namespace Web.Commerce.Business
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Workflow.Activities.Rules;
    using System.Workflow.ComponentModel.Compiler;
    using System.Workflow.ComponentModel.Serialization;
    using System.Xml;

    public class RuleEngine<T> : IRuleEngine<T> where T :class 
    {
        #region rule variables

        private readonly WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
        private RuleSet ruleSet = null;
        private RuleValidation ruleValidation = null;
        private RuleExecution ruleExecution = null;
        private string errorMessage;

        #endregion

        public bool Execute(string ruleSetFilePath, ref T ruleExeObject, out string error)
        {
            if (string.IsNullOrEmpty(ruleSetFilePath))
            {
                throw new ArgumentNullException("ruleSetFilePath");
            }

            if (ruleExeObject == null)
            {
                throw new ArgumentNullException("ruleExeObject");
            }

            bool retVal = false;
            this.ruleSet = this.DeserializeRuleSet(ruleSetFilePath);
            if (this.ruleSet != null
                && this.IsRuleSetValid(ruleExeObject))
            {
                this.ruleSet.Execute(this.ruleExecution);
                retVal = true;
            }

            error = this.errorMessage;
            return retVal;
        }

        private bool IsRuleSetValid(object helpObject)
        {
            bool isValid = false;
            this.ruleValidation = new RuleValidation(helpObject.GetType(), null);
            if (this.ruleValidation != null
                && this.ruleSet != null
                && !this.ruleSet.Validate(this.ruleValidation))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Validation Errors:");
                foreach (ValidationError validationError in this.ruleValidation.Errors)
                {
                    sb.AppendLine(validationError.ErrorText); ;
                }

                this.errorMessage = sb.ToString();
                return isValid;
            }

            this.ruleExecution = new RuleExecution(this.ruleValidation, helpObject);
            return isValid = true;
        }

        private string SerializeRuleSet(RuleSet ruleSet)
        {
            StringBuilder ruleDefinition = new StringBuilder();

            if (ruleSet != null)
            {
                try
                {
                    StringWriter stringWriter = new StringWriter(ruleDefinition, CultureInfo.InvariantCulture);
                    XmlTextWriter writer = new XmlTextWriter(stringWriter);
                    serializer.Serialize(writer, ruleSet);
                    writer.Flush();
                    writer.Close();
                    stringWriter.Flush();
                    stringWriter.Close();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(string.Format(CultureInfo.InvariantCulture, "Error serializing RuleSet: '{0}'. \r\n\n{1}", ruleSet.Name, ex.Message));
                }
            }
            else
            {
                throw new ApplicationException(String.Format(CultureInfo.InvariantCulture, "Error serializing RuleSet: '{0}'. RuleSet is null", ruleSet.Name));
            }

            return ruleDefinition.ToString();
        }

        private RuleSet DeserializeRuleSet(string ruleSetFilePath)
        {
            if (!File.Exists(ruleSetFilePath))
            {
                throw new BusinessException(string.Format("'{0}' path does not exist!!", ruleSetFilePath));
            }

            string xmlString = System.IO.File.ReadAllText(ruleSetFilePath);
            if (!String.IsNullOrEmpty(xmlString))
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                {
                    return serializer.Deserialize(reader) as RuleSet;
                }
            }
            else
            {
                return null;
            }
        }
    }
}

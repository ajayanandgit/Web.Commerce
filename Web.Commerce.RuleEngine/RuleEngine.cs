using System;
using System.IO;
using System.Text;
using System.Workflow.Activities.Rules;
using System.Workflow.ComponentModel.Serialization;
using System.Xml;
using Web.Commerce.Common.Interface;
using Web.Commerce.Entity;

namespace Web.Commerce.RuleEngine
{
    public class RuleEngine<T> : IRuleEngine<T> where T :class 
    {
        #region rule variables

        private readonly WorkflowMarkupSerializer _serializer = new WorkflowMarkupSerializer();
        private RuleSet _ruleSet;
        private RuleValidation _ruleValidation;
        private RuleExecution _ruleExecution;
        private string _errorMessage;

        #endregion

        public bool Execute(string ruleSetFilePath, ref T ruleExeObject, out string error)
        {
            if (string.IsNullOrEmpty(ruleSetFilePath))
            {
                throw new ArgumentNullException("ruleSetFilePath");
            }

            var retVal = false;
            _ruleSet = DeserializeRuleSet(ruleSetFilePath);
            if (_ruleSet != null
                && IsRuleSetValid(ruleExeObject))
            {
                _ruleSet.Execute(_ruleExecution);
                retVal = true;
            }

            error = _errorMessage;
            return retVal;
        }

        private bool IsRuleSetValid(T helpObject)
        {
            _ruleValidation = new RuleValidation(helpObject.GetType(), null);
            if (_ruleValidation != null
                && _ruleSet != null
                && !_ruleSet.Validate(_ruleValidation))
            {
                var sb = new StringBuilder();
                sb.AppendLine("Validation Errors:");
                foreach (var validationError in _ruleValidation.Errors)
                {
                    sb.AppendLine(validationError.ErrorText);
                }

                _errorMessage = sb.ToString();
                return false;
            }

            _ruleExecution = new RuleExecution(_ruleValidation, helpObject);
            return true;
        }

        private RuleSet DeserializeRuleSet(string ruleSetFilePath)
        {
            if (!File.Exists(ruleSetFilePath))
            {
                throw new BusinessException(string.Format("'{0}' path does not exist!!", ruleSetFilePath));
            }

            var xmlString = File.ReadAllText(ruleSetFilePath);
            if (string.IsNullOrEmpty(xmlString)) throw new BusinessException(string.Format("'{0}' file is blank!!", ruleSetFilePath)); ;
            using (var reader = XmlReader.Create(new StringReader(xmlString)))
            {
                return _serializer.Deserialize(reader) as RuleSet;
            }
        }
    }
}

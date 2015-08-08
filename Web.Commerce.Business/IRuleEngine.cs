using System;
namespace Web.Commerce.Business
{
    public interface IRuleEngine<T> where T : class
    {
        bool Execute(string ruleSetFilePath, ref T ruleExeObject, out string error);
    }
}

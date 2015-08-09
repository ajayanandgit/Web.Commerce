using System;
using System.Configuration;
using Web.Commerce.Common.Interface;
using Web.Commerce.Entity;

namespace Web.Commerce.Business
{
    public class OrderOperation
    {
        private readonly IRuleEngine<Order> _ruleExecutor;

        public OrderOperation(IRuleEngine<Order> ruleExecutor)
        {
            _ruleExecutor = ruleExecutor;
        }

        public Order CalculateOrderTotal(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }

            string errorMessage;
            if (_ruleExecutor.Execute(
                ConfigurationManager.AppSettings["RuleFilePath"], 
                ref order, 
                out errorMessage))
            {
                return order;
            }
            throw new BusinessException(errorMessage);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Web.Commerce.Entity;

namespace Web.Commerce.Business
{
    public class OrderOperation
    {
        public Order CalculateOrderTotal(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("Order");
            }

            string errorMessage;
            if (new RuleEngine<Order>().Execute(
                ConfigurationManager.AppSettings["RuleFilePath"], 
                ref order, 
                out errorMessage))
            {
                return order;
            }
            else
            {
                throw new BusinessException(errorMessage);
            }
        }

    }
}

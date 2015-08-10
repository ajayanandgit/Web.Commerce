using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Commerce.Common.Interface;
using Web.Commerce.Entity;
using Web.Commerce.RuleEngine;

namespace Web.Commerce.Business.Tests
{
    [TestClass()]
    public class OrderOperationTests
    {
        [TestMethod()]
        public void OrderOperation_Constructor_Test()
        {
            Assert.IsNotNull(new OrderOperation(null));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateOrderTotal_Null_Arg_Test()
        {
            new OrderOperation(null).CalculateOrderTotal(null);
        }

        [TestMethod()]
        public void CalculateOrderTotal_Rule_Passed_Test()
        {
            var ruleStub = new Mock<RuleEngine<Order>>();
            var ruleEx = ruleStub.As<IRuleEngine<Order>>();
            var order = new Order() {Id = 123};
            string error;

            ruleEx.Setup(c => c.Execute(It.IsAny<string>(), ref order, out error))
                .Returns(true);

            var operation = new OrderOperation(ruleStub.Object);
            var result = operation.CalculateOrderTotal(order);
            Assert.IsNotNull(result);
            Assert.AreEqual(order.Id, result.Id);
        }

        [TestMethod()]
        [ExpectedException(typeof(BusinessException))]
        public void CalculateOrderTotal_Rule_Failed_Test()
        {
            var ruleStub = new Mock<RuleEngine<Order>>();
            var ruleEx = ruleStub.As<IRuleEngine<Order>>();
            var order = new Order() { Id = 123 };
            string error;

            ruleEx.Setup(c => c.Execute(It.IsAny<string>(), ref order, out error))
                .Returns(false);

            var operation = new OrderOperation(ruleStub.Object);
            operation.CalculateOrderTotal(order);
        }
    }

}

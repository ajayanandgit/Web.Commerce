using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Commerce.Entity;
namespace Web.Commerce.EntityTest
{


    [TestClass()]
    public class BusinessExceptionTest
    {
        [TestMethod()]
        public void Initialize_Error_Test()
        {
            var error = "error message";
            var businessException = new BusinessException(error);

            Assert.IsNotNull(businessException);
            Assert.AreEqual(businessException.Message, error);
        }

        [TestMethod()]
        public void Initialize_Error_InnerEx_Test()
        {
            var error = "error message";
            var businessException = new BusinessException(error, new Exception());

            Assert.IsNotNull(businessException);
            Assert.IsNotNull(businessException.InnerException);
            Assert.AreEqual(businessException.Message, error);
        }

    }
}

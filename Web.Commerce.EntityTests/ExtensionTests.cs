using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Commerce.Entity.Tests
{
    [TestClass()]
    public class ExtensionTests
    {
        [TestMethod()]
        public void DifferenceTotalYearsTest()
        {
            var year = DateTime.UtcNow.DifferenceTotalYears(DateTime.UtcNow.AddYears(-2));
            Assert.AreEqual(year, 2);
        }
    }
}

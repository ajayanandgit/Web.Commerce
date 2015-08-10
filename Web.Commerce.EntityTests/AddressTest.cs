
using System;
using Web.Commerce.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Commerce.EntityTest
{
    [TestClass()]
    public class AddressTest
    {
        private Address _address;


        /// <summary>
        /// Code that is run before each test
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            //New instance of address
            _address = new Address();
        }

        #region Property Tests
        
        [TestMethod()]
        public void LastUpdatedUtcTest()
        {
            var expected = new DateTime(1969,7,21);
            _address.LastUpdatedUtc = expected;
            Assert.AreEqual(expected, _address.LastUpdatedUtc, "Web.Commerce.Entity.Address.LastUpdatedUtc property test failed");
        }

        [TestMethod()]
        public void StoreIdTest()
        {
            var expected = 123456L;
            _address.StoreId = expected;
            Assert.AreEqual(expected, _address.StoreId, "Web.Commerce.Entity.Address.StoreId property test failed");
        }


        [TestMethod()]
        public void IdTest()
        {
            var expected = 123;
            _address.Id = expected;
            Assert.AreEqual(expected, _address.Id, "Web.Commerce.Entity.Address.Id property test failed");
        }

        [TestMethod()]
        public void NameTest()
        {
            var expected = "test";
            _address.Name = expected;
            Assert.AreEqual(expected, _address.Name, "Web.Commerce.Entity.Address.Name property test failed");
        }

        [TestMethod()]
        public void Line1Test()
        {
            var expected = "test";
            _address.Line1 = expected;
            Assert.AreEqual(expected, _address.Line1, "Web.Commerce.Entity.Address.Line1 property test failed");
        }

        [TestMethod()]
        public void Line2Test()
        {
            var expected = "test";
            _address.Line2 = expected;
            Assert.AreEqual(expected, _address.Line2, "Web.Commerce.Entity.Address.Line2 property test failed");
        }

        [TestMethod()]
        public void Line3Test()
        {
            var expected = "test";
            _address.Line3 = expected;
            Assert.AreEqual(expected, _address.Line3, "Web.Commerce.Entity.Address.Line3 property test failed");
        }

        [TestMethod()]
        public void CityTest()
        {
            var expected = "test";
            _address.City = expected;
            Assert.AreEqual(expected, _address.City, "Web.Commerce.Entity.Address.City property test failed");
        }


        [TestMethod()]
        public void StateTest()
        {
            var expected = "test";
            _address.State = expected;
            Assert.AreEqual(expected, _address.State, "Web.Commerce.Entity.Address.State property test failed");
        }

        [TestMethod()]
        public void CountryTest()
        {
            var expected = "test";
            _address.Country = expected;
            Assert.AreEqual(expected, _address.Country, "Web.Commerce.Entity.Address.Country property test failed");
        }

        [TestMethod()]
        public void PincodeTest()
        {
            var expected = 123;
            _address.Pincode = expected;
            Assert.AreEqual(expected, _address.Pincode, "Web.Commerce.Entity.Address.Pincode property test failed");
        }

        #endregion
        
    }
}

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Commerce.Entity;

namespace Web.Commerce.EntityTest
{
    [TestClass()]
    public class CustomerTest
    {
        private Customer _customer;

        /// <summary>
        /// Code that is run before each test
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            //New instance of Order
            _customer = new Customer()
            {
                Id = 123,
                FirstName = "test",
                MiddleName = "test",
                LastName = "test",
                Addresses = new List<Address>(),
                Email = "test",
                IsEmployee = true,
                Orders = new List<Order>(),
                PhoneNumber = "test",
                PreferedBillingAddressId = 123,
                PreferedShippingAddressId = 123,
                RegisteredOnUtc = DateTime.UtcNow.AddYears(-2)
            };
        }
        
        #region Property Tests

        [TestMethod()]
        public void IdTest()
        {
            var expected = 123;
            Assert.AreEqual(expected, _customer.Id, "Web.Commerce.Entity.Customer.Id property test failed");
        }

        [TestMethod()]
        public void FirstNameTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _customer.FirstName, "Web.Commerce.Entity.Customer.FirstName property test failed");
        }
             
        [TestMethod()]
        public void MiddleNameTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _customer.MiddleName, "Web.Commerce.Entity.Customer.MiddleName property test failed");
        }

        [TestMethod()]
        public void LastNameTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _customer.LastName, "Web.Commerce.Entity.Customer.LastName property test failed");
        }
        
        [TestMethod()]
        public void EmailTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _customer.Email, "Web.Commerce.Entity.Customer.Email property test failed");
        }
        
        [TestMethod()]
        public void PhoneNumberTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _customer.PhoneNumber, "Web.Commerce.Entity.Customer.PhoneNumber property test failed");
        }

    
        [TestMethod()]
        public void AddressesTest()
        {
            Assert.IsNotNull(_customer.Addresses, "Web.Commerce.Entity.Customer.Addresses property test failed");
        }
     
        [TestMethod()]
        public void OrdersTest()
        {
            Assert.IsNotNull(_customer.Orders, "Web.Commerce.Entity.Customer.Orders property test failed");
        }
        
        [TestMethod()]
        public void RegisteredOnUtcTest()
        {
            var expected = new DateTime(1969,7,21);
            _customer.RegisteredOnUtc = expected;
            Assert.AreEqual(expected, _customer.RegisteredOnUtc, "Web.Commerce.Entity.Customer.RegisteredOnUtc property test failed");
        }
        
        [TestMethod()]
        public void PreferedShippingAddressIdTest()
        {
            var expected = 123;
            Assert.AreEqual(expected, _customer.PreferedShippingAddressId, "Web.Commerce.Entity.Customer.PreferedShippingAddressId property test failed");
        }
        
        [TestMethod()]
        public void PreferedBillingAddressIdTest()
        {
            var expected = 123;
            Assert.AreEqual(expected, _customer.PreferedBillingAddressId, "Web.Commerce.Entity.Customer.PreferedBillingAddressId property test failed");
        }
        
        [TestMethod()]
        public void IsEmployeeTest()
        {
            var expected = true;
            Assert.AreEqual(expected, _customer.IsEmployee, "Web.Commerce.Entity.Customer.IsEmployee property test failed");
        }

        [TestMethod()]
        public void RegisteredForYearsTest()
        {
            var expected = 2;
            _customer.RegisteredOnUtc = DateTime.UtcNow.AddYears(-2);
            Assert.AreEqual(expected, _customer.RegisteredForYears,
                "Web.Commerce.Entity.Customer.RegisteredForYears property test failed");
        }

        #endregion
    }
}

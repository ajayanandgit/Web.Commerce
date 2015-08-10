using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Commerce.Entity;

namespace Web.Commerce.EntityTest
{
    [TestClass()]
    public class OrderTest
    {
        private Order _order;

        /// <summary>
        /// Code that is run before each test
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            //New instance of Order
            _order = new Order()
            {
                Id = 123,
                Items = new List<OrderItem>()
                {
                    new OrderItem()
                    {
                        BasePricePerItem = 10,
                        Quantity = 2,
                        Discount = 2
                    }
                },
                OrderNumber = "test",
                LastUpdatedUtc = new DateTime(1969, 7, 21),
                TimeOfOrderUtc = new DateTime(1969, 7, 21),
                Customer = new Customer(),
                IsPlaced = true,
                BillingAddress = new Address(),
                ShippingAddress = new Address(),
                AffiliateID = "test",
                OrderDiscount = 3.14159265D
            };
        }

        #region Property Tests

        [TestMethod()]
        public void ItemsTest()
        {
            Assert.IsNotNull(_order.Items, "Web.Commerce.Entity.Order.Items property test failed");
        }
        
        [TestMethod()]
        public void IdTest()
        {
            var expected = 123;
            Assert.AreEqual(expected, _order.Id, "Web.Commerce.Entity.Order.Id property test failed");
        }
        
        [TestMethod()]
        public void OrderNumberTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _order.OrderNumber, "Web.Commerce.Entity.Order.OrderNumber property test failed");
        }
        
        [TestMethod()]
        public void LastUpdatedUtcTest()
        {
            var expected = new DateTime(1969,7,21);
            Assert.AreEqual(expected, _order.LastUpdatedUtc, "Web.Commerce.Entity.Order.LastUpdatedUtc property test failed");
        }
        
        [TestMethod()]
        public void TimeOfOrderUtcTest()
        {
            var expected = new DateTime(1969,7,21);
            Assert.AreEqual(expected, _order.TimeOfOrderUtc, "Web.Commerce.Entity.Order.TimeOfOrderUtc property test failed");
        }
        
        [TestMethod()]
        public void CustomerTest()
        {
            Assert.IsNotNull(_order.Customer, "Web.Commerce.Entity.Order.Customer property test failed");
        }
        
        [TestMethod()]
        public void IsPlacedTest()
        {
            var expected = true;
            Assert.AreEqual(expected, _order.IsPlaced, "Web.Commerce.Entity.Order.IsPlaced property test failed");
        }
        
        [TestMethod()]
        public void BillingAddressTest()
        {
            Assert.IsNotNull(_order.BillingAddress, "Web.Commerce.Entity.Order.BillingAddress property test failed");
        }

        [TestMethod()]
        public void ShippingAddressTest()
        {
            Assert.IsNotNull(_order.ShippingAddress, "Web.Commerce.Entity.Order.ShippingAddress property test failed");
        }
        
        [TestMethod()]
        public void AffiliateIDTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _order.AffiliateID, "Web.Commerce.Entity.Order.AffiliateID property test failed");
        }
        
        [TestMethod()]
        public void IsAffiliateTest()
        {
            var expected = true;
            Assert.AreEqual(expected, _order.IsAffiliate, "Web.Commerce.Entity.Order.IsAffiliate property test failed");
        }

        [TestMethod()]
        public void OrderDiscountTest()
        {
            var expected = 3.14159265D;
            Assert.AreEqual(expected, _order.OrderDiscount, "Web.Commerce.Entity.Order.OrderDiscount property test failed");
        }
        
        [TestMethod()]
        public void EnumeratorTest()
        {
            IEnumerator<OrderItem> expected = null;
            _order.Enumerator = expected;
            Assert.AreEqual(expected, _order.Enumerator, "Web.Commerce.Entity.Order.Enumerator property test failed");
        }
        
        [TestMethod()]
        public void CurrentItemTest()
        {
            var expected = new OrderItem();
            _order.CurrentItem = expected;
            Assert.AreEqual(expected, _order.CurrentItem, "Web.Commerce.Entity.Order.CurrentItem property test failed");
        }
        
        [TestMethod()]
        public void TotalOrderBeforeDiscountsTest()
        {
            var expected = 20D;
            Assert.AreEqual(expected, _order.TotalOrderBeforeDiscounts, "Web.Commerce.Entity.Order.TotalOrderBeforeDiscounts property test failed");
        }
        
        [TestMethod()]
        public void TotalOrderDiscountsTest()
        {
            var expected = 3.14159265D + 2D;
            Assert.AreEqual(expected, _order.TotalOrderDiscounts, "Web.Commerce.Entity.Order.TotalOrderDiscounts property test failed");
        }
        
        [TestMethod()]
        public void TotalOrderAfterDiscountsTest()
        {
            var expected = 20 - 5.14159265D;
            Assert.AreEqual(expected, _order.TotalOrderAfterDiscounts, "Web.Commerce.Entity.Order.TotalOrderAfterDiscounts property test failed");
        }
        
        [TestMethod()]
        public void TotalGrandTest()
        {
            var expected = 20 - 5.14159265D;
            Assert.AreEqual(expected, _order.TotalGrand, "Web.Commerce.Entity.Order.TotalGrand property test failed");
        }
        
        [TestMethod()]
        public void TotalQuantityTest()
        {
            var expected = 2;
            Assert.AreEqual(expected, _order.TotalQuantity, "Web.Commerce.Entity.Order.TotalQuantity property test failed");
        }

        #endregion
    }
}

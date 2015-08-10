
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Commerce.Entity;

namespace Web.Commerce.EntityTest
{
    [TestClass()]
    public class OrderItemTest
    {
        private OrderItem _orderItem;
        
        /// <summary>
        /// Code that is run before each test
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            //New instance of Order Item
            _orderItem = new OrderItem()
            {
                Id = 123456L,
                LastUpdatedUtc = new DateTime(1969, 7, 21),
                BasePricePerItem = 3.14159265D,
                Discount = 3.14159265D,
                OrderId = "test",
                ProductId = "test",
                ItemType = ProductItemType.Apparel,
                VariantId = "test",
                ProductName = "test",
                ProductSku = "test",
                Quantity = 123,
                ProductShortDescription = "test",
                ShipFromAddress = new Address(),
                ShippingSchedule = new DateTime(1969, 7, 21),
                ProductShippingHeight = 3.14159265D,
                ProductShippingLength = 3.14159265D,
                ProductShippingWeight = 3.14159265D,
                ProductShippingWidth = 3.14159265D,
                ShipFromNotificationId = "test"
            };
        }

        #region Property Tests


        [TestMethod()]
        public void IdTest()
        {
            var expected = 123456L;
            Assert.AreEqual(expected, _orderItem.Id, "Web.Commerce.Entity.OrderItem.Id property test failed");
        }

        [TestMethod()]
        public void LastUpdatedUtcTest()
        {
            var expected = new DateTime(1969, 7, 21);
            Assert.AreEqual(expected, _orderItem.LastUpdatedUtc,
                "Web.Commerce.Entity.OrderItem.LastUpdatedUtc property test failed");
        }

        [TestMethod()]
        public void BasePricePerItemTest()
        {
            var expected = 3.14159265D;
            Assert.AreEqual(expected, _orderItem.BasePricePerItem,
                "Web.Commerce.Entity.OrderItem.BasePricePerItem property test failed");
        }

        [TestMethod()]
        public void DiscountTest()
        {
            var expected = 3.14159265D;
            Assert.AreEqual(expected, _orderItem.Discount, "Web.Commerce.Entity.OrderItem.Discount property test failed");
        }

        [TestMethod()]
        public void OrderIdTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _orderItem.OrderId, "Web.Commerce.Entity.OrderItem.OrderId property test failed");
        }

        [TestMethod()]
        public void ProductIdTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _orderItem.ProductId,
                "Web.Commerce.Entity.OrderItem.ProductId property test failed");
        }

        [TestMethod()]
        public void ItemTypeTest()
        {
            var expected = ProductItemType.Apparel;
            Assert.AreEqual(expected, _orderItem.ItemType, "Web.Commerce.Entity.OrderItem.ItemType property test failed");
        }

        [TestMethod()]
        public void VariantIdTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _orderItem.VariantId,
                "Web.Commerce.Entity.OrderItem.VariantId property test failed");
        }

        [TestMethod()]
        public void ProductNameTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _orderItem.ProductName,
                "Web.Commerce.Entity.OrderItem.ProductName property test failed");
        }

        [TestMethod()]
        public void ProductSkuTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _orderItem.ProductSku,
                "Web.Commerce.Entity.OrderItem.ProductSku property test failed");
        }

        [TestMethod()]
        public void ProductShortDescriptionTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _orderItem.ProductShortDescription,
                "Web.Commerce.Entity.OrderItem.ProductShortDescription property test failed");
        }

        [TestMethod()]
        public void QuantityTest()
        {
            var expected = 123;
            Assert.AreEqual(expected, _orderItem.Quantity, "Web.Commerce.Entity.OrderItem.Quantity property test failed");
        }

        [TestMethod()]
        public void ShippingScheduleTest()
        {
            var expected = new DateTime(1969, 7, 21);
            Assert.AreEqual(expected, _orderItem.ShippingSchedule,
                "Web.Commerce.Entity.OrderItem.ShippingSchedule property test failed");
        }

        [TestMethod()]
        public void ProductShippingWeightTest()
        {
            var expected = 3.14159265D;
            Assert.AreEqual(expected, _orderItem.ProductShippingWeight,
                "Web.Commerce.Entity.OrderItem.ProductShippingWeight property test failed");
        }

        [TestMethod()]
        public void ProductShippingLengthTest()
        {
            var expected = 3.14159265D;
            Assert.AreEqual(expected, _orderItem.ProductShippingLength,
                "Web.Commerce.Entity.OrderItem.ProductShippingLength property test failed");
        }

        [TestMethod()]
        public void ProductShippingWidthTest()
        {
            var expected = 3.14159265D;
            Assert.AreEqual(expected, _orderItem.ProductShippingWidth,
                "Web.Commerce.Entity.OrderItem.ProductShippingWidth property test failed");
        }

        [TestMethod()]
        public void ProductShippingHeightTest()
        {
            var expected = 3.14159265D;
            Assert.AreEqual(expected, _orderItem.ProductShippingHeight,
                "Web.Commerce.Entity.OrderItem.ProductShippingHeight property test failed");
        }

        [TestMethod()]
        public void ShipFromNotificationIdTest()
        {
            var expected = "test";
            Assert.AreEqual(expected, _orderItem.ShipFromNotificationId,
                "Web.Commerce.Entity.OrderItem.ShipFromNotificationId property test failed");
        }

        [TestMethod()]
        public void ShipFromAddressTest()
        {
            Assert.IsNotNull(_orderItem.ShipFromAddress,
                "Web.Commerce.Entity.OrderItem.ShipFromAddress property test failed");
        }

        [TestMethod()]
        public void LineTotalWithoutDiscountsTest()
        {
            var expected = 3.14159265D*123;
            Assert.AreEqual(expected, _orderItem.LineTotalWithoutDiscounts,
                "Web.Commerce.Entity.OrderItem.LineTotalWithoutDiscounts property test failed");
        }

        [TestMethod()]
        public void LineTotalTest()
        {
            var expected = 3.14159265D*123 - 3.14159265D;
            Assert.AreEqual(expected, _orderItem.LineTotal,
                "Web.Commerce.Entity.OrderItem.LineTotal property test failed");
        }

        #endregion

        #region Method Tests

        [TestMethod()]
        public void EqualsTest()
        {
            var expected = true;

            //Parameters
            var other = new OrderItem() {Id = 123456L};

            var results = _orderItem.Equals(other);
            Assert.AreEqual(expected, results, "Web.Commerce.Entity.OrderItem.Equals method test failed");

        }

        #endregion

    }
}

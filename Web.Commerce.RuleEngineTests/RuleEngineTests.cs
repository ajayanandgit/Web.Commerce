using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Workflow.Activities.Rules;
using Web.Commerce.Entity;

namespace Web.Commerce.RuleEngine.Tests
{
    [TestClass()]
    public class RuleEngineTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Execute_First_Null_Arg_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            Order order = new Order();
            string error;
            engine.Execute(null, ref order, out error);
        }

        [TestMethod()]
        [ExpectedException(typeof(RuleEvaluationException))]
        public void Execute_Null_OrderItem_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            Order order = new Order();
            string error;
            engine.Execute(
                ConfigurationManager.AppSettings["RuleFilePath"],
                ref order,
                out error);
        }

        [TestMethod()]
        public void Execute_Empty_Object_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            Order order = new Order()
            {
                Items = new List<OrderItem>()
            };

            string error;
            Assert.IsTrue(engine.Execute(
                ConfigurationManager.AppSettings["RuleFilePath"],
                ref order,
                out error));
        }

        [TestMethod()]
        [ExpectedException(typeof(BusinessException))]
        public void Execute_InValidRulePath_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            Order order = new Order()
            {
                Items = new List<OrderItem>()
            };

            string error;
            Assert.IsTrue(engine.Execute(
                "test",
                ref order,
                out error));
        }

        [TestMethod()]
        [ExpectedException(typeof(BusinessException))]
        public void Execute_InValidRuleFile_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            Order order = new Order()
            {
                Items = new List<OrderItem>()
            };

            string path = Environment.CurrentDirectory + "\\test.txt";
            using (var stream = File.Create(path))
            {
                stream.Close();
            }

            string error;
            Assert.IsTrue(engine.Execute(
                path,
                ref order,
                out error));
        }

        [TestMethod()]
        public void Execute_InValidObjectForRule_Test()
        {
            RuleEngine<OrderItem> engine = new RuleEngine<OrderItem>();
            OrderItem orderItem = new OrderItem();

            string error;
            Assert.IsFalse(engine.Execute(
                ConfigurationManager.AppSettings["RuleFilePath"],
                ref orderItem,
                out error));
        }

        [TestMethod()]
        public void Execute_Employee_LessThan_100_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            var order = new Order
            {
                Id = 1,
                Customer = new Customer { IsEmployee = true },
                Items = new List<OrderItem>()
            };

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 40,
                Quantity = 1,
                ItemType = ProductItemType.Apparel
            });

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 50,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            string error;
            Assert.IsTrue(engine.Execute(
                ConfigurationManager.AppSettings["RuleFilePath"],
                ref order,
                out error));
            Assert.AreEqual(order.TotalOrderDiscounts, 12D);
        }


        [TestMethod()]
        public void Execute_EmployeeNoDiscountOnGrocery_LessThan_100_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            var order = new Order
            {
                Id = 1,
                Customer = new Customer { IsEmployee = true },
                Items = new List<OrderItem>()
            };

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 50,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            string error;
            Assert.IsTrue(engine.Execute(
                ConfigurationManager.AppSettings["RuleFilePath"],
                ref order,
                out error));
            Assert.AreEqual(order.TotalOrderDiscounts, 0D);
        }
        
        
        [TestMethod()]
        public void Execute_Employee_LessThan_890_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            var order = new Order
            {
                Id = 1,
                Customer = new Customer { IsEmployee = true },
                Items = new List<OrderItem>()
            };

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 100,
                Quantity = 8,
                ItemType = ProductItemType.Apparel
            });

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 90,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            string error;
            Assert.IsTrue(engine.Execute(
                ConfigurationManager.AppSettings["RuleFilePath"],
                ref order,
                out error));
            Assert.AreEqual(order.TotalOrderDiscounts, 240D + 30D);
        }


        [TestMethod()]
        public void Execute_Affiliate_LessThan_100_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            var order = new Order
            {
                Id = 1,
                Customer = new Customer (),
                Items = new List<OrderItem>(),
                AffiliateId = "AFF-10"
            };

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 40,
                Quantity = 1,
                ItemType = ProductItemType.Apparel
            });

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 50,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            string error;
            Assert.IsTrue(engine.Execute(
                ConfigurationManager.AppSettings["RuleFilePath"],
                ref order,
                out error));
            Assert.AreEqual(order.TotalOrderDiscounts, 4D);
        }

        [TestMethod()]
        public void Execute_Affiliate_LessThan_890_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            var order = new Order
            {
                Id = 1,
                Customer = new Customer (),
                Items = new List<OrderItem>(),
                AffiliateId = "AFF-10"
            };

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 100,
                Quantity = 8,
                ItemType = ProductItemType.Apparel
            });

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 90,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            string error;
            Assert.IsTrue(engine.Execute(
                ConfigurationManager.AppSettings["RuleFilePath"],
                ref order,
                out error));
            Assert.AreEqual(order.TotalOrderDiscounts, 80D + 40D);
        }
        
        [TestMethod()]
        public void Execute_CustomerAndAffiliate_LessThan_100_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            var order = new Order
            {
                Id = 1,
                Customer = new Customer { RegisteredOnUtc = DateTime.UtcNow.AddYears(3) },
                Items = new List<OrderItem>(),
                AffiliateId = "AFF-10"
            };

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 40,
                Quantity = 1,
                ItemType = ProductItemType.Apparel
            });

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 50,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            string error;
            Assert.IsTrue(engine.Execute(
                ConfigurationManager.AppSettings["RuleFilePath"],
                ref order,
                out error));
            Assert.AreEqual(order.TotalOrderDiscounts, 4D);
        }

        [TestMethod()]
        public void Execute_CustomerAndAffiliate_LessThan_890_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            var order = new Order
            {
                Id = 1,
                Customer = new Customer { RegisteredOnUtc = DateTime.UtcNow.AddYears(3) },
                Items = new List<OrderItem>(),
                AffiliateId = "AFF-10"
            };

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 100,
                Quantity = 8,
                ItemType = ProductItemType.Apparel
            });

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 90,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            string error;
            Assert.IsTrue(engine.Execute(
                ConfigurationManager.AppSettings["RuleFilePath"],
                ref order,
                out error));
            Assert.AreEqual(order.TotalOrderDiscounts, 80D + 40D);
        }

        [TestMethod()]
        public void Execute_CustomerMoreThan2_LessThan_100_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            var order = new Order
            {
                Id = 1,
                Customer = new Customer { RegisteredOnUtc = DateTime.UtcNow.AddYears(3) },
                Items = new List<OrderItem>()
            };

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 40,
                Quantity = 1,
                ItemType = ProductItemType.Apparel
            });

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 50,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            string error;
            Assert.IsTrue(engine.Execute(
                ConfigurationManager.AppSettings["RuleFilePath"],
                ref order,
                out error));
            Assert.AreEqual(order.TotalOrderDiscounts, 2D);
        }

        [TestMethod()]
        public void Execute_CustomerMoreThan2_LessThan_890_Test()
        {
            RuleEngine<Order> engine = new RuleEngine<Order>();
            var order = new Order
            {
                Id = 1,
                Customer = new Customer { RegisteredOnUtc = DateTime.UtcNow.AddYears(3) },
                Items = new List<OrderItem>()
            };

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 100,
                Quantity = 8,
                ItemType = ProductItemType.Apparel
            });

            order.Items.Add(new OrderItem
            {
                BasePricePerItem = 90,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            string error;
            Assert.IsTrue(engine.Execute(
                ConfigurationManager.AppSettings["RuleFilePath"],
                ref order,
                out error));
            Assert.AreEqual(order.TotalOrderDiscounts, 40D + 40D);
        }
    }
}

using System;
using System.Collections.Generic;
using Web.Commerce.Business;
using Web.Commerce.Entity;
using Web.Commerce.RuleEngine;

namespace Web.Commerce.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // employee
            var order1 = new Order
            {
                Id = 1,
                Customer = new Customer { IsEmployee = true },
                Items = new List<OrderItem>()
            };

            order1.Items.Add(new OrderItem
            {
                BasePricePerItem = 40,
                Quantity = 1,
                ItemType = ProductItemType.Apparel
            });

            order1.Items.Add(new OrderItem
            {
                BasePricePerItem = 50,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            var service = new OrderOperation(new RuleEngine<Order>());
            var result1 = service.CalculateOrderTotal(order1);

            Console.WriteLine(result1.TotalGrand);

            // Affiliate
            var order2 = new Order
            {
                Id = 1,
                Customer = new Customer(),
                Items = new List<OrderItem>(),
                AffiliateId = "AFF-10"
            };

            order2.Items.Add(new OrderItem
            {
                BasePricePerItem = 40,
                Quantity = 1,
                ItemType = ProductItemType.Apparel
            });

            order2.Items.Add(new OrderItem
            {
                BasePricePerItem = 50,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            var result2 = service.CalculateOrderTotal(order2);

            Console.WriteLine(result2.TotalGrand);

            // more than 2 year
            var order3 = new Order
            {
                Id = 1,
                Customer = new Customer { RegisteredOnUtc = DateTime.UtcNow.AddYears(3) },
                Items = new List<OrderItem>()
            };

            order3.Items.Add(new OrderItem
            {
                BasePricePerItem = 40,
                Quantity = 1,
                ItemType = ProductItemType.Apparel
            });

            order3.Items.Add(new OrderItem
            {
                BasePricePerItem = 50,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            var result3 = service.CalculateOrderTotal(order3);

            Console.WriteLine(result3.TotalGrand);

            // no discount
            var order = new Order
            {
                Id = 1,
                Customer = new Customer() {RegisteredOnUtc = DateTime.UtcNow.AddYears(1)},
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

            var result4 = service.CalculateOrderTotal(order);

            Console.WriteLine(result4.TotalGrand);
            

            Console.ReadKey();
        }
    }
}

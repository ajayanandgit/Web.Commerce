using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Commerce.Business;
using Web.Commerce.Entity;

namespace Web.Commerce.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // employee
            Order order1 = new Order()
            {
                Id = 1,
                Customer = new Customer() { IsEmployee = true },
                Items = new List<OrderItem>()
            };

            order1.Items.Add(new OrderItem()
            {
                BasePricePerItem = 40,
                Quantity = 1,
                ItemType = ProductItemType.Apparel
            });

            order1.Items.Add(new OrderItem()
            {
                BasePricePerItem = 50,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            OrderOperation service = new OrderOperation();
            var orde = service.CalculateOrderTotal(order1);

            System.Console.WriteLine(orde.TotalGrand);

            // Affiliate
            Order order2 = new Order()
            {
                Id = 1,
                Customer = new Customer(),
                Items = new List<OrderItem>(),
                AffiliateID = "AFF-10"
            };

            order2.Items.Add(new OrderItem()
            {
                BasePricePerItem = 40,
                Quantity = 1,
                ItemType = ProductItemType.Apparel
            });

            order2.Items.Add(new OrderItem()
            {
                BasePricePerItem = 50,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            var orde2 = service.CalculateOrderTotal(order2);

            System.Console.WriteLine(orde2.TotalGrand);

            // more than 2 year
            Order order3 = new Order()
            {
                Id = 1,
                Customer = new Customer() { RegisteredOnUtc = DateTime.UtcNow.AddYears(3) },
                Items = new List<OrderItem>()
            };

            order3.Items.Add(new OrderItem()
            {
                BasePricePerItem = 40,
                Quantity = 1,
                ItemType = ProductItemType.Apparel
            });

            order3.Items.Add(new OrderItem()
            {
                BasePricePerItem = 50,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            var orde3 = service.CalculateOrderTotal(order3);

            System.Console.WriteLine(orde3.TotalGrand);

            // no discount
            Order order = new Order()
            {
                Id = 1,
                Customer = new Customer(),
                Items = new List<OrderItem>()
            };

            order.Items.Add(new OrderItem()
            {
                BasePricePerItem = 40,
                Quantity = 1,
                ItemType = ProductItemType.Apparel
            });

            order.Items.Add(new OrderItem()
            {
                BasePricePerItem = 50,
                Quantity = 1,
                ItemType = ProductItemType.Grocery
            });

            var orde4 = service.CalculateOrderTotal(order);

            System.Console.WriteLine(orde4.TotalGrand);

            Console.ReadKey();
        }
    }
}

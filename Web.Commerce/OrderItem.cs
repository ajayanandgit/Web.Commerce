using System;

namespace Web.Commerce.Entity
{
    public class OrderItem
    {
        public long Id { get; set; }
        public DateTime LastUpdatedUtc { get; set; }
        public double BasePricePerItem { get; set; }
        public double Discount { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public ProductItemType ItemType { get; set; }
        public string VariantId { get; set; }
        public string ProductName { get; set; }
        public string ProductSku { get; set; }
        public string ProductShortDescription { get; set; }
        public int Quantity { get; set; }
        public long ShippingSchedule { get; set; }
        public double ProductShippingWeight { get; set; }
        public double ProductShippingLength { get; set; }
        public double ProductShippingWidth { get; set; }
        public double ProductShippingHeight { get; set; }
        public string ShipFromNotificationId { get; set; }
        public Address ShipFromAddress { get; set; }

        public double LineTotalWithoutDiscounts
        {
            get { return (BasePricePerItem*Quantity); }
        }

        public double LineTotal
        {
            get
            {
                var result = BasePricePerItem*Quantity;
                return result - Discount;
            }
        }

        public virtual bool Equals(OrderItem other)
        {
            return Id == other.Id;
        }
    }
}
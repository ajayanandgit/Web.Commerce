using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Commerce.Entity
{
    public class Order
    {
        // Sub Items
        public List<OrderItem> Items { get; set; }

        // Basics
        public int Id { get; set; } //  primary key
        public string OrderNumber { get; set; } // invoice to show alpha numeric value
        public DateTime LastUpdatedUtc { get; set; }
        public DateTime TimeOfOrderUtc { get; set; }

        public virtual Customer Customer { get; set; }


        public bool IsPlaced { get; set; }

        // Addresses
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }

        // Others
        public string AffiliateID { get; set; }

        public bool IsAffiliate
        {
            get
            {
                return string.IsNullOrEmpty(this.AffiliateID) ? false : true;
            }
        }

        public double OrderDiscount { get; set; }

        public IEnumerator<OrderItem> Enumerator { get; set; }

        public OrderItem CurrentItem { get; set; }
        
        // Calculated Properties                
        public double TotalOrderBeforeDiscounts
        {
            get
            {
                double result = 0;
                if (this.Items.Count > 0)
                {
                    result = this.Items.Sum(y => y.LineTotalWithoutDiscounts);
                }

                return result;
            }
        }

        public double TotalOrderDiscounts
        {
            get
            {
                double result = 0;
                if (this.Items.Count > 0)
                {
                    result = this.Items.Sum(y => y.Discount) + this.OrderDiscount;
                }

                return result;
            }
        }

        public double TotalOrderAfterDiscounts
        {
            get { return TotalOrderBeforeDiscounts - TotalOrderDiscounts; }
        }

        public double TotalGrand
        {
            get
            {
                // this property can be used for shipping, tax - which is not considered 
                return this.TotalOrderAfterDiscounts;
            }
        }

        public int TotalQuantity
        {
            get
            {
                return this.Items.Sum(y => y.Quantity);
            }
        }              
        
    }
}

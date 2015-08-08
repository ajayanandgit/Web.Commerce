using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Commerce.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Address> Addresses { get; set; }
        public virtual List<Order> Orders { get; set; }

        public DateTime RegisteredOnUtc { get; set; }

        public int PreferedShippingAddressId { get; set; }
        public int PreferedBillingAddressId { get; set; }

        public bool IsEmployee { get; set; }

        public int RegisteredForYears
        {
            get
            {
                return this.RegisteredOnUtc.DifferenceTotalYears(DateTime.UtcNow);
            }
        }
    }
}

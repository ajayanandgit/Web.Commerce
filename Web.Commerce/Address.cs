using System;

namespace Web.Commerce.Entity
{
    public class Address
    {
        public DateTime LastUpdatedUtc { get; set; }
        public long StoreId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Pincode { get; set; }
    }
}
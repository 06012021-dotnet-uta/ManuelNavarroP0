using System;
using System.Collections.Generic;

#nullable disable

namespace P0DbContext
{
    public partial class CustomersAddress
    {
        public CustomersAddress()
        {
            Customers = new HashSet<Customer>();
        }

        public int AddressId { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}

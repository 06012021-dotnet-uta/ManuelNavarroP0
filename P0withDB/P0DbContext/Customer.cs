using System;
using System.Collections.Generic;

#nullable disable

namespace P0DbContext
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustId { get; set; }
        public string CustFname { get; set; }
        public string CustLname { get; set; }
        public string CustPhoneNum { get; set; }
        public string CustEmail { get; set; }
        public string CustUsername { get; set; }
        public string CustPassword { get; set; }
        public int? AddressId { get; set; }

        public virtual CustomersAddress Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

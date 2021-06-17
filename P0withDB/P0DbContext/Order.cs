using System;
using System.Collections.Generic;

#nullable disable

namespace P0DbContext
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int OrderId { get; set; }
        public decimal? OrderTotal { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? StoreId { get; set; }
        public int? CustId { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}

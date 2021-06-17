using System;
using System.Collections.Generic;

#nullable disable

namespace P0DbContext
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? DeptId { get; set; }

        public virtual ProductDept Dept { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace P0DbContext
{
    public partial class ProductDept
    {
        public ProductDept()
        {
            Products = new HashSet<Product>();
        }

        public int DeptId { get; set; }
        public string ProductDept1 { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

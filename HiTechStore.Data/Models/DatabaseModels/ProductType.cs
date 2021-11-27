using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }

        public int product_type_id { get; set; }
        public string name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

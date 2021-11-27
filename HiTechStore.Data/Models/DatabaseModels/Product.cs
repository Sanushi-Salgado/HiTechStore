using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class Product
    {
        public Product()
        {
            OrderedItems = new HashSet<OrderedItem>();
        }

        public int product_id { get; set; }
        public int type_id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public string image_url { get; set; }
        public decimal price { get; set; }
        public DateTime created_at { get; set; }

        public virtual ProductType type { get; set; }
        public virtual ICollection<OrderedItem> OrderedItems { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class Item
    {
        public Item()
        {
            OrderedItems = new HashSet<OrderedItem>();
        }

        public int item_id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }

        public virtual ICollection<OrderedItem> OrderedItems { get; set; }
    }
}

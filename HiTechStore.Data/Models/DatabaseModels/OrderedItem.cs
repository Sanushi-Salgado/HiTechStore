using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class OrderedItem
    {
        public int ordered_item_id { get; set; }
        public int customer_order_id { get; set; }
        public int item_id { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }

        public virtual Product item { get; set; }
    }
}

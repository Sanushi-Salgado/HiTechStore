using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class Discount
    {
        public int discount_id { get; set; }
        public int order_id { get; set; }
        public decimal total_price { get; set; }
        public decimal discount1 { get; set; }
        public decimal discounted_price { get; set; }

        public virtual CustomerOrder order { get; set; }
    }
}

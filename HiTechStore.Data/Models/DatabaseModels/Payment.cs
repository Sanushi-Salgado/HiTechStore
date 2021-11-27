using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class Payment
    {
        public int payment_id { get; set; }
        public int order_id { get; set; }
        public decimal total_amount { get; set; }
        public int? discount_id { get; set; }
        public decimal amount_paid { get; set; }
        public string status { get; set; }

        public virtual CustomerOrder order { get; set; }
    }
}

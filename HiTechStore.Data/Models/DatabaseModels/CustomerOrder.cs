using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            Discounts = new HashSet<Discount>();
            Payments = new HashSet<Payment>();
        }

        public int customer_order_id { get; set; }
        public int customer_id { get; set; }
        public DateTime created_at { get; set; }

        public virtual SystemUser customer { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}

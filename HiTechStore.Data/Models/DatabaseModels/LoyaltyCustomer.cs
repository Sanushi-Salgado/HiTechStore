using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class LoyaltyCustomer
    {
        public int loyalty_customer_id { get; set; }
        public int customer_id { get; set; }
        public DateTime joined_at { get; set; }

        public virtual SystemUser customer { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerContactDetails = new HashSet<CustomerContactDetail>();
        }

        public int customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public virtual ICollection<CustomerContactDetail> CustomerContactDetails { get; set; }
    }
}

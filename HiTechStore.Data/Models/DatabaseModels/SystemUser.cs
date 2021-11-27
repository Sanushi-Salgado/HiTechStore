using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class SystemUser
    {
        public SystemUser()
        {
            CustomerContactDetails = new HashSet<CustomerContactDetail>();
            CustomerOrders = new HashSet<CustomerOrder>();
            LoyaltyCustomers = new HashSet<LoyaltyCustomer>();
        }

        public int user_id { get; set; }
        public int user_role_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public virtual UserRole user_role { get; set; }
        public virtual ICollection<CustomerContactDetail> CustomerContactDetails { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
        public virtual ICollection<LoyaltyCustomer> LoyaltyCustomers { get; set; }
    }
}

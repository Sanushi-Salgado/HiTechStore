using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class CustomerContactDetail
    {
        public int customer_contact_id { get; set; }
        public int customer_id { get; set; }
        public string country_code { get; set; }
        public string contact_no { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string state { get; set; }
        public string country { get; set; }

        public virtual SystemUser customer { get; set; }
    }
}

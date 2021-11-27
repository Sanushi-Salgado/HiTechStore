using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class UserRole
    {
        public UserRole()
        {
            SystemUsers = new HashSet<SystemUser>();
        }

        public int user_role_id { get; set; }
        public string name { get; set; }

        public virtual ICollection<SystemUser> SystemUsers { get; set; }
    }
}

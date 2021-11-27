using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class SystemView
    {
        public SystemView()
        {
            UserPrivileges = new HashSet<UserPrivilege>();
        }

        public int view_id { get; set; }
        public string name { get; set; }

        public virtual ICollection<UserPrivilege> UserPrivileges { get; set; }
    }
}

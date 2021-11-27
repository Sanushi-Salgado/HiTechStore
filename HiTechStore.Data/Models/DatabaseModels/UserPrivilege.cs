using System;
using System.Collections.Generic;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class UserPrivilege
    {
        public int privilege_id { get; set; }
        public int user_role_id { get; set; }
        public int view_id { get; set; }
        public bool can_view { get; set; }
        public bool can_add { get; set; }
        public bool can_edit { get; set; }
        public bool can_delete { get; set; }

        public virtual SystemView view { get; set; }
    }
}

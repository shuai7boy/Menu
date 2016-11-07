using System;
using System.Collections.Generic;

namespace MP.Entity.Models
{
    public partial class UserRoleInfo
    {
        public int UserRoleID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string RoleID { get; set; }
    }
}

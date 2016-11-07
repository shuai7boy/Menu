using System;
using System.Collections.Generic;

namespace MP.Entity.Models
{
    public partial class RoleActionInfo
    {
        public int RoleActionID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string ActionID { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace MP.Entity.Models
{
    public partial class UserActionInfo
    {
        public int UserActionID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> ActionID { get; set; }
        public bool IsTrue { get; set; }
    }
}

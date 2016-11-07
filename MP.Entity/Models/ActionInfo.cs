using System;
using System.Collections.Generic;

namespace MP.Entity.Models
{
    public partial class ActionInfo
    {
        public int ActionID { get; set; }
        public string Name { get; set; }
        public string ICON { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public Nullable<int> ParID { get; set; }
    }
}

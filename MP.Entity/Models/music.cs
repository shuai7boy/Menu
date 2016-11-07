using System;
using System.Collections.Generic;

namespace MP.Entity.Models
{
    public partial class music
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string url { get; set; }
        public string pic { get; set; }
    }
}

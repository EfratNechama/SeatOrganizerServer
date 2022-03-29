using System;
using System.Collections.Generic;

#nullable disable

namespace ourProject.Models
{
    public partial class Placement
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int? GuestId { get; set; }

        public virtual Guest Guest { get; set; }
        public virtual Table Table { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ourProject.Models
{
    public partial class CategoryPerEvent
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Event Event { get; set; }
    }
}

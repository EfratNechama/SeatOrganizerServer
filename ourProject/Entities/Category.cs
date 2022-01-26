using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Category
    {
        public Category()
        {
            CategoryPerEvents = new HashSet<CategoryPerEvent>();
            Guests = new HashSet<Guest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual ICollection<CategoryPerEvent> CategoryPerEvents { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual ICollection<CategoryPerEvent> CategoryPerEvents { get; set; }
        [JsonIgnore]
        public virtual ICollection<Guest> Guests { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Table
    {
        public Table()
        {
            Placements = new HashSet<Placement>();
        }

        public int Id { get; set; }
        public bool IsSpecial { get; set; }
        public int NumChair { get; set; }
        public int EventId { get; set; }
        public int? GenderId { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }
        [JsonIgnore]
        public virtual Gender Gender { get; set; }
        [JsonIgnore]
        public virtual ICollection<Placement> Placements { get; set; }
    }
}

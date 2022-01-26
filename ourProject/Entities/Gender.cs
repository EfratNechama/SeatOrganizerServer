using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Gender
    {
        public Gender()
        {
            Guests = new HashSet<Guest>();
            Tables = new HashSet<Table>();
        }

        public int Id { get; set; }
        public bool Male { get; set; }
        public bool Female { get; set; }
        [JsonIgnore]
        public virtual ICollection<Guest> Guests { get; set; }
        [JsonIgnore]
        public virtual ICollection<Table> Tables { get; set; }
    }
}

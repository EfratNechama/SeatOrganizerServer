using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Placement
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int? GuestId { get; set; }

        public int? NumMembers { get; set; }
        [JsonIgnore]
        public virtual Guest Guest { get; set; }
        [JsonIgnore]
        public virtual Table Table { get; set; }
    }
}

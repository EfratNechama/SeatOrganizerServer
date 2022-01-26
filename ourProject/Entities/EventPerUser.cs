using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class EventPerUser
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}

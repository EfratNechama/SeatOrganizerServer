using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class CategoryPerEvent
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int? CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }
    }
}

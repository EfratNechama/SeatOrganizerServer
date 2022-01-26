using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


#nullable disable

namespace Entities
{
    public partial class Table
    {
       // IEventDL ieventdl;
        public Table(int id,bool isSpecial, int numChair, int eventId, int? genderId)
        {
            Placements = new HashSet<Placement>();
            Id = id;
            IsSpecial = isSpecial;
            NumChair = numChair;
            EventId = eventId;
            GenderId = genderId;
          //  Event =
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

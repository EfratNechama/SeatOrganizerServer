using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Event
    {
        public Event()
        {
            CategoryPerEvents = new HashSet<CategoryPerEvent>();
            Guests = new HashSet<Guest>();
            Tables = new HashSet<Table>();
        }

        public int Id { get; set; }
        public bool SeperatedSeats { get; set; }
        public int NumTabelsMale { get; set; }
        public int NumTablesFemale { get; set; }
        public int NumChairsMale { get; set; }
        public int NumChairsFemale { get; set; }
        public int NumSpecialTableChairsMale { get; set; }
        public int NumSpecialTableChairsFemale { get; set; }
        public int UserAId { get; set; }
        public int? UserBId { get; set; }
        public DateTime? DateToSendEmail { get; set; }

        //[JsonIgnore]
        public virtual User UserA { get; set; }
        //[JsonIgnore]
        public virtual User UserB { get; set; }
        [JsonIgnore]
        public virtual ICollection<CategoryPerEvent> CategoryPerEvents { get; set; }
        [JsonIgnore]
        public virtual ICollection<Guest> Guests { get; set; }
        [JsonIgnore]
        public virtual ICollection<Table> Tables { get; set; }
    }
}

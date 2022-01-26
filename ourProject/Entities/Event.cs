using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Event
    {
        public Event()
        {
            Categories = new HashSet<Category>();
            CategoryPerEvents = new HashSet<CategoryPerEvent>();
            Guests = new HashSet<Guest>();
            Tables = new HashSet<Table>();
        }

        public int Id { get; set; }
        public bool SeperatedSeats { get; set; }
        public int NumTabelsMale { get; set; }
        public int NumTablesFemale { get; set; }
        public int? NumChairsMale { get; set; }
        public int? NumChairsFemale { get; set; }
        public int NumSpecialTableChairsMale { get; set; }
        public int? NumSpecialTableChairsFemale { get; set; }
        public byte[] InvitationImage { get; set; }
        public DateTime? DateToSendEmail { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<CategoryPerEvent> CategoryPerEvents { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ourProject.Models
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
        public bool SeparatedSeats { get; set; }
        public int NumTablesMale { get; set; }
        public int? NumTablesFemale { get; set; }
        public int NumChairsMale { get; set; }
        public int? NumChairsFemale { get; set; }
        public int? NumSpecialTableChairsMale { get; set; }
        public int? NumSpecialTableChairsFemale { get; set; }
        public byte[] InvitationImage { get; set; }
        public DateTime? EventDate { get; set; }
        public string InvitationImageName { get; set; }
        public string InvitationImagePath { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<CategoryPerEvent> CategoryPerEvents { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}

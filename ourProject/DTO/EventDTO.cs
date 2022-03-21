using System;

namespace DTO
{
    public class EventDTO 
    {
        //public string userAName { get; set; }
        //public string? userBName { get; set; }


        public int Id { get; set; }
        public bool SeparatedSeats { get; set; }
        public int NumTabelsMale { get; set; }
        public int NumTablesFemale { get; set; }
        public int? NumChairsMale { get; set; }
        public int? NumChairsFemale { get; set; }
        public int NumSpecialTableChairsMale { get; set; }
        public int? NumSpecialTableChairsFemale { get; set; }
        public byte[] InvitationImage { get; set; }
        public DateTime? EventDate { get; set; }

        //public virtual ICollection<Category> Categories { get; set; }
        //public virtual ICollection<CategoryPerEvent> CategoryPerEvents { get; set; }
        //public virtual ICollection<Guest> Guests { get; set; }
        //public virtual ICollection<Table> Tables { get; set; }
    }
}

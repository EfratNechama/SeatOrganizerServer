using System;

namespace DTO
{
    public class EventDTO 
    {

       
       
        public int Id { get; set; }
        public bool SeperatedSeats { get; set; }
        public int NumTabelsMale { get; set; }
        public int NumTablesFemale { get; set; }
        public int NumChairsMale { get; set; }
        public int NumChairsFemale { get; set; }
        public int NumSpecialTableChairsMale { get; set; }
        public int NumSpecialTableChairsFemale { get; set; }
        //public int UserAId { get; set; }
        //public int? UserBId { get; set; }
        public DateTime? DateToSendEmail { get; set; }
        public string userAName { get; set; }
        //public string? userBName { get; set; }

        //public virtual User UserA { get; set; }
        //public virtual User UserB { get; set; }
        //public virtual ICollection<CategoryPerEvent> CategoryPerEvents { get; set; }
        //public virtual ICollection<Guest> Guests { get; set; }
        //public virtual ICollection<Table> Tables { get; set; }
    }
}

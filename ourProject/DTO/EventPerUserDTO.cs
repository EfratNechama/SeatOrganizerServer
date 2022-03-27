using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EventPerUserDTO
    {
        public int UserName { get; set; }
        public int EventId { get; set; }
        public bool SeparatedSeats { get; set; }
        public int NumTablesMale { get; set; }
        public int NumTablesFemale { get; set; }
        public int? NumChairsMale { get; set; }
        public int? NumChairsFemale { get; set; }
        public int NumSpecialTableChairsMale { get; set; }
        public int? NumSpecialTableChairsFemale { get; set; }
        public byte[] InvitationImage { get; set; }
        public DateTime? EventDate { get; set; }
    }
}

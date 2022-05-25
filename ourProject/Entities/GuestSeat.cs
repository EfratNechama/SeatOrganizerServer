using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class GuestSeat
    {


        public int EventId { get; set; }
        public int TableId { get; set; }
        public bool IsSpecial { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Category { get; set; }
        public int NumMembersInTable { get; set; }
       


     
    }
}


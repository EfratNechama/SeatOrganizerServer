using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Entities
{
   public class RecognizedGuest
    {
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public List<int> TableIdList { get; set; }
        public List<int> NumChairsList { get; set; }




    }
}

using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RatingBL: IRatingBL
    {
        IRatingDL iratingdl;
        public RatingBL(IRatingDL iratingdl)
        {
            this.iratingdl = iratingdl;
        }
        public async Task postBL(Rating r)
        {
           await iratingdl.postDL(r);
        }
       
    }
}

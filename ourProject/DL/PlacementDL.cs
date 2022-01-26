using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class PlacementDL :IPlacementDL
    {
        SeatOrgenizerContext _myDB;
        public PlacementDL(SeatOrgenizerContext SeatOrgenizerContext)
        {
            _myDB = SeatOrgenizerContext;
        }

        public async Task postDL(Placement p)
        {
            await _myDB.Placements.AddAsync(p);
            await _myDB.SaveChangesAsync();
        }
    }
}

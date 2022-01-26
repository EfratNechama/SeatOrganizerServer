using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RatingDL: IRatingDL
    {
        SeatOrganizerContext _myDB;
        public RatingDL(SeatOrganizerContext SeatOrgenizerContext)
        {
            _myDB = SeatOrgenizerContext;
        }
        public async Task postDL(Rating r)
        {
            await _myDB.Ratings.AddAsync(r);
            await _myDB.SaveChangesAsync();
        }

    }
}

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
        public RatingDL(SeatOrganizerContext SeatOrganizerContext)
        {
            _myDB = SeatOrganizerContext;
        }
        public async Task postDL(Rating r)
        {
            await _myDB.Ratings.AddAsync(r);
            await _myDB.SaveChangesAsync();
        }

    }
}

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
        SeatOrgenizerContext _myDB;
        public RatingDL(SeatOrgenizerContext SeatOrgenizerContext)
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

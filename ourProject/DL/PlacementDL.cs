using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class PlacementDL :IPlacementDL
    {
        SeatOrganizerContext _myDB;
        public PlacementDL(SeatOrganizerContext SeatOrganizerContext)
        {
            _myDB = SeatOrganizerContext;
        }
        public async Task<List<Table>> getDl(int eventId)
        {
            //List<Event> eventlist = await _myDB.EventPerUsers.Include(e => e.Event).Where(u => u.UserId == id).Select(e => e.Event).ToListAsync();

            //List<Table> l=await _myDB.Tables.Include(t=>t.Placements) 
            List<Table> l=new List<Table>();
            return l;
        }
        public async Task postDL(Placement p)
        {
            await _myDB.Placements.AddAsync(p);
            await _myDB.SaveChangesAsync();
        }
    }
}

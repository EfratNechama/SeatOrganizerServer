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


        public async Task<List<GuestSeat>> getDl(int eventId)
        {
            var query =
               from table in _myDB.Tables
               join placement in _myDB.Placements on table.Id equals placement.TableId
               join guest in _myDB.Guests on placement.GuestId equals guest.Id
               join category in _myDB.Categories on guest.CategoryId equals category.Id
               where table.EventId == eventId
               orderby table.Id , category.Name
               select new GuestSeat { TableId=table.Id, IsSpecial=table.IsSpecial,EventId=table.EventId,FirstName=guest.FirstName,LastName=guest.LastName,NumMembersInTable= (int)placement.NumMembers,Category=category.Name };
           
          return  query.ToList();




        }
        public async Task postDL(Placement p)
        {
            await _myDB.Placements.AddAsync(p);
            await _myDB.SaveChangesAsync();
        }

      public async  Task deleteDL(int eId)
        {
           
            List<Placement> l=await _myDB.Placements.Where(p=>p.Table.EventId==eId).ToListAsync();

            try
            {

               
                _myDB.Placements.RemoveRange(l);
               
                await _myDB.SaveChangesAsync();
            }
            catch (Exception a)
            {
                var w = 1;
            }
        }
    
}
}

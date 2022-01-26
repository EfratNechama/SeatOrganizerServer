using Entities;
using Microsoft.EntityFrameworkCore;

//using ourProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DL
{
    public class GuestDL :IGuestDL
    {
        SeatOrganizerContext _myDB;
        public GuestDL(SeatOrganizerContext SeatOrganizerContext)
        {
            _myDB = SeatOrganizerContext;
        }

        public async Task<List<Guest>> GetDL(int id)
        {
            List<Guest> g = await _myDB.Guests.Where(g => g.EventId == id).ToListAsync();
            return g;
        }

        //placement
        public async Task<List<Guest>> GetDLOrderByFamilySize(int id)
        {
            //יש לזכור לשנות את המיון לפי גודל המשפחה!!
            List<Guest> g = await _myDB.Guests.OrderByDescending(g => g.FirstName).Where(g => g.EventId == id).ToListAsync();

            return g;
        }

        public async Task PostDL(Guest g)
        {
            await _myDB.Guests.AddAsync(g);
            
            await _myDB.SaveChangesAsync(); 
            
            
        }

        public async Task PutDL(int id, Guest g)
        {
            Guest guestToUpdate = await _myDB.Guests.FindAsync(id);
            if (guestToUpdate == null)
            {
                return;
            }
            _myDB.Entry(guestToUpdate).CurrentValues.SetValues(g);


            try { await _myDB.SaveChangesAsync(); }
            catch (Exception e)
            {
                var d = 5;
            }
            
        }

        public async Task DeleteDL(int id)
        {
            Guest g = await _myDB.Guests.FindAsync(id);
            _myDB.Guests.Remove(g);
            await _myDB.SaveChangesAsync();
        }

        //public async Task sendMailDl

    }
}

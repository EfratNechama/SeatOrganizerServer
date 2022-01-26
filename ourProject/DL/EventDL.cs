using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DL
{
   public class EventDL :IEventDL
    {
        SeatOrgenizerContext _myDB;
        ILogger<EventDL> logger;
        public EventDL(SeatOrgenizerContext SeatOrgenizerContext, ILogger<EventDL> logger)
        {
            _myDB = SeatOrgenizerContext;
            this.logger = logger;
        }

        public async Task<List<Event>> getEventByUserIdDL(int id)
        {
           // try
            //{
                List<Event> eventlist = await _myDB.Events.Where(e => e.UserAId.Equals(id) || e.UserBId.Equals(id)).ToListAsync();
                return eventlist;
            /*}
            catch ( Exception ex){ logger.LogError(ex.Message); };
            return null;*/
           
        }

        public async Task<Event> getEventByEventIdDL(int id)
        {

            Event e = await _myDB.Events.Where(e => e.Id.Equals(id)).FirstOrDefaultAsync();
            
                return e;
             }

        public async Task PostDL(Event e)
        {
            await _myDB.Events.AddAsync(e);
            await _myDB.SaveChangesAsync();
        }
        
        public async Task PutDL(int id,Event e)
        {
            Event eventToUpdate = await _myDB.Events.FindAsync(id);
            if (eventToUpdate == null)
            {
                return;
            }
            _myDB.Entry(eventToUpdate).CurrentValues.SetValues(e);
            await _myDB.SaveChangesAsync();
        }

        public async Task DeleteDL(int id)
        {
           Event e= await _myDB.Events.FindAsync(id);
             _myDB.Events.Remove(e);
            await _myDB.SaveChangesAsync();
        }

    }
}

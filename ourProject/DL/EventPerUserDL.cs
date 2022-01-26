using Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
  public   class EventPerUserDL: IEventPerUserDL
    {
        SeatOrganizerContext _myDB;
        public EventPerUserDL(SeatOrganizerContext SeatOrganizerContext)
        {
            _myDB = SeatOrganizerContext;
        }

        public async Task PostDL(EventPerUser epud)
        {
            await _myDB.EventPerUsers.AddAsync(epud);

            await _myDB.SaveChangesAsync();

        }

        public async Task<List<Event>> GetEventListByUserIdDL(int userId )
        {
            List< EventPerUser > eventPerUsersList = await _myDB.EventPerUsers.Where(epu=>epu.UserId== userId).ToListAsync();
            List<Event> eventList = new List<Event>();
            for (int i=0; i< eventPerUsersList.Count; i++)
            {
                Event e = await _myDB.Events.FindAsync(eventPerUsersList[i].EventId);
                eventList.Add(e);
               
            }

            return eventList;
        }
    }
}

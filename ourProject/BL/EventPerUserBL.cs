using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public  class EventPerUserBL: IEventPerUserBL
    {
        IEventPerUserDL ieventperuserdl;

        public EventPerUserBL(IEventPerUserDL ieventperuserdl)
        {
            this.ieventperuserdl = ieventperuserdl;
        }

        public async Task<List<Event>> GetEventListByUserIdBL(int userId)
        {
          return  await ieventperuserdl.GetEventListByUserIdDL(userId);
        }

    }
}

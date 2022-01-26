using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BL
{
    public class EventBL : IEventBL
    {
        IEventDL ieventdl;
        ITableDL itabledl;

        public EventBL(IEventDL ieventdl, ITableDL itabledl)
        {
            this.ieventdl = ieventdl;
            this.itabledl = itabledl;
        }
        public async Task<List<Event>> getEventByUserIdBL(int id)
        {
            return await ieventdl.getEventByUserIdDL(id);
        }
        public async Task<Event> getEventByEventIdBL(int id)
        {
            return await ieventdl.getEventByEventIdDL(id);
        }
        public async Task PostBL(Event e)
        {
            await ieventdl.PostDL(e);



            //post table by the event details 
            for (int i = 0; i < e.NumTabelsMale; i++)
            {
                Table t = new Table(0, false, (int)(e.NumChairsMale), e.Id,1);

                await itabledl.PostDL(t);
            }
            for (int i = 0; i < e.NumTablesFemale; i++)
            {
                Table t = new Table(0, false, (int)(e.NumChairsFemale), e.Id,3);
                await itabledl.PostDL(t);
            }
            //why did we call it NumSpecialTableChairsMale?
            for (int i = 0; i < e.NumSpecialTableChairsMale; i++)
            {
                Table t = new Table(0, true, (int)(e.NumSpecialTableChairsMale), e.Id,1);
                await itabledl.PostDL(t);
            }
            for (int i = 0; i < e.NumSpecialTableChairsFemale; i++)
            {
                Table t = new Table(0, true, (int)(e.NumSpecialTableChairsFemale), e.Id,3);
                await itabledl.PostDL(t);
            }

        }
        public async Task PutBL(int id,Event e)
        {
            await ieventdl.PutDL(id,e);
        }

        public async Task DeleteBL(int id)
        {
            await ieventdl.DeleteDL(id);
        }


    }

   
}

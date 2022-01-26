using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;
using Microsoft.EntityFrameworkCore.Metadata;
//using ourProject.Models;

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
                Table t = new Table
                {Id=0, IsSpecial=false, NumChair=(int)(e.NumChairsMale), EventId=e.Id, GenderId=1};

                await itabledl.PostDL(t);
            }
            for (int i = 0; i < e.NumTablesFemale; i++)
            {
                Table t = new Table
                { Id=0, IsSpecial=false, NumChair=(int)(e.NumChairsFemale), EventId=e.Id, GenderId=3 };
                await itabledl.PostDL(t);
            }

            if (e.NumSpecialTableChairsMale>0)
            { 
                Table t = new Table
                { Id=0, IsSpecial=true, NumChair=(int)(e.NumSpecialTableChairsMale), EventIde.Id, GenderId=1 };
                await itabledl.PostDL(t);
            }
             if (e.NumSpecialTableChairsFemale>0)
            {
                Table t = new Table
                {Id=0, IsSpecial=true, NumChair=(int)(e.NumSpecialTableChairsFemale), EventId=e.Id, GenderId=3 };
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

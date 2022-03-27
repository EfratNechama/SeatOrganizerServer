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
        IEventPerUserDL ieventperuserdl;

        public EventBL(IEventDL ieventdl, ITableDL itabledl, IEventPerUserDL ieventperuserdl)
        {
            this.ieventdl = ieventdl;
            this.itabledl = itabledl;
            this.ieventperuserdl = ieventperuserdl;
        }
        public async Task<List<Event>> getEventByUserIdBL(int id)
        {
           
            return await ieventdl.getEventByUserIdDL(id);
        }
        public async Task<Event> getEventByEventIdBL(int id)
        {
            return await ieventdl.getEventByEventIdDL(id);
        }
        public async Task<int> PostBL(Event e, int userId)
        {
            int id=await ieventdl.PostDL(e);
            List<Table> tblArr = new List<Table>();
            //Table[] tblArr = new Table[(int)(e.NumtablesMale+e.NumTablesFemale+2)];
            //int ind = 0;
            //post table by the event details 
            for (int i = 0; i < e.NumTablesMale; i++)
            {
                Table t = new Table
                {Id=0, IsSpecial=false, NumChair=(int)(e.NumChairsMale), EventId=e.Id, GenderId=1};
                tblArr.Add(t);
               // await itabledl.PostDL(t);
            }
            for (int i = 0; i < e.NumTablesFemale; i++)
            {
                Table t = new Table
                { Id=0, IsSpecial=false, NumChair=(int)(e.NumChairsFemale), EventId=e.Id, GenderId=3 };
                tblArr.Add(t);
            }

            if (e.NumSpecialTableChairsMale>0)
            { 
                Table t = new Table
                { Id=0, IsSpecial=true, NumChair=(int)(e.NumSpecialTableChairsMale), EventId=e.Id, GenderId=1 };
                tblArr.Add(t);
            }
             if (e.NumSpecialTableChairsFemale>0)
            {
                Table t = new Table
                {Id=0, IsSpecial=true, NumChair=(int)(e.NumSpecialTableChairsFemale), EventId=e.Id, GenderId=3 };
                tblArr.Add(t);
            }
            await itabledl.PostDL(tblArr);
            EventPerUser epu = new EventPerUser
            {
                Id = 0,
                EventId = e.Id,
                UserId = userId
            };
            await ieventperuserdl.PostDL(epu);
            return id;
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

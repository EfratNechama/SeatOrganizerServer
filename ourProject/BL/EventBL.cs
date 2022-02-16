﻿using System;
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
        public async Task<List<EventPerUser>> getEventByUserIdBL(int id)
        {
           
            return await ieventdl.getEventByUserIdDL(id);
        }
        public async Task<Event> getEventByEventIdBL(int id)
        {
            return await ieventdl.getEventByEventIdDL(id);
        }
        public async Task PostBL(Event e, int userId)
        {
            await ieventdl.PostDL(e);

            Table[] tblArr = new Table[e.NumTabelsMale+e.NumTablesFemale+2];
            int ind = 0;
            //post table by the event details 
            for (int i = 0; i < e.NumTabelsMale; i++)
            {
                Table t = new Table
                {Id=0, IsSpecial=false, NumChair=(int)(e.NumChairsMale), EventId=e.Id, GenderId=1};
                tblArr[ind++] = t;
               // await itabledl.PostDL(t);
            }
            for (int i = 0; i < e.NumTablesFemale; i++)
            {
                Table t = new Table
                { Id=0, IsSpecial=false, NumChair=(int)(e.NumChairsFemale), EventId=e.Id, GenderId=3 };
                tblArr[ind++] = t;
            }

            if (e.NumSpecialTableChairsMale>0)
            { 
                Table t = new Table
                { Id=0, IsSpecial=true, NumChair=(int)(e.NumSpecialTableChairsMale), EventId=e.Id, GenderId=1 };
                tblArr[ind++] = t;
            }
             if (e.NumSpecialTableChairsFemale>0)
            {
                Table t = new Table
                {Id=0, IsSpecial=true, NumChair=(int)(e.NumSpecialTableChairsFemale), EventId=e.Id, GenderId=3 };
                tblArr[ind++] = t;
            }
            await itabledl.PostDL(tblArr);
            EventPerUser epu = new EventPerUser
            {
                Id = 0,
                EventId = e.Id,
                UserId = userId
            };
            await ieventperuserdl.PostDL(epu);
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

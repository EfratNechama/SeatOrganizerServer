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
    public class TableDL : ITableDL
    {
        SeatOrganizerContext _myDB;
       
        public TableDL(SeatOrganizerContext SeatOrganizerContext)
        {
            _myDB = SeatOrganizerContext;
            
        }
        public async Task PostDL(Table t)
        {   if(t!=null)
            { 
            
            await _myDB.Tables.AddAsync(t); 
            await _myDB.SaveChangesAsync();
            }
        }

        //placement
        public async Task<List<Table>> GetTabelByEventIdDL(int eventId, int gender, bool special)
            {
            List<Table> listTabel = new List<Table>();            
            if (gender==1 && special==true)
            {
               return listTabel = await _myDB.Tables.Where(t => t.EventId.Equals(eventId)&& t.GenderId==1 && t.IsSpecial==true).ToListAsync();
            }
            if (gender == 1 )
            {
               return listTabel = await _myDB.Tables.Where(t => t.EventId.Equals(eventId) && t.GenderId == 1 && t.IsSpecial == false).ToListAsync();
            }
            if (gender == 3 && special == true)
            {
                return listTabel = await _myDB.Tables.Where(t => t.EventId.Equals(eventId) && t.GenderId == 3 && t.IsSpecial == true).ToListAsync();
            }
            if (gender == 3)
            {
              return  listTabel = await _myDB.Tables.Where(t => t.EventId.Equals(eventId) && t.GenderId == 3 && t.IsSpecial == false).ToListAsync();
            }
            if (gender == 2 && special == true)
            {
                return listTabel = await _myDB.Tables.Where(t => t.EventId.Equals(eventId) && t.GenderId == 2 && t.IsSpecial == true).ToListAsync();
            }
            if (gender == 2)
            {
                return listTabel = await _myDB.Tables.Where(t => t.EventId.Equals(eventId) && t.GenderId == 2 && t.IsSpecial == false).ToListAsync();
            }




        }

        public async Task DeleteTabelByEventIdDL(int eventId)
        {
            List<Table> tabelList = await _myDB.Tables.Where(t=>t.EventId==eventId).ToListAsync();
            _myDB.Tables.RemoveRange(tabelList);
            await _myDB.SaveChangesAsync();
            
        }


    }
}

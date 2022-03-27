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
        public async Task PostDL(List<Table> t)
        {   if(t!=null)
            {

            await _myDB.Tables.AddRangeAsync(t); 
            await _myDB.SaveChangesAsync();
            }
        }

        //placement
        public async Task<List<Table>> GetTableByEventIdDL(int eventId, int gender, bool special)
            {
            List<Table> listTable = new List<Table>();            
            if (gender==1 && special==true)
            {
               return listTable = await _myDB.Tables.Where(t => t.EventId.Equals(eventId)&& t.GenderId==1 && t.IsSpecial==true).ToListAsync();
            }
            if (gender == 1 )
            {
               return listTable = await _myDB.Tables.Where(t => t.EventId.Equals(eventId) && t.GenderId == 1 && t.IsSpecial == false).ToListAsync();
            }
            if (gender == 3 && special == true)
            {
                return listTable = await _myDB.Tables.Where(t => t.EventId.Equals(eventId) && t.GenderId == 3 && t.IsSpecial == true).ToListAsync();
            }
            if (gender == 3)
            {
              return  listTable = await _myDB.Tables.Where(t => t.EventId.Equals(eventId) && t.GenderId == 3 && t.IsSpecial == false).ToListAsync();
            }
            if (gender == 2 && special == true)
            {
                return listTable = await _myDB.Tables.Where(t => t.EventId.Equals(eventId) && t.GenderId == 2 && t.IsSpecial == true).ToListAsync();
            }
            if (gender == 2)
            {
                return listTable = await _myDB.Tables.Where(t => t.EventId.Equals(eventId) && t.GenderId == 2 && t.IsSpecial == false).ToListAsync();
            }

            return null;


        }

        public async Task DeleteTableByEventIdDL(int eventId)
        {
            List<Table> tableList = await _myDB.Tables.Where(t=>t.EventId==eventId).ToListAsync();
            _myDB.Tables.RemoveRange(tableList);
            await _myDB.SaveChangesAsync();


        }

        //delete with cascade EF


    }
}

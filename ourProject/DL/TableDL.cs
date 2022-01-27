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
        public async Task<List<Table>> GetTabelByEventIdDL(int eventId)
            {
            List<Table> listTabel= await _myDB.Tables.Where(t => t.EventId.Equals(eventId) ).ToListAsync();

            return listTabel;

        }

        public async Task DeleteTabelByEventIdDL(int eventId)
        {
            List<Table> tabelList = await _myDB.Tables.Where(t=>t.EventId==eventId).ToListAsync();
            _myDB.Tables.RemoveRange(tabelList);
            await _myDB.SaveChangesAsync();
            
        }


    }
}

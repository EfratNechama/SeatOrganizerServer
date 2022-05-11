using Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public class CategoryDL: ICategoryDL
    {
        SeatOrganizerContext _myDB;
        public CategoryDL(SeatOrganizerContext SeatOrganizerContext)
        {
            _myDB = SeatOrganizerContext;
        }

        //placement
        //לאחר שינוי הקטגוריה בדיבי יש לשים לב להתאים את סוג הליסט וסוג הפרמטר לשליפה
        public async Task<List<Category>> GetCategoryForEventDL(int id)
        {
            List<Category> listCategory = await _myDB.Categories.Where(c => c.EventId == (id)).ToListAsync();

            return listCategory;
        }
        public async Task<List<Category>> GetCategoryByEventId(int eventId)
        {
            List<Category> listCategory = await _myDB.Categories.Where(c => c.EventId==(eventId)).ToListAsync();

            return listCategory;
        }

        public async Task<List<Category>> GetAllCategoryDL()
        {
            List<Category> c = await _myDB.Categories.Where(e=>e.EventId==null).ToListAsync();
            return c;
        }

        public async Task PostDL(Category[] c)
        {
            try
            {
                await _myDB.Categories.AddRangeAsync(c);
                await _myDB.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        
        }
    }
}

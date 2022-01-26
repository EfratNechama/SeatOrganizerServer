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
        public async Task<List<CategoryPerEvent>> GetCategoryByEventId(int eventId)
        {
            List<CategoryPerEvent> listCategory = await _myDB.CategoryPerEvents.Where(c => c.EventId.Equals(eventId)).ToListAsync();

            return listCategory;
        }

        public async Task<List<Category>> GetAllCategoryDL()
        {
            List<Category> c = await _myDB.Categories.ToListAsync();
            return c;
        }
    }
}

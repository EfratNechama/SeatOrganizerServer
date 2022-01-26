using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class CategoryBL:ICategoryBL
    {
        ICategoryDL icategorydl;
        public CategoryBL(ICategoryDL icategorydl)
        {
            this.icategorydl = icategorydl;
        }
 public async Task<List<Category>> GetAllCategoryBL()
        {
            return await icategorydl.GetAllCategoryDL();
        }
    }
}

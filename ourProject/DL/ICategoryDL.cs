using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICategoryDL
    {
        Task<List<Category>> GetCategoryForEventDL(int id);
        Task<List<Category>> GetCategoryByEventId(int eventId);
        Task<List<Category>> GetAllCategoryDL();
        Task PostDL(Category[] c);
    }
}
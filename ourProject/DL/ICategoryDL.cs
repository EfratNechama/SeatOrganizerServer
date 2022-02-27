using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICategoryDL
    {
        Task<List<CategoryPerEvent>> GetCategoryByEventId(int eventId);
        Task<List<Category>> GetAllCategoryDL();
        Task PostDL(Category[] c);
    }
}
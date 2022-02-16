using Entities;
//using ourProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ITableDL
    {
        Task PostDL(Table[] t);

        Task<List<Table>> GetTabelByEventIdDL(int eventId, int gender, bool special);
        Task DeleteTabelByEventIdDL(int eventId);
    }
}
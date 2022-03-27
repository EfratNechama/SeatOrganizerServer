using Entities;
//using ourProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ITableDL
    {
        Task PostDL(List<Table> t);

        Task<List<Table>> GetTableByEventIdDL(int eventId, int gender, bool special);
        Task DeleteTableByEventIdDL(int eventId);
    }
}
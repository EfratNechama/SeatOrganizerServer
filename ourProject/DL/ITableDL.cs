using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ITableDL
    {
        Task PostDL(Table t);

        Task<List<Table>> GetTabelByEventId(int eventId);
    }
}
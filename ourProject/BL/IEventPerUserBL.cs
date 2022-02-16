using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IEventPerUserBL
    {
        Task<List<Event>> GetEventListByUserIdBL(int userId);
    }
}
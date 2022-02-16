using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IEventPerUserDL
    {
        Task PostDL(EventPerUser epud);
        Task<List<Event>> GetEventListByUserIdDL(int userId);
    }
}
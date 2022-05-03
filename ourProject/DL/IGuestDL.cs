using Entities;
//using ourProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IGuestDL
    {
        Task<List<Guest>> GetDL(int id);
        Task<List<Guest>> GetByGenderDL(int id, int gender);
        Task PostDL(Guest g);
        Task PutDL(int id, Guest g);
        Task<Guest> GetGuestByGuestIdDL(int gId);
        Task DeleteDL(int id);
    }
}
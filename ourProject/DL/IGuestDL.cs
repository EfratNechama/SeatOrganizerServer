using Entities;
//using ourProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IGuestDL
    {
        Task<List<Guest>> GetDL(int id);
        Task<List<Guest>> GetDLOrderByFamilySize(int id,int gender);
        Task PostDL(Guest g);
        Task PutDL(int id, Guest g);

        Task DeleteDL(int id);
    }
}
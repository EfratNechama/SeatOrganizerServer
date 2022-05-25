using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BL
{
    public interface IPlacementBL
    {
        //  Task<List<Table>> getBl(int id);
          Task<List<GuestSeat>> getBl(int id);
        Task place(int eId);
    }
}
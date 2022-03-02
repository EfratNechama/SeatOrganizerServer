using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IGuestBL
    {
        //Task<System.Collections.Generic.List<Guest>> getGuestBL(int id);
        Task<List<Guest>> GetBL(int id);
        Task PostBL(Guest g);
        Task PutBL(int id, Guest g);
        Task DeleteBL(int id);
        Task sendEmailByEventIdBL(int eventId);
       
        Task sendEmailByGuestId(Guest g);



    }
}
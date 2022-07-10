using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IPlacementDL
    {
        Task postDL(Placement p);
        //Task<List<Table>> getDl(int eventId);
        Task<List<GuestSeat>> getDl(int eventId);
       Task deleteDL(int eId);
        Task<List<Placement>> getPlacementByGuestIdDl(int guestId);
    }
}
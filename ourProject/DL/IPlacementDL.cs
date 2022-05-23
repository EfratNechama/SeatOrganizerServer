using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IPlacementDL
    {
        Task postDL(Placement p);
        Task<List<Table>> getDl(int eventId);
    }
}
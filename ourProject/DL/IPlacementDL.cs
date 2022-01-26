using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IPlacementDL
    {
        Task postDL(Placement p);
    }
}
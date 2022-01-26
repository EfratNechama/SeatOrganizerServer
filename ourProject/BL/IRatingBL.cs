using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IRatingBL
    {
        Task postBL(Rating r);
    }
}
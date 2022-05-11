using Entities;
using System.Threading.Tasks;


namespace BL
{
    public interface IPlacementBL
    {
        Task place(int eId);
    }
}
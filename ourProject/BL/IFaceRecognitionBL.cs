using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IFaceRecognitionBL
    {
        int goToPythonBl(string queryStr);
        Task<RecognizedGuest> postBl(string querystr, int eventId);
    }
}
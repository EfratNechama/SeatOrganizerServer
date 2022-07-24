using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;

namespace BL
{
    public class FaceRecognitionBL: IFaceRecognitionBL
    {


        IFaceRecognitionDL ifacerecognitiondl;
        IGuestDL iguestdl;
        IPlacementDL iplacementdl;
        public FaceRecognitionBL(IFaceRecognitionDL ifacerecognitiondl, IGuestDL iguestdl, IPlacementDL iplacementdl)
        {
            this.ifacerecognitiondl = ifacerecognitiondl;
            this.iguestdl = iguestdl;
            this.iplacementdl = iplacementdl;
        }

        public int goToPythonBl(string queryStr)
        {
            return ifacerecognitiondl.goToPython(queryStr);
        }

        public async Task<RecognizedGuest> postBl(string querystr,int eventId)
        {
            int guestId = goToPythonBl(querystr);
            Guest g = await iguestdl.GetGuestByGuestIdDL(guestId);
            List<Placement> placementList = await iplacementdl.getPlacementByGuestIdDl(guestId);
            List<int> countList=new List<int>();
            List<int> tableIdList = new List<int>();
            for (int i = 0; i < placementList.Count();i++)
            {
                countList.Add((int)placementList[i].NumMembers);
                tableIdList.Add(placementList[i].TableId);
            }
            return new RecognizedGuest { GuestId = g.Id, GuestName = g.FirstName + " " + g.LastName, TableIdList = tableIdList, NumChairsList = countList };
            
        }
    }
}

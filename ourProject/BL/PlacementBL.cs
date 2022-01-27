using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;


namespace BL
{

   public class PlacementBL: IPlacementBL
    {
        IPlacementDL iplacementdl;
        IGuestDL iguestdl;
        ITableDL itabeldl;
      
        ICategoryDL icategorydl;
         

        public PlacementBL(IPlacementDL iplacementdl)
        {
            this.iplacementdl = iplacementdl;
        }
       
        
        
        struct match
        {
            public match(Table T, int CategoryId,int AvailableChairs)
            {
                t = T;
                categoryId = CategoryId;
                availableChairs= AvailableChairs;

            }
            public Table t { get; set; }
            public int categoryId { get; set; }
            public int availableChairs { set; get; }

            
        }



            //BS"D!!!!!
            //אלגוריתם שיבוץ בסיסי
            public async Task place(int eventId)
        
        {
            //לטפל בספיישל
            List<Guest> guestList = await iguestdl.GetDLOrderByFamilySize(eventId);

        List<Table> tabelList = await itabeldl.GetTabelByEventIdDL(eventId);

        List<CategoryPerEvent> categoryList = await icategorydl.GetCategoryByEventId(eventId);

        List<match> matchList = new List<match>();

        int i = 0;
            while(i<tabelList.Count && i<categoryList.Count)
            {
                //after update the db we must change this
                
                matchList.Add(new match(tabelList[i], (int) categoryList[i].CategoryId, (int) tabelList[i].NumChair));
                i++;
            }


    List<Table> availableTableList = new List<Table>();
            while(i<tabelList.Count)
            {
                availableTableList.Add(tabelList[i]);
            }


//יתכן ונותרו זנבות אך מקרים אלו יכללו בהמשך


for (int j = 0; j < guestList.Count; j++)
{
    for (int k = 0; k < matchList.Count; k++)
    {
        //בגרסה זאת מיינו את השולחנות הפנויים לפי כמות הכסאות הפנויים בסדר יורד
        List<match> filterCategoryList = matchList.OrderByDescending(m => m.availableChairs).Where(m => m.categoryId == guestList[j].CategoryId).ToList();
        if (filterCategoryList.Any())
        {
            //השתמשתי באי די בגלל שעוד לא היה פרמטר כמה אורחים באיםאיתי יש לגנרט בדחיפות
            if (filterCategoryList.First().availableChairs >= guestList[j].Id)
            {
                int tableId = filterCategoryList.First().t.Id;
                Placement p = new Placement
                {Id= 0, TableId=tableId, GuestId=guestList[j].Id };
                await iplacementdl.postDL(p);
                //חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                for (int a = 0; a < matchList.Count; a++)
                {
                    //if (matchList[a].t.Id == tableId)
                    //השתמשתי באי די בגלל שעוד לא היה פרמטר כמה אורחים באיםאיתי יש לגנרט בדחיפות

                    //פה נעצרנו
                    //בעיה בreadonly
                    //matchList[a].availableChairs= matchList[a].availableChairs - (int)guestList[j].Id;
                }

            }
            else
            {
                if (availableTableList.Any())
                {

                }
                else
                {

                }

            }


        }
        else
        {

        }

    }
}
        }


    }
}

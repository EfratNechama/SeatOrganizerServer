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
       
        
        
        private class match
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
            public async Task place(Event e)
        
        {
            //לטפל בספיישל
            //לדאוג להסרת השולחנות שהגיעו לתפוסה מלאה (0מקומות זמינים)

            //ארוע מופרד

            

            if (e.SeperatedSeats == true)
            {

            }
            //ארוע מעורב
            else            
            {
                List<Guest> guestList = await iguestdl.GetDLOrderByFamilySize(e.Id, 2);
                List<Table> tabelList = await itabeldl.GetTabelByEventIdDL(e.Id,2,false);
                List<CategoryPerEvent> categoryList = await icategorydl.GetCategoryByEventId(e.Id);
                List<match> matchList = new List<match>();
                int i = 0;
                //התאמת שולחנות לקטגוריות לצורך אתחול 
                while (i < tabelList.Count && i < categoryList.Count)
                {
                    //after update the db we must change this

                    matchList.Add(new match(tabelList[i], (int)categoryList[i].CategoryId, (int)tabelList[i].NumChair));
                    i++;
                }
                //רשימת שולחנות שאין להם קטגוריות
                List<Table> availableTableList = new List<Table>();
                while (i < tabelList.Count)
                {
                    availableTableList.Add(tabelList[i]);
                }
                ////יתכן ונותרו זנבות אך מקרים אלו יכללו בהמשך
                for (int j = 0; j < guestList.Count; j++)
                {
                    for (int k = 0; k < matchList.Count; k++)
                    {
                        //בגרסה זאת מיינו את השולחנות הפנויים לפי כמות הכסאות הפנויים בסדר יורד
                        List<match> filterCategoryList = matchList.OrderByDescending(m => m.availableChairs).Where(m => m.categoryId == guestList[j].CategoryId).ToList();
                        if (filterCategoryList.Any())
                        {
                            if (filterCategoryList.First().availableChairs >= guestList[j].NumFamilyMembersMale)
                            {
                                int tableId = filterCategoryList.First().t.Id;
                                // ללא שארית שיבוץ
                                Placement p = new Placement
                                { Id = 0, TableId = tableId, GuestId = guestList[j].Id };
                                await iplacementdl.postDL(p);
                                //חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                                for (int a = 0; a < matchList.Count; a++)
                                {
                                    if (matchList[a].t.Id == tableId)
                                        matchList[a].availableChairs = matchList[a].availableChairs - (int)guestList[j].NumFamilyMembersMale;
                                }
                                //end

                            }
                            else
                            {
                            //יש שולחנות ריקים
                            go_to_have_empty_tables:
                                if (availableTableList.Any())
                                {
                                    Table t1 = availableTableList[0];
                                    availableTableList.RemoveAt(0);
                                    matchList.Add(new match(t1, guestList[j].CategoryId, t1.NumChair));
                                    if (guestList[j].NumFamilyMembersMale <= t1.NumChair)
                                    {
                                        //שיבוץ
                                        Placement p = new Placement
                                        { Id = 0, TableId = t1.Id, GuestId = guestList[j].Id };
                                        await iplacementdl.postDL(p);
                                        //חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                                        for (int a = 0; a < matchList.Count; a++)
                                        {
                                            if (matchList[a].t.Id == t1.Id)
                                                matchList[a].availableChairs = matchList[a].availableChairs - (int)guestList[j].NumFamilyMembersMale;
                                        }
                                        //end

                                    }
                                    else
                                    {
                                        //שיבוץ עם שארית
                                        Placement p = new Placement
                                        { Id = 0, TableId = t1.Id, GuestId = guestList[j].Id };
                                        await iplacementdl.postDL(p);
                                        //חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                                        for (int a = 0; a < matchList.Count; a++)
                                        {
                                            if (matchList[a].t.Id == t1.Id)
                                                matchList[a].availableChairs = 0;
                                        }
                                        // לברר האם זה מעתיק כתובת או ערך
                                        Guest g1 = guestList[j];
                                        g1.NumFamilyMembersMale = guestList[j].NumFamilyMembersMale - t1.NumChair;
                                        // יש לברר האם הלולאה תתעדכן ותרוץ גם על האיבר הנוסף
                                        guestList.Add(g1);


                                    }

                                }
                                //אין שולחנות רייקים
                                else
                                {
                                    //האם יש בכלל מקום כלשהו פנוי בקטגוריה הרצויה
                                    if (filterCategoryList.First().availableChairs > 0)
                                    {
                                        int tableId = filterCategoryList.First().t.Id;
                                        Placement p = new Placement
                                        { Id = 0, TableId = tableId, GuestId = guestList[j].Id };
                                        await iplacementdl.postDL(p);
                                        // לברר האם זה מעתיק כתובת או ערך
                                        Guest g1 = guestList[j];
                                        g1.NumFamilyMembersMale = guestList[j].NumFamilyMembersMale - filterCategoryList.First().availableChairs;
                                        // יש לברר האם הלולאה תתעדכן ותרוץ גם על האיבר הנוסף
                                        guestList.Add(g1);
                                        //חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                                        for (int a = 0; a < matchList.Count; a++)
                                        {
                                            if (matchList[a].t.Id == tableId)
                                                matchList[a].availableChairs = 0;
                                        }

                                    }
                                    //אם אין בכלל מקום בשולחנות הקטגוריה וגם אין שולחן ריק לפתיחה מוכרחים לשבץ בשולחן השייך לקטגוריה אחרת 
                                    else
                                    {
                                        List<match> orderTableByAvailableChairsList = matchList.OrderByDescending(m => m.availableChairs).ToList();
                                        int tableId = orderTableByAvailableChairsList.First().t.Id;

                                        if (orderTableByAvailableChairsList.First().availableChairs >= guestList[j].NumFamilyMembersMale)
                                        {

                                            //שיבוץ
                                            Placement p = new Placement
                                            { Id = 0, TableId = tableId, GuestId = guestList[j].Id };
                                            await iplacementdl.postDL(p);
                                            //חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                                            for (int a = 0; a < matchList.Count; a++)
                                            {
                                                if (matchList[a].t.Id == tableId)
                                                    matchList[a].availableChairs = matchList[a].availableChairs - (int)guestList[j].NumFamilyMembersMale;
                                            }
                                            //end

                                        }
                                        else
                                        {
                                            //שיבוץ עם שארית
                                            Placement p = new Placement
                                            { Id = 0, TableId = tableId, GuestId = guestList[j].Id };
                                            await iplacementdl.postDL(p);
                                            // לברר האם זה מעתיק כתובת או ערך
                                            Guest g1 = guestList[j];
                                            g1.NumFamilyMembersMale = guestList[j].NumFamilyMembersMale - orderTableByAvailableChairsList.First().availableChairs;
                                            // יש לברר האם הלולאה תתעדכן ותרוץ גם על האיבר הנוסף
                                            guestList.Add(g1);
                                            //חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                                            for (int a = 0; a < matchList.Count; a++)
                                            {
                                                if (matchList[a].t.Id == tableId)
                                                    matchList[a].availableChairs = 0;
                                            }


                                        }
                                    }

                                }

                            }


                        }
                        else
                        {
                            goto go_to_have_empty_tables;
                        }
                    }
                }



            }
            //            List<Guest> guestListMale = await iguestdl.GetDLOrderByFamilySize(e.Id,1);
            //            List<Guest> guestListFemale = await iguestdl.GetDLOrderByFamilySize(e.Id, 3);
            //            List<Table> tabelList= await itabeldl.GetTabelByEventIdDL(e.Id);

            //              List<CategoryPerEvent> categoryList = await icategorydl.GetCategoryByEventId(e.Id);

            //             List<match> matchList = new List<match>(); &&&

            //        int i = 0;
            //            while(i<tabelList.Count && i<categoryList.Count)
            //            {
            //                //after update the db we must change this

            //                matchList.Add(new match(tabelList[i], (int) categoryList[i].CategoryId, (int) tabelList[i].NumChair));
            //                i++;
            //            }


            //    List<Table> availableTableList = new List<Table>();
            //            while(i<tabelList.Count)
            //            {
            //                availableTableList.Add(tabelList[i]);
            //            }




            //for (int j = 0; j < guestList.Count; j++)
            //{
            //    for (int k = 0; k < matchList.Count; k++)
            //    {
            //        //בגרסה זאת מיינו את השולחנות הפנויים לפי כמות הכסאות הפנויים בסדר יורד
            //        List<match> filterCategoryList = matchList.OrderByDescending(m => m.availableChairs).Where(m => m.categoryId == guestList[j].CategoryId).ToList();
            //        if (filterCategoryList.Any())
            //        {
            //            //השתמשתי באי די בגלל שעוד לא היה פרמטר כמה אורחים באיםאיתי יש לגנרט בדחיפות
            //            if (filterCategoryList.First().availableChairs >= guestList[j].Id)
            //            {
            //                int tableId = filterCategoryList.First().t.Id;
            //                Placement p = new Placement
            //                {Id= 0, TableId=tableId, GuestId=guestList[j].Id };
            //                await iplacementdl.postDL(p);
            //                //חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
            //                for (int a = 0; a < matchList.Count; a++)
            //                {
            //                    //if (matchList[a].t.Id == tableId)
            //                    //השתמשתי באי די בגלל שעוד לא היה פרמטר כמה אורחים באיםאיתי יש לגנרט בדחיפות

            //                    //פה נעצרנו
            //                    //בעיה בreadonly
            //                    //matchList[a].availableChairs= matchList[a].availableChairs - (int)guestList[j].Id;
            //                }

            //            }
            //            else
            //            {
            //                if (availableTableList.Any())
            //                {

            //                }
            //                else
            //                {

            //                }

            //            }


            //        }
            //        else
            //        {

            //        }

            //    }
            //}
        }


  }
}

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
       
        
        
        public class match
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
                List<Guest> allGuestsList = await iguestdl.GetByGenderDL(e.Id, 2);
                List<Guest> specialGuestList = allGuestsList.OrderByDescending(g => g.NumFamilyMembersMale).Where(g => g.Category.Name.Equals("special")).ToList();
                List<Guest> guestList = allGuestsList.OrderByDescending(g => g.NumFamilyMembersMale).Where(g => g.Category.Name!="special").ToList();
                List<Table> tabelList = await itabeldl.GetTabelByEventIdDL(e.Id,2,false);
                List<CategoryPerEvent> categoryList = await icategorydl.GetCategoryByEventId(e.Id);
                List<match> matchList = new List<match>();


                async Task finalPlace(match machedTable, Guest guest, bool leftOver)
                {
                    if (leftOver==true)
                    {
                        // לברר האם זה מעתיק כתובת או ערך
                        var g1 = guest;
                        g1.NumFamilyMembersMale = guest.NumFamilyMembersMale - machedTable.availableChairs;
                        guestList.Add(g1);
                        //חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                        //בעצם אפשר כבר למחוק אותו לא?
                        matchList.Find(u => u.t.Id == machedTable.t.Id).availableChairs =0;
                    }
                    else
                        //חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                        matchList.Find(u => u.t.Id == machedTable.t.Id).availableChairs -= (int)guest.NumFamilyMembersMale;
                    Placement p = new Placement
                    { Id = 0, TableId = machedTable.t.Id, GuestId = guest.Id };
                    await iplacementdl.postDL(p);
                   
                }


                //special
                List<Table> spicalTabelList = await itabeldl.GetTabelByEventIdDL(e.Id, 2, true);
                //לא נכון .COUNT כי צריך לספור את מספר חברי המשפחה (איך להגביל?) לתקן
                if (specialGuestList.Count <= spicalTabelList[0].NumChair)
                {

                }
                else
                    throw new Exception("too many spical pepole!");

                //התאמת שולחנות לקטגוריות לצורך אתחול 
                int i = 0;
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
                       //בגרסה זאת מיינו את השולחנות הפנויים לפי כמות הכסאות הפנויים בסדר יורד
                        List<match> filterCategoryList = matchList.OrderByDescending(m => m.availableChairs).Where(m => m.categoryId == guestList[j].CategoryId).ToList();
                       //האם יש בכלל שולחנות לקטגוריה וגם באחד מהם יש מספיק מקום לכל המשפחה
                        if (filterCategoryList.Any() && filterCategoryList.First().availableChairs >= guestList[j].NumFamilyMembersMale)
                        {
                        //// שיבוץ ללא שארית
                        //int tableId = filterCategoryList.First().t.Id;
                        //Placement p = new Placement
                        //{ Id = 0, TableId = tableId, GuestId = guestList[j].Id };
                        //await iplacementdl.postDL(p);
                        ////חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                        //filterCategoryList.First().availableChairs -= (int)guestList[j].NumFamilyMembersMale;
                        ////סוף שיבוץ
                        await finalPlace(matchList.Find(u => u.t.Id == filterCategoryList.First().t.Id), guestList[j], false);
                        break;
                        }
                        //אין מקום לכולם בקטגוריה ☹ בדיקה אם יש שוחנות פנויים להקצות לקטגוריה
                        else if (availableTableList.Any())
                        {
                            Table t1 = availableTableList[0];
                            availableTableList.RemoveAt(0);
                            matchList.Add(new match(t1, guestList[j].CategoryId, t1.NumChair));
                            //יש מספיק מקומות בשולחן החדש
                            if (guestList[j].NumFamilyMembersMale <= t1.NumChair)
                            {
                            //שיבוץ ללא שארית. כולם נכנסים בשולחן
                            //Placement p = new Placement
                            //{ Id = 0, TableId = t1.Id, GuestId = guestList[j].Id };
                            //await iplacementdl.postDL(p);
                            ////חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                            //matchList.Find(u => u.t.Id == t1.Id).availableChairs -= (int)guestList[j].NumFamilyMembersMale;
                            ////סוף שיבוץ
                            await finalPlace(matchList[-1], guestList[j], false);
                            }
                            //המשפחה מדי גדולה, ולא נכנסת אפילו לשולחן החדש הפנוי. נאלץ לפצל
                            else
                            {
                            ////שיבוץ עם שארית
                            //Placement p = new Placement
                            //{ Id = 0, TableId = t1.Id, GuestId = guestList[j].Id };
                            //await iplacementdl.postDL(p);
                            ////חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                            //matchList.Find(u => u.t.Id == t1.Id).availableChairs =0;
                            //// לברר האם זה מעתיק כתובת או ערך
                            ////ליצור אוביקט חדש ולהוסיף לרשימה*********************
                            //var g1 = guestList[j];

                            //g1.NumFamilyMembersMale = guestList[j].NumFamilyMembersMale - t1.NumChair;
                            //// יש לברר האם הלולאה תתעדכן ותרוץ גם על האיבר הנוסף
                            //guestList.Add(g1);
                            await finalPlace(matchList[-1], guestList[j], true);
                        }

                        }
                        //מה לעשות? אין שולחנות ריקים להקצות:( נאלץ לפצל את המשפחה
                        else
                        {
                            //האם יש בכלל מקומות כלשהם פנויים בקטגוריה הרצויה
                            if (filterCategoryList.First().availableChairs > 0)//אם בראשון אין ק"ו שאין בכל השאר
                            {
                            ////שיבוץ עם שארית. הרי ברור שאין מקום לכולם בשולחן זה
                            //int tableId = filterCategoryList.First().t.Id;
                            //Placement p = new Placement
                            //{ Id = 0, TableId = tableId, GuestId = guestList[j].Id };
                            //await iplacementdl.postDL(p);
                            //// לברר האם זה מעתיק כתובת או ערך
                            //Guest g1 = guestList[j];
                            //g1.NumFamilyMembersMale = guestList[j].NumFamilyMembersMale - filterCategoryList.First().availableChairs;
                            //// יש לברר האם הלולאה תתעדכן ותרוץ גם על האיבר הנוסף
                            //guestList.Add(g1);
                            ////חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                            ////בעצם אפשר כבר למחוק אותו לא?
                            //matchList.Find(u => u.t.Id == tableId).availableChairs = 0;
                            ////סוף שיבוץ
                            await finalPlace(matchList.Find(u => u.t.Id == filterCategoryList.First().t.Id), guestList[j], true);
                        }
                        //אם אין בכלל מקום בשולחנות הקטגוריה וגם אין שולחן ריק לפתיחה מוכרחים לשבץ בשולחן השייך לקטגוריה אחרת 
                        else
                            {
                                List<match> orderTableByAvailableChairsList = matchList.OrderByDescending(m => m.availableChairs).ToList();
                                int tableId = orderTableByAvailableChairsList.First().t.Id;
                                //אם יש מקום לכולם בשולחן אחד (של קטגוריה זרה כמובן) אז שיבוץ
                                if (orderTableByAvailableChairsList.First().availableChairs >= guestList[j].NumFamilyMembersMale)
                                {
                                ////שיבוץ
                                //Placement p = new Placement
                                //{ Id = 0, TableId = tableId, GuestId = guestList[j].Id };
                                //await iplacementdl.postDL(p);
                                ////חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                                //matchList.Find(u => u.t.Id == tableId).availableChairs -= (int)guestList[j].NumFamilyMembersMale;
                                ////סוף שיבוץ
                                await finalPlace(matchList.Find(u => u.t.Id == orderTableByAvailableChairsList.First().t.Id), guestList[j], false);

                            }
                            else
                            {
                                //    //שיבוץ עם שארית
                                //    Placement p = new Placement
                                //    { Id = 0, TableId = tableId, GuestId = guestList[j].Id };
                                //    await iplacementdl.postDL(p);
                                //    // לברר האם זה מעתיק כתובת או ערך
                                //    Guest g1 = guestList[j];
                                //    g1.NumFamilyMembersMale = guestList[j].NumFamilyMembersMale - orderTableByAvailableChairsList.First().availableChairs;
                                //    // יש לברר האם הלולאה תתעדכן ותרוץ גם על האיבר הנוסף
                                //    guestList.Add(g1);
                                //    //חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                                //    matchList.Find(u => u.t.Id == tableId).availableChairs -= (int)guestList[j].NumFamilyMembersMale;
                                await finalPlace(matchList.Find(u => u.t.Id == orderTableByAvailableChairsList.First().t.Id), guestList[j], true);

                            }
                        }

                        }

                    


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


  


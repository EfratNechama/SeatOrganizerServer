//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DL;
//using Entities;


//namespace BL
//{

//    public class PlacementBL : IPlacementBL
//    {
//        IPlacementDL iplacementdl;
//        IGuestDL iguestdl;
//        ITableDL itabledl;
//        IEventDL ieventdl;
//        ICategoryDL icategorydl;


//        public PlacementBL(IPlacementDL iplacementdl, IEventDL ieventdl, IGuestDL iguestdl, ITableDL itabledl, ICategoryDL icategorydl)
//        {
//            this.iplacementdl = iplacementdl;
//            this.ieventdl = ieventdl;
//            this.iguestdl = iguestdl;
//            this.itabledl = itabledl;
//            this.icategorydl = icategorydl;
//        }



//        public class match
//        {
//            public match(Table T, int CategoryId, int AvailableChairs)
//            {
//                t = T;
//                categoryId = CategoryId;
//                availableChairs = AvailableChairs;

//            }
//            public Table t { get; set; }
//            public int categoryId { get; set; }
//            public int availableChairs { set; get; }


//        }


//        BS"D!!!!!
//            אלגוריתם שיבוץ בסיסי
//         public async Task place(int eId)
//        {
//            Event e = await this.ieventdl.getEventByEventIdDL(eId);
//            לטפל בספיישל
//             לדאוג להסרת השולחנות שהגיעו לתפוסה מלאה(0מקומות זמינים)

//            ארוע מופרד
//             if (e.SeparatedSeats == true)
//            {

//            }
//            ארוע מעורב
//            else
//            {
//                List<Guest> allGuestsList = await iguestdl.GetByGenderDL(e.Id, 2);
//                List<Guest> specialGuestList = allGuestsList.OrderByDescending(g => g.NumFamilyMembersMale).Where(g => g.CategoryId.Equals(168)).ToList();
//                List<Guest> guestList = allGuestsList.OrderByDescending(g => g.NumFamilyMembersMale).Where(g => g.CategoryId != 168).ToList();
//                List<Table> tableList = await itabledl.GetTableByEventIdDL(e.Id, 1, false);
//                List<Category> categoryList = await icategorydl.GetCategoryByEventId(e.Id);
//                List<match> matchList = new List<match>();


//                async Task finalPlace(match machedTable, Guest guest, bool leftOver)
//                {
//                    if (leftOver == true)
//                    {
//                        לברר האם זה מעתיק כתובת או ערך

//                       Guest g1 = new Guest
//                       {
//                           Id = guest.Id,
//                           EventId = guest.EventId,
//                           FirstName = guest.FirstName,
//                           LastName = guest.LastName,
//                           Phone = guest.Phone,
//                           Email = guest.Email,
//                           Confirmed = guest.Confirmed,
//                           CategoryId = guest.CategoryId,
//                           UserId = guest.UserId,
//                           IdentifyName = guest.IdentifyName,
//                           IdentifyImage = guest.IdentifyImage,
//                           NumFamilyMembersMale = guest.NumFamilyMembersMale,
//                           NumFamilyMembersFemale = guest.NumFamilyMembersFemale
//                       };
//                        g1.NumFamilyMembersMale = guest.NumFamilyMembersMale - machedTable.availableChairs;
//                        guestList.Add(g1);
//                        חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
//                        בעצם אפשר כבר למחוק אותו לא?
//                        matchList.Find(u => u.t.Id == machedTable.t.Id).availableChairs = 0;
//                    }
//                    else
//                        חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
//                        matchList.Find(u => u.t.Id == machedTable.t.Id).availableChairs -= (int)guest.NumFamilyMembersMale;
//                    Placement p = new Placement
//                    { Id = 0, TableId = machedTable.t.Id, GuestId = guest.Id };
//                    await iplacementdl.postDL(p);

//                }


//                special
//                List<Table> spicalTableList = await itabledl.GetTableByEventIdDL(e.Id, 1, true);
//                לא נכון .COUNT כי צריך לספור את מספר חברי המשפחה(איך להגביל?) לתקן
//                if (specialGuestList.Count <= spicalTableList[0].NumChair)
//                {

//                }
//                else
//                    throw new Exception("too many spical pepole!");

//                התאמת שולחנות לקטגוריות לצורך אתחול
//                int i = 0;
//                while (i < tableList.Count && i < categoryList.Count)
//                {
//                    after update the db we must change this

//                    matchList.Add(new match(tableList[i], (int)categoryList[i].Id, (int)tableList[i].NumChair));
//                    i++;
//                }
//                רשימת שולחנות שאין להם קטגוריות
//                List<Table> availableTableList = new List<Table>();
//                while (i < tableList.Count)
//                {
//                    availableTableList.Add(tableList[i++]);

//                }
//                //יתכן ונותרו זנבות אך מקרים אלו יכללו בהמשך
//                for (int j = 0; j < guestList.Count; j++)
//                {
//                    בגרסה זאת מיינו את השולחנות הפנויים לפי כמות הכסאות הפנויים בסדר יורד
//                        List<match> filterCategoryList = matchList.OrderByDescending(m => m.availableChairs).Where(m => m.categoryId == guestList[j].CategoryId).ToList();
//                    האם יש בכלל שולחנות לקטגוריה וגם באחד מהם יש מספיק מקום לכל המשפחה
//                        if (filterCategoryList.Any() && filterCategoryList.First().availableChairs >= guestList[j].NumFamilyMembersMale)
//                    {

//                        await finalPlace(matchList.Find(u => u.t.Id == filterCategoryList.First().t.Id), guestList[j], false);
//                        break;
//                    }
//                    אין מקום לכולם בקטגוריה ☹ בדיקה אם יש שוחנות פנויים להקצות לקטגוריה
//                        else if (availableTableList.Any())
//                    {
//                        Table t1 = availableTableList[0];
//                        availableTableList.RemoveAt(0);
//                        matchList.Add(new match(t1, guestList[j].CategoryId, t1.NumChair));
//                        יש מספיק מקומות בשולחן החדש
//                            if (guestList[j].NumFamilyMembersMale <= t1.NumChair)
//                        {

//                            await finalPlace(matchList.LastOrDefault(), guestList[j], false);
//                            break;

//                        }
//                        המשפחה מדי גדולה, ולא נכנסת אפילו לשולחן החדש הפנוי. נאלץ לפצל
//                        else
//                        {

//                            await finalPlace(matchList.LastOrDefault(), guestList[j], true);
//                            break;

//                        }

//                    }
//                    מה לעשות? אין שולחנות ריקים להקצות:(נאלץ לפצל את המשפחה
//                        else
//                    {
//                        האם יש בכלל מקומות כלשהם פנויים בקטגוריה הרצויה
//                            if (filterCategoryList.First().availableChairs > 0)//אם בראשון אין ק"ו שאין בכל השאר
//                        {
//                            //שיבוץ עם שארית. הרי ברור שאין מקום לכולם בשולחן זה

//                            await finalPlace(matchList.Find(u => u.t.Id == filterCategoryList.First().t.Id), guestList[j], true);
//                            break;

//                        }
//                        אם אין בכלל מקום בשולחנות הקטגוריה וגם אין שולחן ריק לפתיחה מוכרחים לשבץ בשולחן השייך לקטגוריה אחרת
//                        else
//                        {
//                            List<match> orderTableByAvailableChairsList = matchList.OrderByDescending(m => m.availableChairs).ToList();
//                            int tableId = orderTableByAvailableChairsList.First().t.Id;
//                            אם יש מקום לכולם בשולחן אחד(של קטגוריה זרה כמובן) אז שיבוץ
//                                if (orderTableByAvailableChairsList.First().availableChairs >= guestList[j].NumFamilyMembersMale)
//                            {

//                                await finalPlace(matchList.Find(u => u.t.Id == orderTableByAvailableChairsList.First().t.Id), guestList[j], false);
//                                break;


//                            }
//                            else
//                            {

//                                await finalPlace(matchList.Find(u => u.t.Id == orderTableByAvailableChairsList.First().t.Id), guestList[j], true);
//                                break;


//                            }
//                        }

//                    }




//                }

//            }
//        }



//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;


namespace BL
{

    public class PlacementBL : IPlacementBL
    {
        IPlacementDL iplacementdl;
        IGuestDL iguestdl;
        ITableDL itabledl;
        IEventDL ieventdl;
        ICategoryDL icategorydl;


        public PlacementBL(IPlacementDL iplacementdl, IEventDL ieventdl, IGuestDL iguestdl, ITableDL itabledl, ICategoryDL icategorydl)
        {
            this.iplacementdl = iplacementdl;
            this.ieventdl = ieventdl;
            this.iguestdl = iguestdl;
            this.itabledl = itabledl;
            this.icategorydl = icategorydl;
        }

        public async Task<List<GuestSeat>> getBl(int id)
        {
            return await iplacementdl.getDl(id);
        }

        public class match
        {
            public match(Table T, int CategoryId, int AvailableChairs)
            {
                t = T;
                categoryIdList=new List<int>();
                categoryIdList.Add(CategoryId);
                availableChairs = AvailableChairs;

            }
            public Table t { get; set; }
            public List<int> categoryIdList { get; set; }
            public int availableChairs { set; get; }


        }


        //BS"D!!!!!
        //אלגוריתם שיבוץ בסיסי
        public async Task place(int eId)
        {
            Event e = await this.ieventdl.getEventByEventIdDL(eId);
            //למחוק את השיבוץ הקודם בישיביל שלא יהיה כפול
            await this.iplacementdl.deleteDL(eId);
            //לטפל בספיישל
            //לדאוג להסרת השולחנות שהגיעו לתפוסה מלאה (0מקומות זמינים)

            //ארוע מופרד
            if (e.SeparatedSeats == true)
            {

            }
            //ארוע מעורב
            else
            {
                List<Guest> allGuestsList = await iguestdl.GetByGenderDL(e.Id, 2);
                List<Guest> specialGuestList = allGuestsList.OrderByDescending(g => g.NumFamilyMembersMale).Where(g => g.CategoryId.Equals(168)).ToList();
                List<Guest> guestList = allGuestsList.OrderByDescending(g => g.NumFamilyMembersMale).Where(g => g.CategoryId != 168).ToList();
                List<Table> tableList = await itabledl.GetTableByEventIdDL(e.Id, 1, false);
                List<Category> categoryList = await icategorydl.GetCategoryByEventId(e.Id);
                List<match> matchList = new List<match>();


                async Task finalPlace(match machedTable, Guest guest, bool leftOver)
                {
                    if (leftOver == true)
                    {
                        // לברר האם זה מעתיק כתובת או ערך

                        Guest g1 = new Guest
                        {
                            Id = guest.Id,
                            EventId = guest.EventId,
                            FirstName = guest.FirstName,
                            LastName = guest.LastName,
                            Phone = guest.Phone,
                            Email = guest.Email,
                            Confirmed = guest.Confirmed,
                            CategoryId = guest.CategoryId,
                            UserId = guest.UserId,
                            IdentifyName = guest.IdentifyName,
                            IdentifyImage = guest.IdentifyImage,
                            //NumFamilyMembersMale = guest.NumFamilyMembersMale,
                            NumFamilyMembersMale = guest.NumFamilyMembersMale - machedTable.availableChairs,
                            NumFamilyMembersFemale = guest.NumFamilyMembersFemale
                        };
                        //g1.NumFamilyMembersMale = guest.NumFamilyMembersMale - machedTable.availableChairs;
                        guestList.Add(g1);
                        //חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                        //בעצם אפשר כבר למחוק אותו לא?
                        matchList.Find(u => u.t.Id == machedTable.t.Id).availableChairs = 0;

                        Placement p = new Placement
                        { Id = 0, TableId = machedTable.t.Id, GuestId = guest.Id, NumMembers = guest.NumFamilyMembersMale-g1.NumFamilyMembersMale };
                        await iplacementdl.postDL(p);

                    }
                    else
                    { 
                        //חיפוש השולחן ממנו צריך להפחית את מספר הכסאות
                        matchList.Find(u => u.t.Id == machedTable.t.Id).availableChairs -= (int)guest.NumFamilyMembersMale;
                        Placement p = new Placement
                        { Id = 0, TableId = machedTable.t.Id, GuestId = guest.Id, NumMembers=guest.NumFamilyMembersMale };
                        await iplacementdl.postDL(p);

                    }

                }


                //special
                List<Table> spicalTableList = await itabledl.GetTableByEventIdDL(e.Id, 1, true);
                //לא נכון .COUNT כי צריך לספור את מספר חברי המשפחה (איך להגביל?) לתקן
                if (specialGuestList.Count <= spicalTableList[0].NumChair)
                {
                    foreach(Guest g2 in specialGuestList)
                    {
                        Placement p = new Placement
                        { Id = 0, TableId = spicalTableList[0].Id, GuestId = g2.Id,NumMembers=1 };
                        await iplacementdl.postDL(p);
                    }
                }
                //else
                //    throw new Exception("too many special pepole!");

                //התאמת שולחנות לקטגוריות לצורך אתחול 
                int i = 0;
                while (i < tableList.Count && i < categoryList.Count)
                {
                    //after update the db we must change this

                    matchList.Add(new match(tableList[i], (int)categoryList[i].Id, (int)tableList[i].NumChair));
                    i++;
                }
                //רשימת שולחנות שאין להם קטגוריות
                List<Table> availableTableList = new List<Table>();
                while (i < tableList.Count)
                {
                    availableTableList.Add(tableList[i++]);

                }
                ////יתכן ונותרו זנבות אך מקרים אלו יכללו בהמשך
                for (int j = 0; j < guestList.Count; j++)
                {
                    //בגרסה זאת מיינו את השולחנות הפנויים לפי כמות הכסאות הפנויים בסדר יורד
                    List<match> filterCategoryList = matchList.OrderByDescending(m => m.availableChairs).Where(m => m.categoryIdList.IndexOf(guestList[j].CategoryId)!=-1).ToList();

                    //כדי שלקטגוריה המרכזית (אם קיימת) תיהיה עדיפות
                    //List<match> filterCategoryList = matchList.OrderByDescending(m => m.availableChairs).Where(m => m.categoryIdList.IndexOf(guestList[j].CategoryId) == 0).ToList();
                    //List<match> filterCategoryListSecond = matchList.OrderByDescending(m => m.availableChairs).Where(m => m.categoryIdList.IndexOf(guestList[j].CategoryId) > 0).ToList();
                    //filterCategoryList.Concat( filterCategoryListSecond);

                   // filterCategoryList = (List<match>)filterCategoryList.OrderBy(i => i.categoryIdList.IndexOf(guestList[j].CategoryId));

                    //האם יש בכלל שולחנות לקטגוריה וגם באחד מהם יש מספיק מקום לכל המשפחה
                    if (filterCategoryList.Any() && filterCategoryList.First().availableChairs >= guestList[j].NumFamilyMembersMale)
                    {

                        await finalPlace(matchList.Find(u => u.t.Id == filterCategoryList.First().t.Id), guestList[j], false);
                        //break;
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

                            await finalPlace(matchList.LastOrDefault(), guestList[j], false);
                            // break;

                        }
                        //המשפחה מדי גדולה, ולא נכנסת אפילו לשולחן החדש הפנוי. נאלץ לפצל
                        else
                        {

                            await finalPlace(matchList.LastOrDefault(), guestList[j], true);
                            //  break;

                        }

                    }
                    //מה לעשות? אין שולחנות ריקים להקצות:( נאלץ לפצל את המשפחה
                    else
                    {
                        //האם יש בכלל מקומות כלשהם פנויים בקטגוריה הרצויה
                        if (filterCategoryList.First().availableChairs > 0)//אם בראשון אין ק"ו שאין בכל השאר
                        {
                            ////שיבוץ עם שארית. הרי ברור שאין מקום לכולם בשולחן זה

                            await finalPlace(matchList.Find(u => u.t.Id == filterCategoryList.First().t.Id), guestList[j], true);
                            // break;

                        }
                        //אם אין בכלל מקום בשולחנות הקטגוריה וגם אין שולחן ריק לפתיחה מוכרחים לשבץ בשולחן השייך לקטגוריה אחרת 
                        else
                        {
                            List<match> orderTableByAvailableChairsList = matchList.OrderByDescending(m => m.availableChairs).ToList();
                            int tableId = orderTableByAvailableChairsList.First().t.Id;
                            matchList.Find(f => f.t.Id == tableId).categoryIdList.Add(guestList[j].CategoryId);
                            //אם יש מקום לכולם בשולחן אחד (של קטגוריה זרה כמובן) אז שיבוץ
                            if (orderTableByAvailableChairsList.First().availableChairs >= guestList[j].NumFamilyMembersMale)
                            {

                                await finalPlace(matchList.Find(u => u.t.Id == orderTableByAvailableChairsList.First().t.Id), guestList[j], false);
                                //break;


                            }
                            else
                            {

                                await finalPlace(matchList.Find(u => u.t.Id == orderTableByAvailableChairsList.First().t.Id), guestList[j], true);
                                //break;


                            }
                        }

                    }




                }

            }
        }



    }
}









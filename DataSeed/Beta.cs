//using Database;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.OleDb;

//namespace DataSeed
//{
//    static class Beta
//    {
//        static string sourceData = Utility.sourceRoot + "GigiSchool.xls";
//        static SchoolContext context = new SchoolContext();

//        public static void Seed()
//        {
//            getResourceCategories();
//            getCharacteristicNames();
//            getResources();
//            getCharacteristics();
//            getEvents();
//            Console.ReadKey();
//        }

//        static void getResourceCategories()
//        {
//            Console.Write("RESOURCE CATEGORIES: ");
//            DataTable rawData = Utility.OpenExcel(sourceData, "ResourceCategory");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                ResourceCategory category = new ResourceCategory()
//                {
//                    CategoryName = Utility.getString(row, 0)
//                };
//                N++;
//                context.ResourceCategories.Add(category);
//            }
//            context.SaveChanges();
//            Console.WriteLine(N);
//        }

//        static void getCharacteristicNames()
//        {
//            Console.Write("CATEGORY CHARACTERISTICS NAME: ");
//            DataTable rawData = Utility.OpenExcel(sourceData, "CharacteristicName");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                string catName = Utility.getString(row, 0);
//                ResourceCategory resource = context.ResourceCategories.FirstOrDefault(x => x.CategoryName == catName);

//                CharacteristicName characteristic = new CharacteristicName()
//                {
//                    ResourceCategory = resource,
//                    Name = Utility.getString(row, 1)
//                };
//                N++;
//                context.CharacteristicNames.Add(characteristic);
//            }
//            context.SaveChanges();
//            Console.WriteLine(N);
//        }

//        static void getResources()
//        {
//            Console.Write("RESOURCES: ");
//            DataTable rawData = Utility.OpenExcel(sourceData, "Resource");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                string catName = Utility.getString(row, 1);
//                ResourceCategory category = context.ResourceCategories.FirstOrDefault(x => x.CategoryName == catName);

//                Resource resource = new Resource()
//                {
//                    ResourceCategory = category,
//                    Name = Utility.getString(row, 0),
//                    Status = (ReservationStatus)Enum.Parse(typeof(ReservationStatus), Utility.getString(row, 2))
//                };
//                N++;
//                context.Resources.Add(resource);

//            }
//            context.SaveChanges();
//            Console.WriteLine(N);
//        }

//        static void getCharacteristics()
//        {
//            Console.Write("CHARACTERISTICS: ");
//            DataTable rawData = Utility.OpenExcel(sourceData, "Characteristic");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                string resName = Utility.getString(row, 2);
//                Resource resource = context.Resources.FirstOrDefault(x => x.Name == resName);

//                Characteristic characteristic = new Characteristic()
//                {
//                    Resource = resource,
//                    Name = Utility.getString(row, 0),
//                    Value = Utility.getString(row, 1)
//                };
//                N++;
//                context.CategoryCharacteristics.Add(characteristic);

//            }
//            context.SaveChanges();
//            Console.WriteLine(N);
//        }

//        static void getEvents()
//        {
//            Console.Write("RESERVATION EVENTS: ");
//            DataTable rawData = Utility.OpenExcel(sourceData, "Event");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                string resName = Utility.getString(row, 0);
//                Resource resource = context.Resources.FirstOrDefault(x => x.Name == resName);

//                string userName = Utility.getString(row, 1);
//                Person user = context.People.FirstOrDefault(x => x.FirstName == userName);


//                Event resEvent = new Event()
//                {
//                    User = user,
//                    Resource = resource,
//                    EventTitle = Utility.getString(row, 2),
//                    EventStart = Utility.getDate(row, 3),
//                    EventEnd = Utility.getDate(row, 4)
//                };
//                N++;
//                context.Events.Add(resEvent);
//            }
//            context.SaveChanges();
//            Console.WriteLine(N);
//        }
//    }
//}

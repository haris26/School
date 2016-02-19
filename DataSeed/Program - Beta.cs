
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
//    class Program
//    {
//        static string sourceData = @"C:\Projects\school\beta.xls";
//        static SchoolContext context = new SchoolContext();

//        static DataTable OpenExcel(string path, string sheet)
//        {
//            var cs = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0",
//                path);
//            OleDbConnection conn = new OleDbConnection(cs);
//            conn.Open();

//            OleDbCommand cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}$]", sheet), conn);
//            OleDbDataAdapter da = new OleDbDataAdapter();
//            da.SelectCommand = cmd;

//            System.Data.DataTable dt = new System.Data.DataTable();
//            da.Fill(dt);
//            conn.Close();

//            return dt;
//        }

//        static void Main(string[] args)
//        {
//            getResourceCategories();
//            getCharacteristicNames();
//            getResources();
//            getCharacteristics();
//            getEvents();
//        }

//        static void getResourceCategories()
//        {
//            Console.Write("RESOURCE CATEGORIES: ");
//            DataTable rawData = OpenExcel(sourceData, "ResourceCategory");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                ResourceCategory category = new ResourceCategory()
//                {
//                    CategoryName = getString(row, 0)
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
//            DataTable rawData = OpenExcel(sourceData, "CharacteristicName");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                string catName = getString(row, 0);
//                ResourceCategory resource = context.ResourceCategories.FirstOrDefault(x => x.CategoryName == catName);

//                CharacteristicName characteristic = new CharacteristicName()
//                {
//                    ResourceCategory = resource,
//                    Name = getString(row, 1)
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
//            DataTable rawData = OpenExcel(sourceData, "Resource");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                string catName = getString(row, 1);
//                ResourceCategory category = context.ResourceCategories.FirstOrDefault(x => x.CategoryName == catName);

//                Resource resource = new Resource()
//                {
//                    ResourceCategory = category,
//                    Name = getString(row, 0),
//                    Status = (ReservationStatus)Enum.Parse(typeof(ReservationStatus), getString(row, 2))
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
//            DataTable rawData = OpenExcel(sourceData, "Characteristic");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                string resName = getString(row, 2);
//                Resource resource = context.Resources.FirstOrDefault(x => x.Name == resName);

//                Characteristic characteristic = new Characteristic()
//                {
//                    Resource = resource,
//                    Name = getString(row, 0),
//                    Value = getString(row, 1)
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
//            DataTable rawData = OpenExcel(sourceData, "Event");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                string resName = getString(row, 0);
//                Resource resource = context.Resources.FirstOrDefault(x => x.Name == resName);

//                string userName = getString(row, 1);
//                Person user = context.People.FirstOrDefault(x => x.FirstName == userName);


//                Event resEvent = new Event()
//                {
//                    User = user,
//                    Resource = resource,
//                    EventTitle = getString(row, 2),
//                    EventStart = getDate(row, 3),
//                    EventEnd = getDate(row, 4)
//                };
//                N++;
//                context.Events.Add(resEvent);
//            }
//            context.SaveChanges();
//            Console.WriteLine(N);

//        }

//        static string getString(DataRow row, int index)
//        {
//            return row.ItemArray.GetValue(index).ToString();
//        }

//        static DateTime getDate(DataRow row, int index)
//        {
//            return Convert.ToDateTime(row.ItemArray.GetValue(index).ToString());
//        }
//    }
//}

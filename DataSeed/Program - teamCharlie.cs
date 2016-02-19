//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Database;
//using System.Data.OleDb;
//using System.Data;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataSeed
//{
//    class Program
//    {
//        static string sourceData = @"C:\Projects\school\Charlie.xls";
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
//            getAssetCategories();

//            getAssets();
//            getRequests();
//            getAssetCharNames();
//            getAssetChar();
//            getHistory();


//            Console.ReadKey();

//        }



//        static string getString(DataRow row, int index)
//        {
//            return row.ItemArray.GetValue(index).ToString();
//        }
//        static DateTime getDate(DataRow row, int index)
//        {
//            return Convert.ToDateTime(row.ItemArray.GetValue(index).ToString());
//        }

//        static void getAssetCategories()
//        {
//            Console.Write("AssetCATEGORIES: ");
//            DataTable rawData = OpenExcel(sourceData, "AssetCategory");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                AssetCategory category = new AssetCategory()
//                {
//                    CategoryName = row.ItemArray.GetValue(0).ToString()
//                };
//                N++;
//                context.AssetCategory.Add(category);
//            }
//            context.SaveChanges();
//            Console.WriteLine(N);
//        }



//        static void getAssets()
//        {
//            Console.Write("Assets: ");
//            DataTable rawData = OpenExcel(sourceData, "Asset");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                string catName = row.ItemArray.GetValue(7).ToString();
//                string userName = row.ItemArray.GetValue(8).ToString();

//                AssetCategory category = context.AssetCategory.FirstOrDefault(x => x.CategoryName == catName);

//                Person user = context.People.FirstOrDefault(c => c.FirstName == userName);
//                Asset asset = new Asset()
//                {
//                    AssetCategory = category,
//                    Type = (AssetType)Enum.Parse(typeof(AssetType), row.ItemArray.GetValue(0).ToString()),
//                    Name = row.ItemArray.GetValue(1).ToString(),
//                    SerialNumber = row.ItemArray.GetValue(2).ToString(),
//                    Description = row.ItemArray.GetValue(3).ToString(),
//                    Vendor = row.ItemArray.GetValue(4).ToString(),
//                    Price = Convert.ToDouble(row.ItemArray.GetValue(5).ToString()),
//                    Status = (AssetStatus)Enum.Parse(typeof(AssetStatus), row.ItemArray.GetValue(6).ToString()),
//                    User = user,
//                };
//                N++;
//                context.Assets.Add(asset);

//            }
//            context.SaveChanges();
//            Console.WriteLine(N);
//        }

//        static void getAssetCharNames()
//        {
//            Console.Write("AssetCharNames: ");
//            DataTable rawData = OpenExcel(sourceData, "AssetCharacteristicNames");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                string catName = row.ItemArray.GetValue(0).ToString();
//                AssetCategory asset = context.AssetCategory.FirstOrDefault(x => x.CategoryName == catName);

//                AssetCharacteristicNames names = new AssetCharacteristicNames()
//                {
//                    AssetCategory = asset,
//                    Name = row.ItemArray.GetValue(1).ToString()
//                };
//                N++;
//                context.AssetCharNames.Add(names);
//            }
//            context.SaveChanges();
//            Console.WriteLine(N);
//        }


//        static void getAssetChar()
//        {
//            Console.Write("AssetChars: ");
//            DataTable rawData = OpenExcel(sourceData, "AssetChar");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                string name = row.ItemArray.GetValue(2).ToString();

//                Asset asset = context.Assets.FirstOrDefault(c => c.Name == name);
//                AssetChar assetChar = new AssetChar()
//                {

//                    Name = row.ItemArray.GetValue(0).ToString(),
//                    Value = row.ItemArray.GetValue(1).ToString(),
//                    Asset = asset,


//                };
//                N++;
//                context.AssetCharacteristics.Add(assetChar);

//            }
//            context.SaveChanges();
//            Console.WriteLine(N);
//        }



//        static void getRequests()
//        {
//            Console.Write("Requests: ");
//            DataTable rawData = OpenExcel(sourceData, "Request");

//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                string assetid = row.ItemArray.GetValue(4).ToString();
//                string userName = row.ItemArray.GetValue(5).ToString();


//                Asset asset = context.Assets.FirstOrDefault(c => c.Name == assetid);

//                Person user = context.People.FirstOrDefault(c => c.FirstName == userName);

//                Request requests = new Request()
//                {

//                    requestType = (RequestType)Enum.Parse(typeof(RequestType), row.ItemArray.GetValue(0).ToString()),
//                    RequestMessage = row.ItemArray.GetValue(1).ToString(),
//                    RequestDate = getDate(row, 2),
//                    Status = (RequestStatus)Enum.Parse(typeof(RequestStatus), row.ItemArray.GetValue(3).ToString()),
//                    Asset = asset,
//                    User = user,

//                };
//                N++;
//                context.Requests.Add(requests);

//            }
//            context.SaveChanges();
//            Console.WriteLine(N);
//        }





        static void getHistory()
        {

            Console.Write("History: ");
            DataTable rawData = OpenExcel(sourceData, "HistoryR");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {


                string assetid = row.ItemArray.GetValue(4).ToString();
                string userName = row.ItemArray.GetValue(5).ToString();

                Asset asset = context.Assets.FirstOrDefault(c => c.Name == assetid);

                Person user = context.People.FirstOrDefault(c => c.FirstName == userName);
                DateTime RequestEnd = DateTime.Now;


                History histories = new History()
                {
                    EventEnd = RequestEnd,
                    EventBegin = getDate(row, 0), //uzima iz request tabele pocetak na mjestu 2
                    Description = row.ItemArray.GetValue(2).ToString(), //uzima request message iz reguesta
                    Status = (HistoryStatus)Enum.Parse(typeof(HistoryStatus), row.ItemArray.GetValue(3).ToString()),
                    Asset = asset,
                    Person = user,

                    //user id i asset id dodati - personId(row,4) i userId(row,5)
                
                };
                N++;
                context.Histories.Add(histories);


//            }
//            context.SaveChanges();
//            Console.WriteLine(N);
//        }

//    }

//}


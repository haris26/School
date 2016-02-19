<<<<<<< HEAD
﻿//using Database;
//using System;
//using System.Data;
//using System.Data.OleDb;
//using System.Linq;

//namespace DataSeed
//{
//    class Seed
//    {
//        static string sourceData = @"C:\Projects\school\delta1.xls";
//        static SchoolContext context = new SchoolContext();

//        static void Main(string[] args)
//        {

//            getDays();
//        }



//        static void getDays()
//        {
//            Console.Write("DAYS: ");
//            DataTable rawData = OpenExcel(sourceData, "Day");
//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                Day day = new Day()
//                {
//                    Date = getDate(row,0),
//                    WorkTime = getDouble(row,1),
//                    PtoTime = getDouble(row, 2),
//                    EntryStatus = (EntryStatus)getInteger(row,3)
//                };
//                /*int status = Convert.ToInt32(row.ItemArray.GetValue(3).ToString());
//                switch (status)
//                {
//                    case 2: { status.EntryStatus = EntryStatus.Locked; break; }
//                    default: { status.EntryStatus = EntryStatus.Unlocked; break; }
//                }*/

//                string pName = row.ItemArray.GetValue(4).ToString();
//                day.Person = context.People.Where(x => x.FirstName == pName).FirstOrDefault();

//               // DateTime date = getDate(row, 0);
//                //day.Details.Add(context.Details.Where(x => x.Day.Person.FirstName == pName && x.Day.Date == date).FirstOrDefault());

//                N++;
//                context.Days.Add(day);
//            }
//            context.SaveChanges();
//            Console.WriteLine(N);


//        }




//        static DataTable OpenExcel(string path, string sheet)
//        {
//            var cs = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", path);
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
//        static string getString(DataRow row, int index)
//        {
//            return row.ItemArray.GetValue(index).ToString();
//        }

//        static int getInteger(DataRow row, int index)
//        {
//            return Convert.ToInt32(row.ItemArray.GetValue(index).ToString());
//        }
//        static double getDouble(DataRow row, int index)
//        {
//            return Convert.ToDouble(row.ItemArray.GetValue(index).ToString());
//        }

//        static bool getBool(DataRow row, int index)
//        {
//            return (row.ItemArray.GetValue(index).ToString().ToLower() == "yes");
//        }

//        static DateTime getDate(DataRow row, int index)
//        {
//            return Convert.ToDateTime(row.ItemArray.GetValue(index).ToString());
//        }
//    }
//}
=======
﻿using Database;
using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace DataSeed
{
    class Seed
    {
        static string sourceData = @"C:\MistralProjects\delta.xls";
        static SchoolContext context = new SchoolContext();

        //static void Main(string[] args)
        //{
        //    getDetail();
        //}

        static void getDetail()
        {
            Console.WriteLine("DETAILS: ");
            DataTable rawData = OpenExcel(sourceData, "Details");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Detail detail = new Detail()
                {

                    WorkTime = Convert.ToDouble(row.ItemArray.GetValue(2).ToString()),
                    BillTime = Convert.ToDouble(row.ItemArray.GetValue(3).ToString()),
                    Description = row.ItemArray.GetValue(4).ToString(),

                };
                string pName = row.ItemArray.GetValue(0).ToString();
                Person person = context.People.Where(x => x.FirstName == pName).FirstOrDefault();

                DateTime dan = Convert.ToDateTime(row.ItemArray.GetValue(1).ToString());
                detail.Day = context.Days.Where(x => x.Date == dan && x.Person == person).FirstOrDefault();

                string teamName = row.ItemArray.GetValue(5).ToString();
                detail.Team = context.Teams.Where(x => x.Name == teamName).FirstOrDefault();


                N++;
                context.Details.Add(detail);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }


        static DataTable OpenExcel(string path, string sheet)
        {
            var cs = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", path);
            OleDbConnection conn = new OleDbConnection(cs);
            conn.Open();

            OleDbCommand cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}$]", sheet), conn);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
    }
}
>>>>>>> 663b6a6667bc5c45c3c0e54deb9f0d189899a577

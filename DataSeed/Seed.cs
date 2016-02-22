<<<<<<< HEAD
﻿//﻿using Database;
=======



﻿//using Database;
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
//using System;
//using System.Data;
//using System.Data.OleDb;
//using System.Linq;

//namespace DataSeed
//{
//    class Seed
//    {
//        static string sourceData = @"C:\MistralProjects\delta.xls";
//        static SchoolContext context = new SchoolContext();

//        //static void Main(string[] args)
//        //{
//        //    getDetail();
//        //}

//        static void getDetail()
//        {
//            Console.WriteLine("DETAILS: ");
//            DataTable rawData = OpenExcel(sourceData, "Details");
//            int N = 0;
//            foreach (DataRow row in rawData.Rows)
//            {
//                Detail detail = new Detail()
//                {

//                    WorkTime = Convert.ToDouble(row.ItemArray.GetValue(2).ToString()),
//                    BillTime = Convert.ToDouble(row.ItemArray.GetValue(3).ToString()),
//                    Description = row.ItemArray.GetValue(4).ToString(),

//                };
//                string pName = row.ItemArray.GetValue(0).ToString();
//                Person person = context.People.Where(x => x.FirstName == pName).FirstOrDefault();

//                DateTime dan = Convert.ToDateTime(row.ItemArray.GetValue(1).ToString());
//                detail.Day = context.Days.Where(x => x.Date == dan && x.Person == person).FirstOrDefault();

//                string teamName = row.ItemArray.GetValue(5).ToString();
//                detail.Team = context.Teams.Where(x => x.Name == teamName).FirstOrDefault();


//                N++;
//                context.Details.Add(detail);
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
//    }
<<<<<<< HEAD
//}
=======
//}

>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea

using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace DataSeed
{
    class ProgramDelta
    {

        static string sourceData = @"C:\Projects\school\delta.xls";
        static SchoolContext context = new SchoolContext();

        static void Main(string[] args)
        {
            getDetail();
            getDays();
        }


        static void getDetail()
        {
            Console.WriteLine("DETAILS: ");
            DataTable rawData = OpenExcel(sourceData, "Detail");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Detail detail = new Detail();


                detail.WorkTime = getDouble(row, 2); //Convert.ToDouble(row.ItemArray.GetValue(2).ToString());
                detail.BillTime = getDouble(row, 3); //Convert.ToDouble(row.ItemArray.GetValue(3).ToString());
                detail.Description = getString(row, 4); // row.ItemArray.GetValue(4).ToString();


                string pName = getString(row, 0); //row.ItemArray.GetValue(0).ToString();
                Person person = context.People.Where(x => x.FirstName == pName).FirstOrDefault();  //Migration exception

                DateTime dan = getDate(row, 1);  //Convert.ToDateTime(row.ItemArray.GetValue(1).ToString());
                detail.Day = context.Days.Where(x => x.Date == dan && x.Person.FirstName == pName).FirstOrDefault();

                string teamName = row.ItemArray.GetValue(5).ToString();
                detail.Team = context.Teams.Where(x => x.Name == teamName).FirstOrDefault();


                N++;
                context.Details.Add(detail);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }


        static void getDays()
        {
            Console.Write("DAYS: ");
            DataTable rawData = OpenExcel(sourceData, "Day");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Day day = new Day()
                {
                    Date = getDate(row, 0),
                    WorkTime = getDouble(row, 1),
                    PtoTime = getDouble(row, 2),
                    EntryStatus = (EntryStatus)getInteger(row, 3)
                };

                string pName = row.ItemArray.GetValue(4).ToString();
                day.Person = context.People.Where(x => x.FirstName == pName).FirstOrDefault();

                N++;
                context.Days.Add(day);
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

        static string getString(DataRow row, int index)
        {
            return row.ItemArray.GetValue(index).ToString();
        }

        static int getInteger(DataRow row, int index)
        {
            return Convert.ToInt32(row.ItemArray.GetValue(index).ToString());
        }

        static bool getBool(DataRow row, int index)
        {
            return (row.ItemArray.GetValue(index).ToString().ToLower() == "yes");
        }

        static DateTime getDate(DataRow row, int index)
        {
            return Convert.ToDateTime(row.ItemArray.GetValue(index).ToString());
        }

        static double getDouble(DataRow row, int index)
        {
            return Convert.ToDouble(row.ItemArray.GetValue(index).ToString());
        }
 
    }
}


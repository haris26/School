using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace DataSeed
{
    static class Delta
    {
        static string sourceData = Utility.sourceRoot + "delta.xls";
        static SchoolContext context = new SchoolContext();

        public static void Main()
        {
            getDays();      
            getDetails();   
            Console.ReadKey();
        }

        static void getDays()
        {
            Console.Write("DAYS: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "Day");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string perName = Utility.getString(row, 4);
                Person person = context.People.FirstOrDefault(x => x.FirstName == perName);
                Day day = new Day()
                {
                    Date = Utility.getDate(row, 0),
                    WorkTime = Utility.getDouble(row, 1),
                    PtoTime = Utility.getDouble(row, 2),
                    EntryStatus = (EntryStatus)Utility.getInteger(row, 3),
                    Person = person
                };
                N++;
                context.Days.Add(day);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getDetails()
        {
            Console.Write("DETAILS: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "Details");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string perName = Utility.getString(row, 0);
                DateTime date = Utility.getDate(row, 1);
                Day day = context.Days.FirstOrDefault(x => x.Person.FirstName == perName && x.Date == date);
                string teamName = Utility.getString(row, 5);
                Team team = context.Teams.FirstOrDefault(x => x.Name == teamName);
                Detail detail = new Detail()
                {
                    Day = day,
                    WorkTime = Utility.getDouble(row, 2),
                    BillTime = Utility.getDouble(row, 3),
                    Description = Utility.getString(row, 4),
                    Team = team
                };
                N++;
                context.Details.Add(detail);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }
    }
}

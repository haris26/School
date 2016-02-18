using Database;
using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace DataSeed
{
    class Seed
    {
        static string sourceData = @"C:\Projects\school\day.xls";
        static SchoolContext context = new SchoolContext();

        static void Main(string[] args)
        {
            //getRoles();
            //getTeams();
            //getPeople();
            //getEngagement();
            getDays();
        }

        static void getRoles()
        {
            Console.Write("ROLES: ");
            DataTable rawData = OpenExcel(sourceData, "Roles");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Role role = new Role()
                {
                    Name = row.ItemArray.GetValue(1).ToString(),
                };
                N++;
                context.Roles.Add(role);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getTeams()
        {
            Console.Write("TEAMS: ");
            DataTable rawData = OpenExcel(sourceData, "Teams");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Team team = new Team()
                {
                    Name = row.ItemArray.GetValue(1).ToString(),
                    Description = row.ItemArray.GetValue(2).ToString(),
                    Type = (ProjectType)Convert.ToInt32(row.ItemArray.GetValue(3).ToString())
                };
                int type = Convert.ToInt32(row.ItemArray.GetValue(3).ToString());
                switch (type)
                {
                    case 1: { team.Type = ProjectType.External; break; }
                    case 2: { team.Type = ProjectType.Internal; break; }
                    default: { team.Type = ProjectType.Absence; break; }
                }
                N++;
                context.Teams.Add(team);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getPeople()
        {
            Console.Write("PEOPLE: ");
            DataTable rawData = OpenExcel(sourceData, "People");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Person person = new Person()
                {
                    FirstName = row.ItemArray.GetValue(1).ToString(),
                    LastName = row.ItemArray.GetValue(2).ToString()
                };
                N++;
                context.People.Add(person);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getDays()
        {
            Console.Write("DAYS: ");
            DataTable rawData = OpenExcel(sourceData, "Days");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Day day = new Day()
                {
                    Date = Convert.ToDateTime(row.ItemArray.GetValue(0).ToString()),
                    WorkTime = Convert.ToDouble(row.ItemArray.GetValue(1).ToString()),
                    PtoTime = Convert.ToDouble(row.ItemArray.GetValue(2).ToString()),
                    EntryStatus = (EntryStatus)Convert.ToInt32(row.ItemArray.GetValue(3).ToString())
                };
                /*int status = Convert.ToInt32(row.ItemArray.GetValue(3).ToString());
                switch (status)
                {
                    case 2: { status.EntryStatus = EntryStatus.Locked; break; }
                    default: { status.EntryStatus = EntryStatus.Unlocked; break; }
                }*/

                string pName = row.ItemArray.GetValue(4).ToString();
                day.Person = context.People.Where(x => x.FirstName == pName).FirstOrDefault();

                N++;
                context.People.Add(day);
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

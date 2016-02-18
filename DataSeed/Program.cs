using Database;
using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace DataSeed
{
    class Program
    {
        static string sourceData = @"C:\Projects\school\omega.xls";
        static SchoolContext context = new SchoolContext();

        static void Main(string[] args)
        {
            getRoles();
            getTeams();
            getPeople();
            getEngagement();
            Console.ReadKey();
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
                    Name = getString(row, 0),
                    Description = getString(row, 1),
                    Type = (ProjectType)getInteger(row, 2)
                };
                N++;
                context.Teams.Add(team);
            }
            context.SaveChanges();
            Console.WriteLine(N);
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
                    Name = getString(row, 0),
                    Team = getBool(row, 1),
                    System = getBool(row, 2)
                };
                N++;
                context.Roles.Add(role);
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
                    FirstName = getString(row, 0),
                    LastName = getString(row, 1),
                    Email = getString(row, 2),
                    Category = (EmploymentType)getInteger(row, 3),
                    Gender = (Gender)getInteger(row, 4),
                    Image = getString(row, 5),
                    Phone = getString(row, 6),
                    Address = new Address(getString(row, 7), getString(row, 8), getString(row, 9)),
                    BirthDate = getDate(row, 10),
                    StartDate = getDate(row, 11),
                    Status = (EmploymentStatus)getInteger(row, 12)
                };
                N++;
                context.People.Add(person);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getEngagements()
        {
            Console.Write("ENGAGEMENTS: ");
            DataTable rawData = OpenExcel(sourceData, "Engagements");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string personName = getString(row, 2);
                Person person = context.People.Where(x => x.FirstName == personName).FirstOrDefault();
                string roleName = getString(row, 3);
                Role role = context.Roles.Where(x => x.Name == roleName).FirstOrDefault();
                string teamName = getString(row, 4);
                Team team = context.Teams.Where(x => x.Name == teamName).FirstOrDefault();
                Engagement eng = new Engagement()
                {
                    StartDate = getDate(row, 0),
                    Time = getInteger(row, 1),
                    Person = person,
                    Role = role,
                    Team = team
                };
                N++;
                context.Engagements.Add(eng);
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
    }
}

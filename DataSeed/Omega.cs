using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeed
{
    static class Omega
    {
        static string sourceData = @"D:\GigiProject\omega.xls";
        static SchoolContext context = new SchoolContext();

        public static void Seed()
        {
            Console.Clear();
            getTeams();
            getRoles();
            getPeople();
            getEngagements();
            Console.ReadKey();
        }

        static void getTeams()
        {
            Console.Write("TEAMS: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "Teams");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Team team = new Team()
                {
                    Name = Utility.getString(row, 0),
                    Description = Utility.getString(row, 1),
                    Type = (ProjectType)Utility.getInteger(row, 2)
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
            DataTable rawData = Utility.OpenExcel(sourceData, "Roles");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Role role = new Role()
                {
                    Name = Utility.getString(row, 0),
                    Team = Utility.getBool(row, 1),
                    System = Utility.getBool(row, 2)
                };
                N++;
                context.Roles.Add(role);
            }
        }

        static void getPeople()
        {
            Console.Write("PEOPLE: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "People");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Person person = new Person()
                {
                    FirstName = Utility.getString(row, 0),
                    LastName = Utility.getString(row, 1),
                    Email = Utility.getString(row, 2),
                    Category = (EmploymentType)Utility.getInteger(row, 3),
                    Gender = (Gender)Utility.getInteger(row, 4),
                    Image = Utility.getString(row, 5),
                    Phone = Utility.getString(row, 6),
                    Address = new Address(Utility.getString(row, 7), Utility.getString(row, 8), Utility.getString(row, 9)),
                    BirthDate = Utility.getDate(row, 10),
                    StartDate = Utility.getDate(row, 11),
                    Status = (EmploymentStatus)Utility.getInteger(row, 12)
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
            DataTable rawData = Utility.OpenExcel(sourceData, "Engagements");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string personName = Utility.getString(row, 2);
                Person person = context.People.Where(x => x.FirstName == personName).FirstOrDefault();
                string roleName = Utility.getString(row, 3);
                Role role = context.Roles.Where(x => x.Name == roleName).FirstOrDefault();
                string teamName = Utility.getString(row, 4);
                Team team = context.Teams.Where(x => x.Name == teamName).FirstOrDefault();
                Engagement eng = new Engagement()
                {
                    StartDate = Utility.getDate(row, 0),
                    Time = Utility.getInteger(row, 1),
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

    }
}


using System;
using Database;
using System.Data;
using System.Linq;
using System.Data.OleDb;

namespace DataSeed
{
    class Program
    {
        static string sourceData = @"C:\Projects\school\alfa.xls";
        static SchoolContext context = new SchoolContext();

        static void Main(string[] args)
        {
            getEmployeeSkills();
            getProjectSkills();
            getEmployeeEducation();
            Console.ReadKey();
        }

        static void getEmployeeSkills()
        {
            Console.Write("EMPLOYEESKILLS: ");
            DataTable rawData = OpenExcel(sourceData, "EmployeeSkill");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string toolName = getString(row, 2);
                Tool tool = context.Tools.Where(x => x.Name == toolName).FirstOrDefault();

                string employeeName = getString(row, 3);
                Person employee = context.People.Where(x => x.FirstName == employeeName).FirstOrDefault();

                EmployeeSkill empSkill = new EmployeeSkill()
                {
                    Level = (Level)getInteger(row, 0),
                    Experience = getInteger(row, 1),
                    Tool = tool,
                    Employee = employee
                };

                N++;
                context.EmployeeSkills.Add(empSkill);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getProjectSkills()
        {
            Console.Write("PROJECTSKILLS: ");
            DataTable rawData = OpenExcel(sourceData, "ProjectSkill");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string teamName = getString(row, 1);
                Team team = context.Teams.Where(x => x.Name == teamName).FirstOrDefault();

                string toolName = getString(row, 2);
                Tool tool = context.Tools.Where(x => x.Name == toolName).FirstOrDefault();

                ProjectSkill projectSkill = new ProjectSkill()
                {
                    Level = (Level)getInteger(row, 0),
                    Team = team,
                    Tool = tool
                };

                N++;
                context.ProjectSkills.Add(projectSkill);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getEmployeeEducation()
        {
            Console.Write("EMPLOYEEEDUCATIONS: ");
            DataTable rawData = OpenExcel(sourceData, "EmployeeEducation");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string empName = getString(row, 0);
                Person employee = context.People.Where(x => x.FirstName == empName).FirstOrDefault();

                string educationName = getString(row, 1);
                Education education = context.Educations.Where(x => x.Name == educationName).FirstOrDefault();

                EmployeeEducation empEducation = new EmployeeEducation()
                {
                    Employee = employee,
                    Education = education
                };

                N++;
                context.EmployeeEducations.Add(empEducation);
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
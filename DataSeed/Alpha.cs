using Database;
using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace DataSeed
{
    static class Alpha
    {
        static string sourceData = Utility.sourceRoot + "GigiSchool.xls";
        static SchoolContext context = new SchoolContext();

        public static void Seed()
        {
            getEducation();
            getSkillCategory();
            getTool();
            getEmployeeSkills();
            getProjectSkills();
            getEmployeeEducation();
            Console.ReadKey();
        }

        static void getEducation()
        {
            Console.Write("EDUCATION: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "Education");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Education education = new Education()
                {
                    Name = Utility.getString(row, 0),
                    Type = (EducationType)Utility.getInteger(row, 1)
                };
                N++;
                context.Educations.Add(education);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getEmployeeSkills()
        {
            Console.Write("EMPLOYEESKILLS: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "EmployeeSkill");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string toolName = Utility.getString(row, 2);
                Tool tool = context.Tools.Where(x => x.Name == toolName).FirstOrDefault();

                string employeeName = Utility.getString(row, 3);
                Person employee = context.People.Where(x => x.FirstName == employeeName).FirstOrDefault();

                int exp = Utility.getInteger(row, 1);

                EmployeeSkill empSkill = new EmployeeSkill()
                {
                    Level = (Level)Utility.getInteger(row, 0),
                    Experience = Utility.getInteger(row, 1),
                    Tool = tool,
                    Employee = employee
                };

                if (exp > 0)
                    empSkill.Experience = exp;

                N++;
                context.EmployeeSkills.Add(empSkill);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getSkillCategory()
        {
            Console.Write("SKILL CATEGORY: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "SkillCategory");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                SkillCategory skillcategory = new SkillCategory()
                {
                    Name = Utility.getString(row, 0),
                };
                N++;
                context.SkillCategories.Add(skillcategory);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getProjectSkills()
        {
            Console.Write("PROJECTSKILLS: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "ProjectSkill");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string teamName = Utility.getString(row, 2);
                Team team = context.Teams.Where(x => x.Name == teamName).FirstOrDefault();

                string toolName = Utility.getString(row, 1);
                Tool tool = context.Tools.Where(x => x.Name == toolName).FirstOrDefault();

                ProjectSkill projectSkill = new ProjectSkill()
                {
                    Level = (Level)Utility.getInteger(row, 0),
                    Team = team,
                    Tool = tool
                };

                N++;
                context.ProjectSkills.Add(projectSkill);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getTool()
        {
            Console.Write("TOOLS: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "Tool");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string categoryName = Utility.getString(row, 1);
                SkillCategory category = context.SkillCategories.Where(x => x.Name == categoryName).FirstOrDefault();

                Tool tool = new Tool()
                {
                    Name = Utility.getString(row, 0),
                    Category = category
                };
                N++;
                context.Tools.Add(tool);
            }

            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getEmployeeEducation()
        {
            Console.Write("EMPLOYEEEDUCATIONS: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "EmployeeEducation");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string empName = Utility.getString(row, 0);
                Person employee = context.People.Where(x => x.FirstName == empName).FirstOrDefault();

                string educationName = Utility.getString(row, 1);
                Education education = context.Educations.Where(x => x.Name == educationName).FirstOrDefault();

                EmployeeEducation empEducation = new EmployeeEducation()
                {
                    Employee = employee,
                    Education = education,
                    Reference = Utility.getString(row, 2)
                };

                N++;
                context.EmployeeEducations.Add(empEducation);

            }
            context.SaveChanges();
            Console.WriteLine(N);
        }
    }
}




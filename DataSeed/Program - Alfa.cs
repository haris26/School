using Database;
using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace DataSeed
{
    class AlfaSeed
    {
        static string sourceData = @"C:\Projects\school\alfa.xls";
        static SchoolContext context = new SchoolContext();

        static void Main(string[] args)
        {
            getEducation();
            getSkillCategory();
            getTool();
        }

        static void getEducation()
        {
            Console.Write("EDUCATION: ");
            DataTable rawData = OpenExcel(sourceData, "Education");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Education education = new Education()
                {
                    Name = getString(row, 0),
                    Type = (EducationType)getInteger(row, 1),
                    Reference = getString(row, 2)
                };
                N++;
                context.Educations.Add(education);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getSkillCategory()
        {
            Console.Write("SKILL CATEGORY: ");
            DataTable rawData = OpenExcel(sourceData, "SkillCategory");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                SkillCategory skillcategory = new SkillCategory()
                {
                    Name = getString(row, 0),
                };
                N++;
                context.SkillCategories.Add(skillcategory);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getTool()
        {
            Console.Write("TOOLS: ");
            DataTable rawData = OpenExcel(sourceData, "Tool");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string categoryName = getString(row, 0);
                SkillCategory category = context.SkillCategories.Where(x => x.Name == categoryName).FirstOrDefault();

                Tool tool = new Tool()
                {
                    Name = getString(row, 0),
                    Category = category
                };
                N++;
                context.Tools.Add(tool);
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

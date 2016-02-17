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
    class Program
    {

        static string sourceData = @"C:\MistralProjects\delta.xls";
        static SchoolContext context = new SchoolContext();

        static void Main (string[] args)
        {
            //SchoolContext context = new SchoolContext();
            //Person person = new Person()
            //{
            //    FirstName = "John",
            //    LastName = "Doe",
            //    Address = new Address("71000", "Sarajevo", "Milana Preloga 12/3"),
            //    Category = EmploymentType.Full,
            //    Gender = Gender.Male,
            //    BirthDate = new DateTime(1990, 9, 15),
            //    StartDate = new DateTime(2014, 4, 20),
            //    Status = EmploymentStatus.Active
            //};
        //    context.People.Add(person);
        //    Team team = new Team() { Name = "Intranet", Description = "Internal project for personal use", Type = ProjectType.Internal }; 
        //    context.Teams.Add(team);
        //    Team team1 = new Team() { Name = "Delta", Description = "Time Tracking project for internal use", Type = ProjectType.Internal };
        //    context.Teams.Add(team1);
            
            
        //    person.Teams.Add(team);
        //    person.Teams.Add(team1);
        //    team.Members.Add(person);

        //    try
        //    {
        //        context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.ReadKey();
        //    }
        getDetail();

        }


        static void getDetail()
        {
            Console.WriteLine("DETAILS: ");
            DataTable rawData = OpenExcel(sourceData, "Details");
            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Detail detail = new Detail();


                detail.WorkTime = Convert.ToDouble(row.ItemArray.GetValue(2).ToString());
                    detail.BillTime = Convert.ToDouble(row.ItemArray.GetValue(3).ToString());
                    detail.Description = row.ItemArray.GetValue(4).ToString();

                
                string pName = row.ItemArray.GetValue(0).ToString();
                Person person = context.People.Where(x => x.FirstName == pName).FirstOrDefault();  //Migration exception

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

    


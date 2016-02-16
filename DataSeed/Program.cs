using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeed
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolContext context = new SchoolContext();
            Person person = new Person()
            {
                FirstName = "John",
                LastName = "Doe",
                Address = new Address("71000", "Sarajevo", "Milana Preloga 12/3"),
                Category = Employment.Full,
                Gender = Gender.Male,
                Status = Status.Active
            };
            context.People.Add(person);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }
    }
}

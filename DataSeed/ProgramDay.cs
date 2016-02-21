using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeed
{
    class ProgramDay
    {
        static DayUnit dayUnit = new DayUnit();

        static void Main(string[] args)
        {
            string choice = "x";
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. List of days");
                Console.WriteLine("2. Read one day");
                Console.WriteLine("3. Insert one day");
                Console.WriteLine("9. End");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": { printAllDays(); break; }
                    case "2": { printOneDay(); break; }
                    case "3": { insertDay(); break; }
                }
            }
            while (choice != "9");
            //Engagement engagement = new Engagement()
            //{
            //    EndDate = DateTime.Now,
            //    StartDate = DateTime.Now,
            //    Time = 1,
            //    Person = new Person()
            //    {
            //        FirstName = "Elma",
            //        LastName = "Ramusovic",
            //        Gender = Gender.Female,
            //        Category = EmploymentType.Student,
            //        BirthDate = DateTime.Now,
            //        StartDate = DateTime.Now,
            //        Status = EmploymentStatus.Active,
            //        Address = new Address()
            //    },
            //    Team = new Team()
            //    {
            //        Name = "Gama",
            //        Type = ProjectType.External
            //    },
            //    Role = new Role()
            //    {
            //        Name = "Test",
            //        Team = false,
            //        System = false
            //    }
            //};
            //EngagementUnit repository = new EngagementUnit();
            //repository.Insert(engagement);

        }

        static void printAllDays()
        {
            var days = dayUnit.Get().ToList();
            foreach (var day in days)
            {
                Console.WriteLine(day.Id + ": " + day.Date);
            }
            Console.ReadKey();

        }
        static void printOneDay()
        {
            Console.WriteLine();
            Console.Write("Enter id");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);
                var day = dayUnit.Get(id);
                Console.WriteLine(day.Id + ": " + day.Date);
                Console.ReadKey();
            }
        }



        static void insertDay()
        {
            Day day = new Day();
            Console.WriteLine();
            Console.WriteLine("Date:");
            string date = Console.ReadLine();
            day.Date = Convert.ToDateTime(date);
            Console.Write("Work time:");
            day.WorkTime = Convert.ToDouble(Console.ReadLine());
            Console.Write("Pto time:");
            day.PtoTime = Convert.ToDouble(Console.ReadLine());
            Console.Write("Entry Status [1,2]: ");
            day.EntryStatus = (EntryStatus)Convert.ToInt32(Console.ReadLine());
            Console.Write("PersonId: ");
            int personId = Convert.ToInt32(Console.ReadLine());
            Repository<Person> personRepository = new Repository<Person>();
            day.Person = personRepository.Get(personId);
            personRepository.Disconect();
            Repository<Day> dayRepository = new Repository<Day>();
            dayRepository.Insert(day);
        }
    }
}

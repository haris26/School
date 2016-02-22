//using Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataSeed
//{
//    class ProgramDeltaCRUD
//    {

//        static void Main(string[] args)
//        {
//            Entry();
            
//        }

//        static void Entry()
//        {
//            string choice = "x";
//            do
//            {
//                Console.Clear();
//                Console.WriteLine("Choose an option:");
//                Console.WriteLine("1. Days");
//                Console.WriteLine("2. Details");

//                choice = Console.ReadLine();
//                switch (choice)
//                {
//                    case "1": { days(); break; }
//                    case "2": { details(); break; }
                    
//                }
//            }
//            while (choice != "9");
//        }

//        static void days() { 
//            string choice = "x";
//            do
//            {
//                Console.Clear();
//                Console.WriteLine("Choose an option:");
//                Console.WriteLine("1. List of days");
//                Console.WriteLine("2. Read one day");
//                Console.WriteLine("3. Insert one day");
//                Console.WriteLine("4. Delete one day");
//                Console.WriteLine("5. Update one day");
//                Console.WriteLine("6. Return to previous menu");
//                Console.WriteLine("9. End");
//                choice = Console.ReadLine();
//                switch (choice)
//                {
//                    case "1": { printAllDays(); break; }
//                    case "2": { printOneDay(); break; }
//                    case "3": { insertDay(); break; }
//                    case "4": { deleteDay(); break; }
//                    case "5": { updateDay(); break; }
//                    case "6": { Entry(); break; }
//                }
//            }
//            while (choice != "9");

//        }

//        static void printAllDays()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                DayUnit dayUnit = new DayUnit(context);
//                var days = dayUnit.Get().ToList();
//                foreach (var day in days)
//                {
//                    Console.WriteLine(day.Id + ": " + day.Date);
//                }
//                Console.ReadKey();
//            }

//        }
//        static void printOneDay()
//        {
//            Console.WriteLine();
//            Console.Write("Enter id: ");
//            string sid = Console.ReadLine();
//            if (sid != "")
//            {
//                using (SchoolContext context = new SchoolContext())
//                {
//                    DayUnit dayUnit = new DayUnit(context);
//                    int id = Convert.ToInt32(sid);
//                    var day = dayUnit.Get(id);
//                    Console.WriteLine(day.Id + ": " + day.Date);
//                    Console.ReadKey();
//                }
//            }
//        }



//        static void insertDay()
//        {
//            Day day = new Day();
//            Console.WriteLine();
//            Console.WriteLine("Date: (FORMAT dd/MM/yyyy)");
//            string date = Console.ReadLine();
//            day.Date = Convert.ToDateTime(date);
//            Console.Write("Work time:");
//            day.WorkTime = Convert.ToDouble(Console.ReadLine());
//            Console.Write("Pto time:");
//            day.PtoTime = Convert.ToDouble(Console.ReadLine());
//            Console.Write("Entry Status [1,2]: ");
//            day.EntryStatus = (EntryStatus)Convert.ToInt32(Console.ReadLine());
//            Console.Write("PersonId: ");
//            int personId = Convert.ToInt32(Console.ReadLine());
//            using (SchoolContext context = new SchoolContext())
//            {
//                DayUnit dayUnit = new DayUnit(context);
//                Repository<Person> personRepository = new Repository<Person>(context);
//                day.Person = personRepository.Get(personId);
//                dayUnit.Insert(day);
//            }
//        }

//        static void deleteDay()
//        {
//            Console.WriteLine();
//            Console.Write("Insert id of day you want to delete: ");
//            string sid = Console.ReadLine();
//            if (sid != "")
//            {
//                int id = Convert.ToInt32(sid);

//                using (SchoolContext context = new SchoolContext())
//                {
//                    DayUnit dayUnit = new DayUnit(context);
//                    dayUnit.Delete(id);
//                    Console.WriteLine("You have deleted the day with id: " + sid);
//                    Console.ReadKey();
//                }
//            }
//        }

//        static void updateDay()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                DayUnit dayUnit = new DayUnit(context);
//                Repository<Person> personRepository = new Repository<Person>(context);
//                Console.WriteLine();
//                Console.WriteLine("Day id: ");
//                string sid = Console.ReadLine();
//                if (sid != "") {
//                    int id = Convert.ToInt32(sid);
//                    Day day = dayUnit.Get(id);
//                    if (day != null) {
//                        Console.WriteLine("Date:");
//                        string date = Console.ReadLine();
//                        day.Date = Convert.ToDateTime(date);
//                        Console.Write("Work time:");
//                        day.WorkTime = Convert.ToDouble(Console.ReadLine());
//                        Console.Write("Pto time:");
//                        day.PtoTime = Convert.ToDouble(Console.ReadLine());
//                        Console.Write("Entry Status [1,2]: ");
//                        day.EntryStatus = (EntryStatus)Convert.ToInt32(Console.ReadLine());
//                        Console.Write("PersonId: ");
//                        int personId = Convert.ToInt32(Console.ReadLine());
//                        day.Person = personRepository.Get(personId);

//                        dayUnit.Update(day,id);
//                    }
//                }
//            }
//        }

//        static void details()
//        {
//            string choice = "x";
//            do
//            {
//                Console.Clear();
//                Console.WriteLine("Choose an option:");
//                Console.WriteLine("1. List of details");
//                Console.WriteLine("2. Read one detail");
//                Console.WriteLine("3. Insert one detail");
//                Console.WriteLine("4. Delete one detail");
//                Console.WriteLine("5. Update one detail");
//                Console.WriteLine("6. Return to previous menu");
//                Console.WriteLine("9. End");
//                choice = Console.ReadLine();
//                switch (choice)
//                {
//                     case "1": { printAllDetails(); break; }
//                    case "2": { printOneDetail(); break; }
//                    case "3": { insertDetail(); break; }
//                    case "4": { deleteDetail(); break; }
//                    case "5": { updateDetail(); break; }
//                    case "6": { Entry(); break; }
//                }
//            }
//            while (choice != "9");
//    }
//        static void printAllDetails()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//               DetailUnit detailUnit = new DetailUnit(context);
//                var details = detailUnit.Get().ToList();
//                foreach (var detail in details)
//                {
//                    Console.WriteLine(detail.Id + ": " + detail.Description);
//                }
//                Console.ReadKey();
//            }

//        }
//        static void printOneDetail()
//        {
//                Console.WriteLine();
//                Console.Write("Enter id: ");
//                string sid = Console.ReadLine();
//                if (sid != "")
//                {
//                    using (SchoolContext context = new SchoolContext())
//                    {
//                        DetailUnit detailUnit = new DetailUnit(context);
//                        int id = Convert.ToInt32(sid);
//                        var detail = detailUnit.Get(id);
//                        Console.WriteLine(detail.Id + ": " + detail.Description);
//                        Console.ReadKey();
//                    }
//                }
//            }
//        static void insertDetail()
//        {
//            Detail detail = new Detail();
//            Console.WriteLine();
//            Console.Write("Worktime:");
//            detail.WorkTime = Convert.ToDouble(Console.ReadLine());
//            Console.Write("Billtime:");
//            detail.BillTime = Convert.ToDouble(Console.ReadLine());
//            Console.Write("Description");
//            detail.Description = Console.ReadLine();
//            Console.Write("DayId: ");
//            int dayId = Convert.ToInt32(Console.ReadLine());
//            Console.Write("TeamId: ");
//            int teamId = Convert.ToInt32(Console.ReadLine());
//            using (SchoolContext context = new SchoolContext())
//            {
//                DetailUnit detailUnit = new DetailUnit(context);
//                Repository<Day> dayRepository = new Repository<Day>(context);
//                Repository<Team> teamRepository = new Repository<Team>(context);
//                detail.Day = dayRepository.Get(dayId);
//                detail.Team = teamRepository.Get(teamId);
//                detailUnit.Insert(detail);
//            }
//        }
//        static void deleteDetail()
//        {
//            Console.WriteLine();
//            Console.Write("Insert id of detail you want to delete: ");
//            string sid = Console.ReadLine();
//            if (sid != "")
//            {
//                int id = Convert.ToInt32(sid);

//                using (SchoolContext context = new SchoolContext())
//                {
//                    DetailUnit detailUnit = new DetailUnit(context);
//                    detailUnit.Delete(id);
//                    Console.WriteLine("You have deleted the detail with id: " + sid);
//                    Console.ReadKey();
//                }
//            }
//        }
//        static void updateDetail()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                DetailUnit detailUnit = new DetailUnit(context);
//                Repository<Day> dayRepository = new Repository<Day>(context);
//                Repository<Team> teamRepository = new Repository<Team>(context);
//                Console.WriteLine();
//                Console.WriteLine("Enter id of the detail you wish to update: ");
//                string sid = Console.ReadLine();
//                if (sid != "")
//                {
//                    int id = Convert.ToInt32(sid);
//                    Detail detail = detailUnit.Get(id);
//                    if (detail != null)
//                    {
//                        Console.WriteLine("Worktime:");
//                        detail.WorkTime = Convert.ToDouble(Console.ReadLine());
//                        Console.Write("Billtime:");
//                        detail.BillTime = Convert.ToDouble(Console.ReadLine());
//                        Console.Write("Description");
//                        detail.Description = Console.ReadLine();
//                        Console.Write("DayId: ");
//                        int dayId = Convert.ToInt32(Console.ReadLine());
//                        Console.Write("TeamId: ");
//                        int teamId = Convert.ToInt32(Console.ReadLine());
//                        detail.Day = dayRepository.Get(dayId);
//                        detail.Team = teamRepository.Get(teamId);
//                        detailUnit.Update(detail, id);
//                    }
//                }
//            }
//        }

//    }
//}

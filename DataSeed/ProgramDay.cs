//using Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataSeed
//{
//    class ProgramDay
//    {
//        static DayUnit dayUnit = new DayUnit();

//        static void Main(string[] args)
//        {
//            string choice = "x";
//            do
//            {
//                Console.WriteLine("Choose an option:");
//                Console.WriteLine("1. List of days");
//                Console.WriteLine("2. Read one day");
//                Console.WriteLine("3. Insert one day");
//                Console.WriteLine("9. End");
//                choice = Console.ReadLine();
//                switch (choice)
//                {
//                    case "1": { printAllDays(); break; }
//                    case "2": { printOneDay(); break; }
//                   // case "3": { insertDay(); break; }
//                }
//            }
//            while (choice != "9");
//        }

//        static void printAllDays()
//        {
//            var days = dayUnit.Get().ToList();
//            foreach (var day in days)
//            {
//                Console.WriteLine(day.Id + ": " + day.Date);
//            }
//            Console.ReadKey();

//        }
//        static void printOneDay()
//        {
//            Console.WriteLine();
//            Console.Write("Enter id");
//            string sid = Console.ReadLine();
//            if (sid != "")
//            {
//                int id = Convert.ToInt32(sid);
//                var day = dayUnit.Get(id);
//                Console.WriteLine(day.Id + ": " + day.Date);
//                Console.ReadKey();
//            }
//        }

        

//        //static void insertTeam()
//        //{
//        //    Console.WriteLine();
//        //    Console.Write("Naziv tima:");
//        //    string naziv = Console.ReadLine();
//        //    if (naziv != "")
//        //    {
//        //        Console.WriteLine("Tip [1, 2, 3]: ");
//        //        string tip = Console.ReadLine();

//        //        Team team = new Team()
//        //        {
//        //            Name = naziv,
//        //            Type = (ProjectType)Convert.ToInt32(tip)
//        //        };
//        //        teamUnit.Insert(team);

//        //    }
//        //}
//    }
//}

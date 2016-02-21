//using Database;
//using System;
//using System.Data;
//using System.Linq;
//using System.Data.OleDb;

//namespace DataSeed
//{
//    class Program
//    {
//        static Repository<Team> teamUnit = new Repository<Team>();

//        static void Main(string[] args)
//        {
//            string choice = "X";
//            do
//            {
//                Console.WriteLine("Odaberi opciju:");
//                Console.WriteLine("1. Ispis timova");
//                Console.WriteLine("2. Ispis jednog tima");
//                Console.WriteLine("3. Otvaranje novog tima");
//                Console.WriteLine("9. Kraj programa");
//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1": { printAllTeams(); break; }
//                    case "2": { printOneTeam(); break; }
//                    case "3": { insertTeam(); break; }
//                }
//            } while (choice != "9");
//        }

//        static void insertTeam()
//        {
//            Console.WriteLine();
//            Console.Write("Naziv tima: ");
//            string naziv = Console.ReadLine();
//            if (naziv != "")
//            {
//                Console.Write("Tip [1, 2, 3]: ");
//                string tip = Console.ReadLine();

//                Team team = new Team()
//                {
//                    Name = naziv,
//                    Type = (ProjectType)Convert.ToInt32(tip)
//                };
//                teamUnit.Insert(team);
//            }
//        }

//        static void printAllTeams()
//        {
//            var teams = teamUnit.Get().ToList();
//            foreach(var team in teams)
//            {
//                Console.WriteLine(team.Id + ": " + team.Name);
//            }
//            Console.ReadKey();
//        }

//        static void printOneTeam()
//        {
//            Console.WriteLine();
//            Console.Write("Upisi ident: ");
//            string sid = Console.ReadLine();
//            if (sid != "")
//            {
//                int id = Convert.ToInt32(sid);
//                var team = teamUnit.Get(id);
//                if (team != null)
//                {
//                    Console.WriteLine(team.Id + ": " + team.Name);
//                    Console.ReadKey();
//                }
//            }
//        }
//    }
// }
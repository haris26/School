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
<<<<<<< HEAD
//        static SchoolContext context = new SchoolContext();

//        static void Main(string[] args)
//        {
//            string choice = "x";
//            do {
                
//                Console.WriteLine("Odaberi opciju: ");
//                Console.WriteLine("1. Ispis timova");
//                Console.WriteLine("2. Ispis jednog tima");
//                Console.WriteLine("3. Otvaranje novog tima tima");
//                Console.WriteLine("4. Brisanje tima");
//                Console.WriteLine("5. Update tima");
//                Console.WriteLine("9. Kraj programa");
//                choice = Console.ReadLine();
=======

//        static void Main(string[] args)
//        {
//            string choice = "X";
//            do
//            {
//                Console.WriteLine("Choose one option ");
//                Console.WriteLine("1. Print all teams");
//                Console.WriteLine("2. Print one team");
//                Console.WriteLine("3. Add new team");
//                Console.WriteLine("4. Delete team");
//                Console.WriteLine("5. Update team");
//                Console.WriteLine("9. End");
//                Console.WriteLine("----------------------");
//                choice = Console.ReadLine();

>>>>>>> 86c4b94cfc5a2b181af8e29c8b25ee4d892fa519
//                switch (choice)
//                {
//                    case "1": { printAllTeams(); break; }
//                    case "2": { printOneTeam(); break; }
<<<<<<< HEAD
//                    case "3": { insertTeam(); break; }
//                    case "4": { deleteTeam(); break; }
//                    case "5": { updateTeam(); break; }
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
//            foreach (var team in teams)
//            {
//                Console.WriteLine(team.Id + ": " + team.Name);
//            }
//           // Console.ReadKey();
//        }

//        static void printOneTeam()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Upisi Id: ");
//            string sid = Console.ReadLine();
//            if(sid != "")
//            {
//                int id = Convert.ToInt32(sid);
//                var team = teamUnit.Get(id);
//                if (team != null)
//                {
//                    Console.WriteLine(team.Id + ":  " + team.Name);
//                   // Console.ReadKey();
//                }
//            }
//        }
//        static void deleteTeam()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Unesi Id za brisanje: ");
//            string sid = Console.ReadLine();
//            if (sid != "")
//            {
//                int id = Convert.ToInt32(sid);
//                teamUnit.Delete(id);  
//            }
//        }
//        static void updateTeam()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Unesi id: ");
//            string sid = Console.ReadLine();
=======
//                    case "3": { insertNewTeam(); break; }
//                    case "4": { deleteTeam(); break; }
//                    case "5": { updateTeam(); break; }

//                }
//            } while (choice != "9");
//        }

//        static void printAllTeams()
//        {
//            var teams = teamUnit.Get().ToList(); //pretvaramo u toList da bi zatvorili konekciju prema bazi
//            //EF ce ove podatke smjestiti negdje u memoriju i zatvoriti konekciju prema bazi
//            foreach (var team in teams)
//            {
//                Console.WriteLine(team.Id + " : " + team.Name + " : " + team.Type);
//            }
//            Console.WriteLine("----------------------");
//            Console.ReadKey();
//        }

//        static void printOneTeam()
//        {
//            Console.WriteLine();
//            Console.Write("Enter team id: ");
//            string sid = Console.ReadLine();

//            if (sid != "")
//            {
//                int id = Convert.ToInt32(sid);
//                var team = teamUnit.Get(id);
//                if (team != null)
//                {
//                    Console.WriteLine(team.Id + ": " + team.Name + " | " + team.Description);
//                    Console.WriteLine("----------------------");
//                    Console.ReadKey();
//                }
//            }
//        }

//        static void insertNewTeam()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Team name: ");
//            string name = Console.ReadLine();

//            if (name != "")
//            {
//                Console.WriteLine(" Team type [1 - absence, 2 - external, 3 - internal]: ");
//                string type = Console.ReadLine();
//                Console.WriteLine("Team description: ");
//                string desc = Console.ReadLine();
//                Team team = new Team()
//                {
//                    Name =  name,
//                    Type = (ProjectType) Convert.ToInt32(type),
//                    Description = desc
//                };
//                teamUnit.Insert(team);
//            }
//            Console.WriteLine("----------------------");
//        }

//        static void deleteTeam()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Team id: ");
//            string sid = Console.ReadLine();

//            if (sid != "")
//            {
//                int id = Convert.ToInt32(sid);
//                var team = teamUnit.Get(id);
//                if (team != null) teamUnit.Delete(team.Id);
//                Console.WriteLine("You deleted team: " + id);
//                Console.WriteLine("----------------------");
//                Console.ReadKey();
//            }
//        }

//        static void updateTeam()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Team id: ");
//            string sid = Console.ReadLine();

>>>>>>> 86c4b94cfc5a2b181af8e29c8b25ee4d892fa519
//            if (sid != "")
//            {
//                int id = Convert.ToInt32(sid);
//                var team = teamUnit.Get(id);
<<<<<<< HEAD
//                Console.WriteLine("Unesite novi naziv tima: ");
//                string newName = Console.ReadLine();
//                team.Name = newName;
//                teamUnit.Update(team, id);
//            }
           
//        }
//    }
//}

=======
//                if (team != null)
//                {
//                    Console.WriteLine("Edit team name: ");
//                    string name = Console.ReadLine();
//                    team.Name = name;
//                    Console.WriteLine("Edit team type [1 -absence, 2 - internal, 3 - external]: ");
//                    string type = Console.ReadLine();
//                    team.Type = (ProjectType)Convert.ToInt32(type);
//                    Console.WriteLine("Edit team description: ");
//                    string desc = Console.ReadLine();
//                    team.Description = desc;
//                    teamUnit.Update(team, team.Id);
//                }
//                Console.WriteLine("----------------------");
//                Console.ReadKey();
//            }
//        }


//    }

//}
 
>>>>>>> 86c4b94cfc5a2b181af8e29c8b25ee4d892fa519

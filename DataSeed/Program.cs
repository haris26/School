using Database;
using System;
using System.Data;
using System.Linq;
using System.Data.OleDb;

namespace DataSeed
{
    class Program
    {
        static SchoolContext context = new SchoolContext();

        static void Main(string[] args)
        {

            using (SchoolContext context = new SchoolContext())
            {
                 Repository<Team> teamUnit = new Repository<Team>(context);
                
                 Repository<Person> people = new Repository<Person>(context);
                 Repository<Team> teams = new Repository<Team>(context);
                 Repository<Role> roles = new Repository<Role>(context);
                 Repository<Engagement> engagements = new Repository<Engagement>(context);

                Engagement engagement = new Engagement()
                {
                    Person = people.Get(1),
                    Team = teams.Get(1),
                    Role = roles.Get(1),
                    Time = 40,
                    StartDate = new DateTime(2016, 2, 1)

                };

                engagements.Insert(engagement);
            }

        }




    }

    //string choice = "X";

    //do
    //{
    //    Console.WriteLine("Odaberi opciju:");
    //    Console.WriteLine("1. Ispis timova");
    //    Console.WriteLine("2. Ispis jednog tima");
    //    Console.WriteLine("3. Otvaranje novog tima");
    //    Console.WriteLine("9. Kraj programa");
    //    choice = Console.ReadLine();
    //    switch (choice)
    //    {
    //        case "1": { printAllTeams(); break; }
    //        case "2": { printOneTeam(); break; }
    //        case "3": { insertTeam(); break; }
    //    }
    //}
    //while (choice != "9");


}

//static void printAllTeams()
//{
//    var teams = teamUnit.Get().ToList();
//    foreach (var team in teams)
//    {
//        Console.WriteLine(team.Id + ": " + team.Name);

//    }
//    Console.ReadKey();
//}

//static void printOneTeam()
//{
//    Console.WriteLine();
//    Console.Write("Upisi ident: ");
//    string sid = Console.ReadLine();
//    if (sid != "")
//    {
//        int id = Convert.ToInt32(sid);
//        var team = teamUnit.Get(id);
//        if (team != null)
//        {
//            Console.WriteLine(team.Id + ":" + team.Name);
//            Console.ReadKey();
//        }
//    }


//}


//static void insertTeam()
//{
//    Console.WriteLine();
//    Console.Write("Naziv tima: ");
//    string naziv = Console.ReadLine();
//    Console.Write("Tip[1, 2, 3]: ");
//    string tip = Console.ReadLine();

//    Team team = new Team()
//    {
//        Name = naziv,
//        Type = (ProjectType)Convert.ToInt32(tip)
//};
//    teamUnit.Insert(team);
//}




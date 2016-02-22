using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace DataSeed
{
    class ProgramDetail
    {
        static Repository<Detail> detailUnit = new Repository<Detail>();
        static void Main(string[] args)
        {
            string choice = "x";
            do
            {
                Console.Clear();
                Console.WriteLine("Odaberi opciju:");
                Console.WriteLine("1. Ispis detalja");
                Console.WriteLine("2. Ispis jednog detalja");
                Console.WriteLine("3. Otvaranje novog tima");
                Console.WriteLine("4. Brisanje detalja");
                Console.WriteLine("5. Izmjena detalja");
                Console.WriteLine("9. Kraj programa");


                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": { printAllDetails(); break; }
                    case "2": { printOneDetail(); break; }
                    case "3": { insertDetail(); break; }
                    case "4": { deleteDetail(); break; }
                    case "5": { updateDetail(); break; }

                }
            }
            while (choice != "9");
        }

        static void printAllDetails()
        {
            var details = detailUnit.Get().ToList();
            foreach (var detail in details)
            {
                Console.WriteLine(detail.Id + ": " + detail.Description);
            }
            Console.ReadKey();
        }

        static void printOneDetail()
        {
            Console.WriteLine();
            Console.Write("Upisi ident:");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);
                var detail = detailUnit.Get(id);
                if (detail != null)
                {
                    Console.WriteLine(detail.Id + ":" + detail.Description);
                    Console.ReadKey();
                }
            }
        }
        static void insertDetail()
        {
            Console.WriteLine();
            Console.Write("Naziv detalja:");
            string naziv = Console.ReadLine();
            if (naziv != "")
            {

                Detail detail = new Detail()
                {
                    Description = naziv,
                };
                detailUnit.Insert(detail);

            }
        }

        static void deleteDetail()
        {
            Console.WriteLine();
            Console.WriteLine("Naziv detalja: ");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);
                Detail detail = new Detail()
                {
                    Id = id
                };
                detailUnit.Delete(id);
            }
        }


        static void updateDetail()
        {
            Console.WriteLine();
            Console.WriteLine("Unesite ID detalja koji zelite izmjeniti: ");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);
                using (SchoolContext context = new SchoolContext())
                {
                    DetailUnit detailUnit = new DetailUnit(context);
                    Repository<Day> dayRepository = new Repository<Day>(context);
                    Repository<Team> teamRepository = new Repository<Team>(context);
                    Detail detail = detailUnit.Get(id);
                    if (detail != null)
                    {
                        Console.WriteLine("Enter new Day information: ");
                        //DateTime day = Convert.ToDateTime(Console.ReadLine());
                        detail.Day = dayRepository.Get(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new WorkTime information: ");
                        detail.WorkTime = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new BillTime information: ");
                        detail.BillTime = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new Description: ");
                        detail.Description = Console.ReadLine();
                        Console.WriteLine("Enter new Team information: ");
                        detail.Team = teamRepository.Get(id);
                    }



                }
            }
        }
    }
}

using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeed
{
    class ProgramHaris
    {
        static Repository<CharacteristicName> charNameUnit = new Repository<CharacteristicName>();
        static SchoolContext context = new SchoolContext();

        static void Main(string[] args)
        {
            string choice = "x";
            do
            {

                Console.WriteLine("Odaberi opciju: ");
                Console.WriteLine("1. Ispis svih kategorija");
                Console.WriteLine("2. Ispis jedne kategorije");
                Console.WriteLine("3. Unos nove kategorije");
                Console.WriteLine("4. Brisanje kategorije");
                Console.WriteLine("5. Update kategorije");
                Console.WriteLine("9. Kraj programa");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": { printAllCharac(); break; }
                    case "2": { printOneCharac(); break; }
                    //case "3": { insertTeam(); break; }
                   // case "4": { deleteTeam(); break; }
                   // case "5": { updateTeam(); break; }
                }


            } while (choice != "9");
        }
        static void printAllCharac()
        {
            var charac = charNameUnit.Get().ToList();
            foreach (var charName in charac)
            {
                Console.WriteLine(charName.Id + ": " + charName.Name + " " + charName.ResourceCategory.CategoryName);
            }
        }
        
        static void printOneCharac()
        {
            Console.WriteLine("Enter id: ");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);
                var charac = charNameUnit.Get(id);
                if (charac != null)
                {
                    Console.WriteLine(charac.Id + ": " + charac.Name);
                }
            }
        }
        static void insertCharac()
        {

        }
    }
}

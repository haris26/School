//using Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataSeed
//{
//    class ProgramHaris
//    {
//        static SchoolContext context = new SchoolContext();
//        static Repository<ResourceCategory> resourceCat = new Repository<ResourceCategory>(context);
//        static Repository<CharacteristicName> characteristicNames = new Repository<CharacteristicName>(context);

//        static void Main(string[] args)
//        {
//            string choice = "x";
//            do
//            {
//                Console.WriteLine("Choose an option: ");
//                Console.WriteLine("1. List all characteristics");
//                Console.WriteLine("2. List specific characteristic");
//                Console.WriteLine("3. Insert new characteristic");
//                Console.WriteLine("4. Delete characterstic");
//                Console.WriteLine("5. Update characteristic");
//                Console.WriteLine("9. Close program");

//                choice = Console.ReadLine();
//                switch (choice)
//                {
//                    case "1": { printAllCharac(); break; }
//                    case "2": { printOneCharac(); break; }
//                    case "3": { insertCharac(); break; }
//                    case "4": { deleteCharac(); break; }
//                    case "5": { updateCharac(); break; }

//                }


//            } while (choice != "9");
//        }
//        static void printAllCharac()
//        {

//            var charac = characteristicNames.Get().ToList();

//            foreach (var charName in charac)
//            {
//                Console.WriteLine(charName.Id + ": " + charName.Name + " " + charName.ResourceCategory.CategoryName);
//            }

//            Console.ReadKey();
//        }

//        static void printOneCharac()
//        {
//            Console.WriteLine("Enter id: ");
//            string sid = Console.ReadLine();
//            if (sid != "")
//            {
//                int id = Convert.ToInt32(sid);

//                var charac = characteristicNames.Get(id);
//                if (charac != null)
//                {
//                    Console.WriteLine(charac.Id + ": " + charac.Name);
//                }
//            }

//            Console.ReadKey();
//        }
//        static void allResourceCat()
//        {
//            var resCat = resourceCat.Get().ToList();
//            foreach (var resource in resCat)
//            {
//                Console.WriteLine("If it is for: " + resource.CategoryName + " enter: " + resource.Id);
//            }
//        }
//        static void insertCharac()
//        {
//            Console.WriteLine("Enter new characteristic: ");
//            string cName = Console.ReadLine();
//            if (cName != "")
//            {
//                allResourceCat();
//                string numb = Console.ReadLine();
//                CharacteristicName cn = new CharacteristicName()
//                {
//                    Name = cName,
//                    ResourceCategory = resourceCat.Get(Convert.ToInt32(numb))
//                };
//                characteristicNames.Insert(cn);
//            }
//            Console.ReadKey();
//        }
//        static void deleteCharac()
//        {
//            Console.WriteLine("Enter characteristic ID: ");
//            string sid = Console.ReadLine();
//            if (sid != "")
//            {
//                int id = Convert.ToInt32(sid);
//                var charac = characteristicNames.Get(id);
//                if (charac != null)
//                {
//                    characteristicNames.Delete(charac.Id);
//                }
//            }
//            Console.ReadKey();
//        }
//        static void updateCharac()
//        {
//            Console.WriteLine("Enter characteristic ID: ");
//            string sid = Console.ReadLine();
//            if (sid != "")
//            {
//                var charac = characteristicNames.Get(Convert.ToInt32(sid));
//                if (charac != null)
//                {
//                    Console.WriteLine("Change characteristic name: ");
//                    string cName = Console.ReadLine();
//                    charac.Name = cName;
//                    Console.WriteLine("This is characteristic for wich resource: ");
//                    allResourceCat();
//                    string numb = Console.ReadLine();
//                    charac.ResourceCategory = resourceCat.Get(Convert.ToInt32(numb));
//                    characteristicNames.Update(charac, charac.Id);
//                }
//            }
//            Console.ReadKey();
//        }
//    }
//}

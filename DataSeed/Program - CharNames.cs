using Database;
using System;
using System.Linq;

namespace DataSeed
{
    class Program___CharNames
    {
        static void doCharacteristicNames()
        {
            string choice = "x";
            do
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("CHARACTERISTICS");
                Console.WriteLine("1. Show characteristic names");
                Console.WriteLine("2. Show one characteristic name");
                Console.WriteLine("3. Insert new characteristic name");
                Console.WriteLine("4. Delete characterstic name");
                Console.WriteLine("5. Update characteristic names");
                Console.WriteLine("9. Return");
                Console.WriteLine("----------------------------------------");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": { showAllCharacteristicNames(); break; }
                    case "2": { showOneCharacteristicName(); break; }
                    case "3": { insertNewCharacteristicName(); break; }
                    case "4": { deleteCharacteristicName(); break; }
                    case "5": { updateCharacteristicName(); break; }
                }
            } while (choice != "9");
            Console.Clear();
        }

        static void addCharacteristicsForCat(int Id)
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<AssetCharacteristicNames> characteristics = new Repository<AssetCharacteristicNames>(context);
                Repository<AssetCategory> categories = new Repository<AssetCategory>(context);
                AssetCategory cat = categories.Get(Id);
                Console.WriteLine("Characteristic name: ");
                string cName = Console.ReadLine();
                if (cName != "")
                {
                    AssetCharacteristicNames cn = new AssetCharacteristicNames()
                    {
                        Name = cName,
                        AssetCategory = cat
                    };
                    characteristics.Insert(cn);
                }
            }
        }

        static void deleteCharcteristicNames(int Id)
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<AssetCharacteristicNames> characteristicsOfCat = new Repository<AssetCharacteristicNames>(context);
                var characteristics = characteristicsOfCat.Get().ToList();
                var catCharacteristics = characteristics.Where(x => x.AssetCategory.Id == Id);
                foreach (var name in catCharacteristics)
                {
                    characteristicsOfCat.Delete(name.Id);
                }
            }
        }

        

        static void showAllCharacteristicNames()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<AssetCharacteristicNames> characteristicNames = new Repository<AssetCharacteristicNames>(context);
                Console.WriteLine();
                var charac = characteristicNames.Get().ToList();
                foreach (var charName in charac)
                {
                    Console.WriteLine(charName.Id + " - " + charName.Name + " | " + charName.AssetCategory.CategoryName);
                }
                Console.WriteLine("---------------------------------------");
            }
        }

        static void showOneCharacteristicName()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<AssetCharacteristicNames> characteristicNames = new Repository<AssetCharacteristicNames>(context);
                Console.WriteLine();
                Console.WriteLine("Enter asset characteristic name id: ");
                string enteredId = Console.ReadLine();
                if (enteredId != "")
                {
                    int id = Convert.ToInt32(enteredId);
                    var charName = characteristicNames.Get(id);
                    if (charName != null)
                    {
                        Console.WriteLine(charName.Id + " - " + charName.Name + " | " + charName.AssetCategory.CategoryName);
                    }
                }
                Console.WriteLine("                  ");
            }
        }

        static void insertNewCharacteristicName()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<AssetCharacteristicNames> characteristicNames = new Repository<AssetCharacteristicNames>(context);
                Repository<AssetCategory> categories = new Repository<AssetCategory>(context);
                Console.WriteLine();
                Console.WriteLine("Choose asset category to add new characteristic: ");
                //showAllCategories();
                int categoryId = Convert.ToInt32(Console.ReadLine());
                AssetCategory cat = categories.Get(categoryId);
                Console.WriteLine("Characteristic name: ");
                string cName = Console.ReadLine();
                if (cName != "")
                {
                    AssetCharacteristicNames cn = new AssetCharacteristicNames()
                    {
                        Name = cName,
                        AssetCategory = cat
                    };
                    characteristicNames.Insert(cn);
                }
                Console.WriteLine("                  ");
            }
        }

        static void updateCharacteristicName()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<AssetCharacteristicNames> characteristicNames = new Repository<AssetCharacteristicNames>(context);
                Repository<AssetCategory> categories = new Repository<AssetCategory>(context);
                Console.WriteLine();
                Console.WriteLine("Enter id: ");
                string enteredId = Console.ReadLine();
                if (enteredId != "")
                {
                    var charName = characteristicNames.Get(Convert.ToInt32(enteredId));
                    if (charName != null)
                    {
                        Console.WriteLine("Edit name: ");
                        string cName = Console.ReadLine();
                        charName.Name = cName;
                        
                        string numb = Console.ReadLine();
                        charName.AssetCategory = categories.Get(Convert.ToInt32(numb));
                        characteristicNames.Update(charName, charName.Id);
                    }
                }
                Console.WriteLine("                              ");
            }
        }

        static void deleteCharacteristicName()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<AssetCharacteristicNames> characteristicNames = new Repository<AssetCharacteristicNames>(context);
                Console.WriteLine();
                Console.WriteLine("Enter Id: ");
                string cid = Console.ReadLine();
                if (cid != "")
                {
                    int id = Convert.ToInt32(cid);
                    var charac = characteristicNames.Get(id);
                    if (charac != null)
                    {
                        characteristicNames.Delete(charac.Id);
                    }
                }
                Console.WriteLine("--------------------------------------------");
            }
        }
    }
}

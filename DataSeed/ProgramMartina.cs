//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Database;

//namespace DataSeed
//{
//    class ProgramMartina
//    {
//        static ResourceUnit resourceUnit = new ResourceUnit();
//        static Repository<ResourceCategory> categoriesUnit = new Repository<ResourceCategory>();

//        static void Main(string[] args)
//        {
//            string enteredChoice = "x";
//            do
//            {
//                Console.Write("RESOURCE");
//                Console.WriteLine("Choose one option ");
//                Console.WriteLine("1. Show all resources");
//                Console.WriteLine("2. Show one resource");
//                Console.WriteLine("3. Add new resource");
//                Console.WriteLine("4. Delete resource");
//                Console.WriteLine("5. Update resource");
//                Console.WriteLine("6. End");
//                Console.WriteLine("----------------------");
//                enteredChoice = Console.ReadLine();
//                switch (enteredChoice)
//                {
//                    case "1": { showAllResources(); break; }
//                    case "2": { showOneResource(); break; }
//                    case "3": { insertNewResource(); break; }
//                    case "4": { deleteResource(); break; }
//                    case "5": { updateResource(); break; }

//                }
//            } while (enteredChoice != "6");
//        }

//        static void showAllResources()
//        {
//            var resources = resourceUnit.Get().ToList();
//            foreach (var resource in resources)
//            {
//                Console.WriteLine(resource.Id + " : " + resource.Name + " : " + resource.ResourceCategory + " : " + resource.Status);
//            }
//            Console.WriteLine("----------------------------");
//            Console.ReadKey();
//        }

//        static void showOneResource()
//        {
//            Console.WriteLine();
//            Console.Write("Enter resource id: ");
//            string enteredId = Console.ReadLine();
//            if (enteredId != "")
//            {
//                int id = Convert.ToInt32(enteredId);
//                var resource = resourceUnit.Get(id);
//                if (resource != null)
//                {
//                    Console.WriteLine(resource.Id + ": " + resource.Name + " | " + resource.ResourceCategory + " | " + resource.Status);
//                    Console.WriteLine("----------------------");
//                    Console.ReadKey();
//                }
//            }
//        }

//        static void insertNewResource()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Resource name: ");
//            string name = Console.ReadLine();

//            if (name != "")
//            {
//                Console.Write(" Resource status [1 - available, 2 - reserved]: ");
//                string status = Console.ReadLine();
//                Console.WriteLine("Resource category: ");
//                showAllCategories();
//                int categoryId = Convert.ToInt32(Console.ReadLine());
//                ResourceCategory cat = categoriesUnit.Get(categoryId);
//                Resource resource = new Resource()
//                {
//                    Name = name,
//                    Status = (ReservationStatus)Convert.ToInt32(status),
//                    ResourceCategory = cat

//                };
//                resourceUnit.Insert(resource);
//            }
//            Console.WriteLine("----------------------");
//        }

//        static void deleteResource()
//        {
            
//        }

//        static void updateResource()
//        {
            
//        }

//        static void showAllCategories()
//        {
//            var categories = categoriesUnit.Get().ToList();
//            foreach (var cat in categories)
//            {
//                Console.WriteLine(cat.Id + " - " + cat.CategoryName);   
//            }
//        }

//        static void addNewCategory()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Category name: ");
//            string name = Console.ReadLine();

//            if (name != "")
//            {
//                ResourceCategory cat = new ResourceCategory()
//                {
//                    CategoryName = name,
                    
//                };
//                categoriesUnit.Insert(cat);
//            }
//            Console.WriteLine("----------------------");
//        }
//    }
//}

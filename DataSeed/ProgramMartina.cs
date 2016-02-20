using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace DataSeed
{
    class ProgramMartina
    {
        static SchoolContext context = new SchoolContext();
        static Repository<Resource> resources = new Repository<Resource>(context);
        static Repository<ResourceCategory> categories = new Repository<ResourceCategory>(context);
        static Repository<CharacteristicName> characteristicsOfCat = new Repository<CharacteristicName>(context); 

        static void Main(string[] args)
        {
            string enteredChoice = "x";
            do
            {
                Console.WriteLine("Choose one option ");
                Console.WriteLine("1. RESOURCES");
                Console.WriteLine("2. RESOURCE CATEGORIES");
                Console.WriteLine("3. End");
                Console.WriteLine("----------------------");
                enteredChoice = Console.ReadLine();
                switch (enteredChoice)
                {
                    case "1": { doResources(); break; }
                    case "2": { doResourceCategories(); break; }
                }
            } while (enteredChoice != "3");
            Console.Clear();
        }

        static void doResources()
        {
            string enteredChoice = "x";
            do
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("RESOURCES");
                Console.WriteLine("Choose one option ");
                Console.WriteLine("1. Show all resources");
                Console.WriteLine("2. Show one resource");
                Console.WriteLine("3. Add new resource");
                Console.WriteLine("4. Delete resource");
                Console.WriteLine("5. Update resource");
                Console.WriteLine("6. End");
                Console.WriteLine("----------------------");
                enteredChoice = Console.ReadLine();
                switch (enteredChoice)
                {
                    case "1": { showAllResources(); break; }
                    case "2": { showOneResource(); break; }
                    case "3": { insertNewResource(); break; }
                    case "4": { deleteResource(); break; }
                    case "5": { updateResource(); break; }
                }
            } while (enteredChoice != "6");
            Console.Clear();
        }

        static void doResourceCategories()
        {
            string enteredChoice = "x";
            do
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("RESOURCE CATEGORIES");
                Console.WriteLine("Choose one option ");
                Console.WriteLine("1. Show all categories");
                Console.WriteLine("2. Show one category");
                Console.WriteLine("3. Add new category");
                Console.WriteLine("4. Delete category");
                Console.WriteLine("5. Update category");
                Console.WriteLine("6. End");
                Console.WriteLine("----------------------");
                enteredChoice = Console.ReadLine();
                switch (enteredChoice)
                {
                    case "1": { showAllCategories(); break; }
                    case "2": { showOneCategory(); break; }
                    case "3": { insertNewCategory(); break; }
                    case "4": { deleteCategory(); break; }
                    case "5": { updateCategory(); break; }
                }
            } while (enteredChoice != "6");
            Console.Clear();
        }

        static void showAllResources()
        {
            var resources = ProgramMartina.resources.Get().ToList();
            foreach (var resource in resources)
            {
                Console.WriteLine(resource.Id + ": " + resource.Name + " | " + resource.ResourceCategory.CategoryName + " | " + resource.Status);
            }
            Console.WriteLine("----------------------------");
            Console.ReadKey();
        }

        static void showOneResource()
        {
            Console.WriteLine();
            Console.Write("Enter resource id: ");
            string enteredId = Console.ReadLine();
            if (enteredId != "")
            {
                int id = Convert.ToInt32(enteredId);
                var resource = resources.Get(id);
                if (resource != null)
                {
                    Console.WriteLine(resource.Id + ": " + resource.Name + " | " + resource.ResourceCategory.CategoryName + " | " + resource.Status);
                }
                Console.WriteLine("----------------------");
                Console.ReadKey();
            }
        }

        static void insertNewResource()
        {
            Console.WriteLine();
            Console.WriteLine("Resource name: ");
            string name = Console.ReadLine();

            if (name != "")
            {
                Console.Write(" Resource status [1 - available, 2 - reserved]: ");
                string status = Console.ReadLine();
                Console.WriteLine("Resource category: ");
                showAllCategories();
                int categoryId = Convert.ToInt32(Console.ReadLine());
                ResourceCategory cat = categories.Get(categoryId);
                Resource resource = new Resource()
                {
                    Name = name,
                    Status = (ReservationStatus)Convert.ToInt32(status),
                    ResourceCategory = cat
                };
                resources.Insert(resource);
            }
            Console.WriteLine("----------------------");
            Console.ReadKey();
        }

        static void deleteResource()
        {
            Console.WriteLine();
            Console.WriteLine("Resource id: ");
            string sid = Console.ReadLine();

            if (sid != "")
            {
                int id = Convert.ToInt32(sid);
                var resource = resources.Get(id);
                if (resource != null) resources.Delete(resource.Id);
                Console.WriteLine("You deleted resource: " + resource.Name);
            }
            Console.WriteLine("----------------------");
            Console.ReadKey();
        }

        static void updateResource()
        {
            Console.WriteLine();
            Console.WriteLine("Resource id: ");
            string sid = Console.ReadLine();

            if (sid != "")
            {
                int id = Convert.ToInt32(sid);
                var resource = resources.Get(id);
                if (resource != null)
                {
                    Console.WriteLine("Edit resource name: ");
                    resource.Name = Console.ReadLine(); 
                    Console.WriteLine("Edit resource status [1 - available, 2 - reserved]: ");
                    string status = Console.ReadLine();
                    resource.Status = (ReservationStatus)Convert.ToInt32(status);
                    Console.WriteLine("Edit resource category: ");
                    showAllCategories();
                    int categoryId = Convert.ToInt32(Console.ReadLine());
                    ResourceCategory cat = categories.Get(categoryId);
                    resource.ResourceCategory = cat;
                    resources.Update(resource, resource.Id);
                }
                Console.WriteLine("----------------------");
                Console.ReadKey();
            }
        }

        static void showAllCategories()
        {
            var allCats = categories.Get().ToList();
            foreach (var cat in allCats)
            {
                Console.WriteLine(cat.Id + " - " + cat.CategoryName);
            }
            Console.WriteLine("----------------------");
            Console.ReadKey();
        }

        static void showOneCategory()
        {
            Console.WriteLine();
            Console.Write("Enter category id: ");
            string enteredId = Console.ReadLine();
            if (enteredId != "")
            {
                int id = Convert.ToInt32(enteredId);
                var cat = categories.Get(id);
                if (cat != null)
                {
                    Console.WriteLine(cat.Id + ": " + cat.CategoryName);
                    var characteristics = characteristicsOfCat.Get().ToList();
                    var catCharacteristics = characteristics.Where(x => x.ResourceCategory.Id == cat.Id);
                    Console.WriteLine(cat.CategoryName + " characteristics: ");
                    foreach (var name in catCharacteristics)
                    {
                        Console.WriteLine("- " + name.Name);
                    }
                }
                Console.WriteLine("----------------------");
                Console.ReadKey();
            }
        }

        static void insertNewCategory()
        {
            Console.WriteLine();
            Console.WriteLine("Category name: ");
            string name = Console.ReadLine();

            if (name != "")
            {
                ResourceCategory cat = new ResourceCategory()
                {
                    CategoryName = name,    
                };
                categories.Insert(cat);
            }
            Console.WriteLine("----------------------");
            Console.ReadKey();
        }

        static void updateCategory()
        {
            Console.WriteLine();
            Console.WriteLine("Category id: ");
            string sid = Console.ReadLine();

            if (sid != "")
            {
                int id = Convert.ToInt32(sid);
                var category = categories.Get(id);
                if (category != null)
                {
                    Console.WriteLine("Edit category name: ");
                    category.CategoryName = Console.ReadLine();
                    categories.Update(category, category.Id);
                }
                Console.WriteLine("----------------------");
                Console.ReadKey();
            }
        }

        static void deleteCategory()
        {
            Console.WriteLine();
            Console.WriteLine("Category id: ");
            string sid = Console.ReadLine();

            if (sid != "")
            {
                int id = Convert.ToInt32(sid);
                var cat = categories.Get(id);
                if (cat != null) resources.Delete(cat.Id);
                Console.WriteLine("You deleted category: " + cat.CategoryName);
            }
            Console.WriteLine("----------------------");
            Console.ReadKey();
        }
    }
}

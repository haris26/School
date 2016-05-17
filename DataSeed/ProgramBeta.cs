using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Database;

namespace DataSeed
{
    class ProgramBeta
    {
        static void Main(string[] args)
        {
            string enteredChoice = "x";
            do
            {
                Console.WriteLine("Choose one option ");
                Console.WriteLine("1. RESOURCES");
                Console.WriteLine("2. RESOURCE CATEGORIES");
                Console.WriteLine("3. CHARACTERISTICS ");
                Console.WriteLine("4. CHARACTERISTIC NAMES");
                Console.WriteLine("5. EVENTS");
                Console.WriteLine("6. EXTENDED EVENTS");
                Console.WriteLine("7. End");
                Console.WriteLine("--------------------------------------------");
                enteredChoice = Console.ReadLine();
                switch (enteredChoice)
                {
                    case "1":
                        {
                            doResources();
                            break;
                        }
                    case "2":
                        {
                            doResourceCategories();
                            break;
                        }
                    case "3":
                        {
                            doCharacteristics();
                            break;
                        }
                    case "4":
                        {
                            doCharacteristicNames();
                            break;
                        }
                    case "5":
                        {
                            doEvents();
                            break;
                        }
                    case "6":
                        {
                            doExtendedEvents();
                            break;
                        }
                }
            } while (enteredChoice != "7");
            Console.Clear();
        }

        static void doResources()
        {
            string enteredChoice = "x";
            do
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("RESOURCES");
                Console.WriteLine("1. Show all resources");
                Console.WriteLine("2. Show one resource");
                Console.WriteLine("3. Add new resource");
                Console.WriteLine("4. Delete resource");
                Console.WriteLine("5. Update resource");
                Console.WriteLine("6. End");
                Console.WriteLine("--------------------------------------------");
                enteredChoice = Console.ReadLine();
                switch (enteredChoice)
                {
                    case "1":
                        {
                            showAllResources();
                            break;
                        }
                    case "2":
                        {
                            showOneResource();
                            break;
                        }
                    case "3":
                        {
                            insertNewResource();
                            break;
                        }
                    case "4":
                        {
                            deleteResource();
                            break;
                        }
                    case "5":
                        {
                            updateResource();
                            break;
                        }
                }
            } while (enteredChoice != "6");
            Console.Clear();
        }

        static void doResourceCategories()
        {
            string enteredChoice = "x";
            do
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("RESOURCE CATEGORIES");
                Console.WriteLine("1. Show all categories");
                Console.WriteLine("2. Show one category");
                Console.WriteLine("3. Add new category");
                Console.WriteLine("4. Delete category");
                Console.WriteLine("5. Update category");
                Console.WriteLine("6. End");
                Console.WriteLine("--------------------------------------------");
                enteredChoice = Console.ReadLine();
                switch (enteredChoice)
                {
                    case "1":
                        {
                            showAllCategories();
                            break;
                        }
                    case "2":
                        {
                            showOneCategory();
                            break;
                        }
                    case "3":
                        {
                            insertNewCategory();
                            break;
                        }
                    case "4":
                        {
                            deleteCategory();
                            break;
                        }
                    case "5":
                        {
                            updateCategory();
                            break;
                        }
                }
            } while (enteredChoice != "6");
            Console.Clear();
        }

        static void doCharacteristicNames()
        {
            string enteredChoice = "x";
            do
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("CHARACTERISTICS");
                Console.WriteLine("1. Show all characteristic names");
                Console.WriteLine("2. Show one characteristic name");
                Console.WriteLine("3. Add new characteristic name");
                Console.WriteLine("4. Delete characterstic name");
                Console.WriteLine("5. Update characteristic name");
                Console.WriteLine("6. End");
                Console.WriteLine("--------------------------------------------");
                enteredChoice = Console.ReadLine();
                switch (enteredChoice)
                {
                    case "1":
                        {
                            showAllCharacteristicNames();
                            break;
                        }
                    case "2":
                        {
                            showOneCharacteristicName();
                            break;
                        }
                    case "3":
                        {
                            insertNewCharacteristicName();
                            break;
                        }
                    case "4":
                        {
                            deleteCharacteristicName();
                            break;
                        }
                    case "5":
                        {
                            updateCharacteristicName();
                            break;
                        }
                }
            } while (enteredChoice != "6");
            Console.Clear();
        }

        static void doCharacteristics()
        {
            string enteredChoice = "x";
            do
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("CHARACTERISTICS");
                Console.WriteLine("1. Show all characteristics");
                Console.WriteLine("2. Show one characteristic");
                Console.WriteLine("3. Add new characteristic");
                Console.WriteLine("4. Delete characterstic");
                Console.WriteLine("5. Update characteristic");
                Console.WriteLine("6. End");
                Console.WriteLine("--------------------------------------------");
                enteredChoice = Console.ReadLine();
                switch (enteredChoice)
                {
                    case "1":
                        {
                            showAllCharacteristics();
                            break;
                        }
                    case "2":
                        {
                            showOneCharacteristic();
                            break;
                        }
                    case "3":
                        {
                            insertNewCharacteristic();
                            break;
                        }
                    case "4":
                        {
                            deleteCharacteristic();
                            break;
                        }
                    case "5":
                        {
                            updateCharacteristic();
                            break;
                        }
                }
            } while (enteredChoice != "6");
            Console.Clear();
        }

        static void doEvents()
        {
            string choice = "X";
            do
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("EVENTS");
                Console.WriteLine("1. Show all events ");
                Console.WriteLine("2. Show one event ");
                Console.WriteLine("3. Crate new event ");
                Console.WriteLine("4. Update event ");
                Console.WriteLine("5. Delete event ");
                Console.WriteLine("6. End");
                Console.WriteLine("--------------------------------------------");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            showAllEvents();
                            break;
                        }
                    case "2":
                        {
                            showOneEvent();
                            break;
                        }
                    case "3":
                        {
                            insertNewEvent();
                            break;
                        }
                    case "4":
                        {
                            updateEvent();
                            break;
                        }
                    case "5":
                        {
                            deleteEvent();
                            break;
                        }

                }
            } while (choice != "6");
        }

        static void doExtendedEvents()
        {
            string choice = "X";
            do
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("EXTENDED EVENTS");
                Console.WriteLine("1. Show all events ");
                Console.WriteLine("2. Show one event ");
                Console.WriteLine("3. Crate new event ");
                Console.WriteLine("4. Update event ");
                Console.WriteLine("5. Delete event ");
                Console.WriteLine("6. End");
                Console.WriteLine("--------------------------------------------");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            showAllExtendedEvents();
                            break;
                        }
                    case "2":
                        {
                            showOneExtendedEvent();
                            break;
                        }
                    case "3":
                        {
                            insertNewExtendedEvent();
                            break;
                        }
                    case "4":
                        {
                            updateExtendedEvent();
                            break;
                        }
                    case "5":
                        {
                            deleteExtendedEvent();
                            break;
                        }

                }
            } while (choice != "6");
        }

        //CRUD methods for Resources
        static void showAllResources()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Resource> resources = new Repository<Resource>(context);
                var allResources = resources.Get().ToList();
                foreach (var resource in allResources)
                {
                    Console.WriteLine(resource.Id + ": " + resource.Name + " | " +
                                      resource.ResourceCategory.CategoryName + " | ");
                }
                Console.WriteLine("--------------------------------------------------");
            }
        }

        static void showOneResource()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Resource> resources = new Repository<Resource>(context);
                Console.WriteLine();
                Console.Write("Enter resource id: ");
                string enteredId = Console.ReadLine();
                if (enteredId != "")
                {
                    int id = Convert.ToInt32(enteredId);
                    var resource = resources.Get(id);
                    if (resource != null)
                    {
                        Console.WriteLine(resource.Id + ": " + resource.Name + " | " +
                                          resource.ResourceCategory.CategoryName + " | ");
                    }
                    Console.WriteLine("--------------------------------------------");
                }
            }
        }

        static void insertNewResource()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Resource> resources = new Repository<Resource>(context);
                Repository<ResourceCategory> categories = new Repository<ResourceCategory>(context);
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
                        ResourceCategory = cat
                    };
                    resources.Insert(resource);
                }
            }
        }

        static void updateResource()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Resource> resources = new Repository<Resource>(context);
                Repository<ResourceCategory> categories = new Repository<ResourceCategory>(context);
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
                        Console.WriteLine("Edit resource category: ");
                        showAllCategories();
                        int categoryId = Convert.ToInt32(Console.ReadLine());
                        ResourceCategory cat = categories.Get(categoryId);
                        resource.ResourceCategory = cat;

                        resources.Update(resource, resource.Id);
                    }
                    Console.WriteLine("--------------------------------------------");
                }
            }
        }

        static void deleteResource()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Resource> resources = new Repository<Resource>(context);
                Console.WriteLine();
                Console.WriteLine("Resource id: ");
                string sid = Console.ReadLine();

                if (sid != "")
                {
                    int id = Convert.ToInt32(sid);
                    var resource = resources.Get(id);
                    if (resource != null)
                    {
                        resources.Delete(resource.Id);
                    }
                    Console.WriteLine("You deleted resource: " + resource.Name);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void getCatCharacteristicNames(int Id)
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<CharacteristicName> characteristicsOfCat = new Repository<CharacteristicName>(context);
                var characteristics = characteristicsOfCat.Get().ToList();
                var catCharacteristics = characteristics.Where(x => x.ResourceCategory.Id == Id);
                foreach (var name in catCharacteristics)
                {
                    Console.WriteLine("- " + name.Name);
                }
            }
        }

        static void updateCatCharacteristicNames(int Id)
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<CharacteristicName> characteristicsOfCat = new Repository<CharacteristicName>(context);
                var characteristics = characteristicsOfCat.Get().ToList();
                var catCharacteristics = characteristics.Where(x => x.ResourceCategory.Id == Id);
                foreach (var name in catCharacteristics)
                {
                    Console.WriteLine("Edit characteristic name for " + name.Name + " : ");
                    name.Name = Console.ReadLine();
                    characteristicsOfCat.Update(name, name.Id);
                }
            }
        }

        //CRUD methods for resource category
        static void showAllCategories()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<ResourceCategory> categories = new Repository<ResourceCategory>(context);
                var allCats = categories.Get().ToList();
                foreach (var cat in allCats)
                {
                    Console.WriteLine(cat.Id + " - " + cat.CategoryName);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void showOneCategory()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<ResourceCategory> categories = new Repository<ResourceCategory>(context);
                Repository<CharacteristicName> characteristicsOfCat = new Repository<CharacteristicName>(context);
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
                        Console.WriteLine("Characteristics for " + cat.CategoryName + ": ");
                        getCatCharacteristicNames(cat.Id);
                    }
                    Console.WriteLine("--------------------------------------------");
                }
            }
        }

        static void insertNewCategory()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<ResourceCategory> categories = new Repository<ResourceCategory>(context);
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
                    //adding characteristics of specific category
                    Console.WriteLine("Number of characteristics for category: ");
                    string numb = Console.ReadLine();
                    if (numb != "")
                    {
                        int number = Convert.ToInt32(numb);
                        for (int i = 0; i < number; i++)
                        {
                            addCharacteristicsForCat(cat.Id);
                        }
                    }
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void deleteCategory()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<ResourceCategory> categories = new Repository<ResourceCategory>(context);
                Console.WriteLine();
                Console.WriteLine("Category id: ");
                string enteredId = Console.ReadLine();

                if (enteredId != "")
                {
                    int id = Convert.ToInt32(enteredId);
                    var cat = categories.Get(id);
                    if (cat != null)
                    {
                        //deleting characteristics of specific category
                        deleteCharcteristicNames(cat.Id);
                        categories.Delete(cat.Id);
                    }
                    Console.WriteLine("You deleted category: " + cat.CategoryName);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void updateCategory()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<ResourceCategory> categories = new Repository<ResourceCategory>(context);

                Console.WriteLine();
                Console.WriteLine("Category id: ");
                string enteredId = Console.ReadLine();

                if (enteredId != "")
                {
                    int id = Convert.ToInt32(enteredId);
                    var category = categories.Get(id);
                    if (category != null)
                    {
                        Console.WriteLine("Edit category name: ");
                        category.CategoryName = Console.ReadLine();
                        //update characteristics of specific category
                        updateCatCharacteristicNames(category.Id);
                        categories.Update(category, category.Id);
                    }
                    Console.WriteLine("--------------------------------------------");
                }
            }
        }

        static void addCharacteristicsForCat(int Id)
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<CharacteristicName> characteristics = new Repository<CharacteristicName>(context);
                Repository<ResourceCategory> categories = new Repository<ResourceCategory>(context);
                ResourceCategory cat = categories.Get(Id);
                Console.WriteLine("Characteristic name: ");
                string cName = Console.ReadLine();
                if (cName != "")
                {
                    CharacteristicName cn = new CharacteristicName()
                    {
                        Name = cName,
                        ResourceCategory = cat
                    };
                    characteristics.Insert(cn);
                }
            }
        }

        static void deleteCharcteristicNames(int Id)
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<CharacteristicName> characteristicsOfCat = new Repository<CharacteristicName>(context);
                var characteristics = characteristicsOfCat.Get().ToList();
                var catCharacteristics = characteristics.Where(x => x.ResourceCategory.Id == Id);
                foreach (var name in catCharacteristics)
                {
                    characteristicsOfCat.Delete(name.Id);
                }
            }
        }

        //CRUD methods for characteristic names
        static void showAllCharacteristicNames()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<CharacteristicName> characteristicNames = new Repository<CharacteristicName>(context);
                Console.WriteLine();
                var charac = characteristicNames.Get().ToList();
                foreach (var charName in charac)
                {
                    Console.WriteLine(charName.Id + " - " + charName.Name + " | " +
                                      charName.ResourceCategory.CategoryName);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void showOneCharacteristicName()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<CharacteristicName> characteristicNames = new Repository<CharacteristicName>(context);
                Console.WriteLine();
                Console.WriteLine("Enter characteristic name id: ");
                string enteredId = Console.ReadLine();
                if (enteredId != "")
                {
                    int id = Convert.ToInt32(enteredId);
                    var charName = characteristicNames.Get(id);
                    if (charName != null)
                    {
                        Console.WriteLine(charName.Id + " - " + charName.Name + " | " +
                                          charName.ResourceCategory.CategoryName);
                    }
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void insertNewCharacteristicName()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<CharacteristicName> characteristicNames = new Repository<CharacteristicName>(context);
                Repository<ResourceCategory> categories = new Repository<ResourceCategory>(context);
                Console.WriteLine();
                Console.WriteLine("Choose resource category to add new characteristic: ");
                showAllCategories();
                int categoryId = Convert.ToInt32(Console.ReadLine());
                ResourceCategory cat = categories.Get(categoryId);
                Console.WriteLine("Characteristic name: ");
                string cName = Console.ReadLine();
                if (cName != "")
                {
                    CharacteristicName cn = new CharacteristicName()
                    {
                        Name = cName,
                        ResourceCategory = cat
                    };
                    characteristicNames.Insert(cn);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void updateCharacteristicName()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<CharacteristicName> characteristicNames = new Repository<CharacteristicName>(context);
                Repository<ResourceCategory> categories = new Repository<ResourceCategory>(context);
                Console.WriteLine();
                Console.WriteLine("Enter characteristic id: ");
                string enteredId = Console.ReadLine();
                if (enteredId != "")
                {
                    var charName = characteristicNames.Get(Convert.ToInt32(enteredId));
                    if (charName != null)
                    {
                        Console.WriteLine("Edit characteristic name: ");
                        string cName = Console.ReadLine();
                        charName.Name = cName;
                        Console.WriteLine("This is characteristic for wich resource: ");
                        showAllCategories();
                        string numb = Console.ReadLine();
                        charName.ResourceCategory = categories.Get(Convert.ToInt32(numb));
                        characteristicNames.Update(charName, charName.Id);
                    }
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void deleteCharacteristicName()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<CharacteristicName> characteristicNames = new Repository<CharacteristicName>(context);
                Console.WriteLine();
                Console.WriteLine("Enter characteristic Id: ");
                string sid = Console.ReadLine();
                if (sid != "")
                {
                    int id = Convert.ToInt32(sid);
                    var charac = characteristicNames.Get(id);
                    if (charac != null)
                    {
                        characteristicNames.Delete(charac.Id);
                    }
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        //CRUD methods for characteristics
        static void showAllCharacteristics()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Characteristic> characteristics = new Repository<Characteristic>(context);
                var allCharacteristics = characteristics.Get().ToList();
                foreach (var characteristic in allCharacteristics)
                {
                    Console.WriteLine(characteristic.Id + " - " + characteristic.Name + " - " + characteristic.Value +
                                      " | " + characteristic.Resource.Name);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void showOneCharacteristic()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Characteristic> characteristics = new Repository<Characteristic>(context);
                Console.WriteLine("Enter characteristic id: ");
                string enteredId = Console.ReadLine();
                if (enteredId != "")
                {
                    int id = Convert.ToInt32(enteredId);
                    var characteristic = characteristics.Get(id);
                    if (characteristic != null)
                    {
                        Console.WriteLine(characteristic.Id + " - " + characteristic.Name + " - " + characteristic.Value +
                                          " | " + characteristic.Resource.Name);
                    }
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void insertNewCharacteristic()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Characteristic> characteristics = new Repository<Characteristic>(context);
                Repository<Resource> resources = new Repository<Resource>(context);
                Console.WriteLine();
                Console.WriteLine("Characteristic name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Characteristic value: ");
                string value = Console.ReadLine();
                var resource = resources.Get(2);
                Characteristic charac = new Characteristic()
                {
                    Name = name,
                    Value = value,
                    Resource = resource
                };
                characteristics.Insert(charac);
            }
        }

        static void deleteCharacteristic()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Characteristic> characteristics = new Repository<Characteristic>(context);
                Console.WriteLine();
                Console.WriteLine("Characteristic id: ");
                string enteredId = Console.ReadLine();
                if (enteredId != "")
                {
                    int id = Convert.ToInt32(enteredId);
                    var charc = characteristics.Get(id);
                    if (charc != null) characteristics.Delete(charc.Id);
                    Console.WriteLine("You deleted characteristic: " + charc.Name);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void updateCharacteristic()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Characteristic> characteristics = new Repository<Characteristic>(context);
                Repository<Resource> resources = new Repository<Resource>(context);
                Console.WriteLine();
                Console.WriteLine("Enter characteristic id: ");
                string enteredId = Console.ReadLine();
                if (enteredId != "")
                {
                    int id = Convert.ToInt32(enteredId);
                    var charac = characteristics.Get(id);
                    if (charac != null)
                    {
                        Console.WriteLine("Edit characteristic name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Edit charasteristic value: ");
                        string value = Console.ReadLine();
                        var resource = resources.Get(2);
                        charac.Name = name;
                        charac.Value = value;
                        charac.Resource = resource;
                        characteristics.Update(charac, charac.Id);
                    }
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        //CRUD methods for events
        static void showAllEvents()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Event> events = new Repository<Event>(context);
                var allEvents = events.Get().ToList();
                foreach (var e in allEvents)
                {
                    string start = printDate(e.EventStart);
                    string end = printDate(e.EventEnd);
                    Console.WriteLine(e.Id + " - " + e.EventTitle + " | " + e.User.FirstName + " | Resource: " +
                                      e.Resource.Name + " | Start: " + start + " | End: " + end);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static string printDate(DateTime date)
        {
            return date.Day + "/" + date.Month + "/" + date.Year;
        }

        static void showOneEvent()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Event> events = new Repository<Event>(context);
                Console.WriteLine("Enter event id: ");
                string enteredId = Console.ReadLine();
                if (enteredId != "")
                {
                    int id = Convert.ToInt32(enteredId);
                    var e = events.Get(id);
                    if (e != null)
                    {
                        string start = printDate(e.EventStart);
                        string end = printDate(e.EventEnd);
                        Console.WriteLine(e.Id + " - " + e.EventTitle + " | " + e.User.FirstName + " | Resource: " +
                                          e.Resource.Name + " | Start: " + start + " | End: " + end);
                    }
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void insertNewEvent()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Event> events = new Repository<Event>(context);
                Repository<Person> peoples = new Repository<Person>(context);
                Repository<Resource> resources = new Repository<Resource>(context);
                Console.WriteLine();
                Console.WriteLine("Event title: ");
                string title = Console.ReadLine();
                Console.WriteLine("Event start: --format is mm/dd/yyyy");
                DateTime start = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Event end: --format is mm/dd/yyyy");
                DateTime end = Convert.ToDateTime(Console.ReadLine());
                showAllResources();
                Console.WriteLine("Resource id: ");
                int idR = Convert.ToInt32(Console.ReadLine());
                var resource = resources.Get(idR);
                Console.WriteLine("Enter the User id: ");
                //showAllPeople(); - kad se uradi merge sa ostalim timovima
                int idU = Convert.ToInt32(Console.ReadLine());
                var user = peoples.Get(idU);
                if (user != null && resource != null && title != "")
                {
                    Event e = new Event()
                    {
                        EventTitle = title,
                        EventStart = start,
                        EventEnd = end,
                        Resource = resource,
                        User = user
                    };
                    events.Insert(e);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void updateEvent()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Event> events = new Repository<Event>(context);
                Repository<Person> peoples = new Repository<Person>(context);
                Repository<Resource> resources = new Repository<Resource>(context);
                Console.WriteLine();
                Console.WriteLine("Enter event id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var e = events.Get(id);
                if (e != null)
                {
                    Console.WriteLine("Edit event title: ");
                    string title = Console.ReadLine();
                    Console.WriteLine("Edit event start: --format is mm/dd/yyyy");
                    DateTime start = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Edit event end: --format is mm/dd/yyyy");
                    DateTime end = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Edit resource id: ");
                    showAllResources();
                    int idR = Convert.ToInt32(Console.ReadLine());
                    var resource = resources.Get(id);
                    Console.WriteLine("Edit user id: ");
                    //showAllPeople(); - kad se uradi merge sa ostalim timovima
                    int idU = Convert.ToInt32(Console.ReadLine());
                    var user = peoples.Get(idU);
                    e.EventTitle = title;
                    e.EventStart = start;
                    e.EventEnd = end;
                    e.Resource = resource;
                    e.User = user;
                    events.Update(e, e.Id);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void deleteEvent()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Event> events = new Repository<Event>(context);
                Console.WriteLine();
                Console.WriteLine("Event id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var e = events.Get(id);
                if (e != null)
                {
                    deleteExtendedEvents(e.Id);
                    events.Delete(e.Id);
                    Console.WriteLine("You deleted event: " + e.EventTitle);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        //CRUD methods for extended events

        static void showAllExtendedEvents()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<ExtendedEvent> extendedEvents = new Repository<ExtendedEvent>(context);
                Repository<Event> events = new Repository<Event>(context);
                var allExEvents = extendedEvents.Get().ToList();
                foreach (var e in allExEvents)
                {
                    string start = printDate(e.ParentEvent.EventStart);
                    string end = printDate(e.RepeatUntil);
                    Console.WriteLine(e.Id + " - " + e.ParentEvent.EventTitle + " | " + e.ParentEvent.User.FirstName +
                                      " | Resource: " + e.ParentEvent.Resource.Name + " | Start: " + start + " | End: " +
                                      end + " | Repeating type: " + e.RepeatingType + " | Frequency: " + e.Frequency);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void showOneExtendedEvent()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<ExtendedEvent> extendedEvents = new Repository<ExtendedEvent>(context);
                Repository<Event> events = new Repository<Event>(context);
                Console.WriteLine("Enter extended event id: ");
                string enteredId = Console.ReadLine();
                if (enteredId != "")
                {
                    int id = Convert.ToInt32(enteredId);
                    var e = extendedEvents.Get(id);
                    if (e != null)
                    {
                        string start = printDate(e.ParentEvent.EventStart);
                        string end = printDate(e.RepeatUntil);
                        Console.WriteLine(e.Id + " - " + e.ParentEvent.EventTitle + " | " + e.ParentEvent.User.FirstName +
                                          " | Resource: " + e.ParentEvent.Resource.Name + " | Start: " + start +
                                          " | End: " + end + " | Repeating type: " + e.RepeatingType + " | Frequency: " +
                                          e.Frequency);
                    }
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void insertNewExtendedEvent()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<ExtendedEvent> extendedEvents = new Repository<ExtendedEvent>(context);
                Repository<Event> events = new Repository<Event>(context);
                Console.WriteLine();
                Console.WriteLine("Enter parent event: ");
                int idEvent = Convert.ToInt32(Console.ReadLine());
                var parentEvent = events.Get(idEvent);
                Console.WriteLine("Repeat event until: --format is mm/dd/yyyy");
                DateTime until = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter repeating type [1 - daily, 2 - weekly, 3 - monthly]: ");
                string repeatingType = Console.ReadLine();
                Console.WriteLine("Enter frequency of repeating (number): ");
                int number = Convert.ToInt32(Console.ReadLine());
                if (parentEvent != null)
                {
                    ExtendedEvent e = new ExtendedEvent()
                    {
                        ParentEvent = parentEvent,
                        RepeatUntil = until,
                        RepeatingType = (RepeatType)Convert.ToInt32(repeatingType),
                        Frequency = number
                    };
                    extendedEvents.Insert(e);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void updateExtendedEvent()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<ExtendedEvent> extendedEvents = new Repository<ExtendedEvent>(context);
                Repository<Event> events = new Repository<Event>(context);
                Console.WriteLine();
                Console.WriteLine("Enter extended event id: ");
                int exEventId = Convert.ToInt32(Console.ReadLine());
                var exEvent = extendedEvents.Get(exEventId);
                if (exEvent != null)
                {
                    Console.WriteLine("Edit parent event: ");
                    int idEvent = Convert.ToInt32(Console.ReadLine());
                    var parentEvent = events.Get(idEvent);
                    Console.WriteLine("Edit repeat date until: --format is mm/dd/yyyy");
                    DateTime until = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Edit repeating type [1 - daily, 2 - weekly, 3 - monthly]: ");
                    string repeatingType = Console.ReadLine();
                    Console.WriteLine("Edit frequency of repeating (number): ");
                    int number = Convert.ToInt32(Console.ReadLine());
                    if (parentEvent != null) exEvent.ParentEvent = parentEvent;
                    exEvent.RepeatUntil = until;
                    exEvent.RepeatingType = (RepeatType)Convert.ToInt32(repeatingType);
                    exEvent.Frequency = number;
                    extendedEvents.Update(exEvent, exEvent.Id);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void deleteExtendedEvent()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<ExtendedEvent> extendedEvents = new Repository<ExtendedEvent>(context);
                Console.WriteLine();
                Console.WriteLine("Extended event id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var e = extendedEvents.Get(id);
                if (e != null)
                {
                    extendedEvents.Delete(e.Id);
                    Console.WriteLine("You deleted extended event: " + e.ParentEvent.EventTitle);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void deleteExtendedEvents(int Id)
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<ExtendedEvent> extendedEvents = new Repository<ExtendedEvent>(context);
                var allExEvents = extendedEvents.Get().ToList();
                var events = allExEvents.Where(x => x.ParentEvent.Id == Id);
                foreach (var e in events)
                {
                    extendedEvents.Delete(e.Id);
                }
            }
        }
    }
}

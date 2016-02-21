//using Database;
//using System;
//using System.Linq;

//namespace DataSeed
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string choice = "X";
//            do
//            {
//                Console.WriteLine("1. Educations");
//                Console.WriteLine("2. Skill Categories");
//                Console.WriteLine("3. Tools");
//                Console.WriteLine("9. END PROGRAM");
//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1": { educations(); break; }
//                    case "2": { skillCategories(); break; }
//                    case "3": { tools(); break; }
//                }
//            } while (choice != "9");
//        }


//        //Educations
//        static void educations()
//        {
//            string choice = "X";
//            do
//            {
//                Console.WriteLine("1. List educations");
//                Console.WriteLine("2. Insert educations");
//                Console.WriteLine("3. Edit educations");
//                Console.WriteLine("4. Delete educations");
//                Console.WriteLine("9. Return");
//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1": { listEducations(); break; }
//                    case "2": { insertEducations(); break; }
//                    case "3": { editEducations(); break; }
//                    case "4": { deleteEducations(); break; }
//                }
//            }
//            while (choice != "9");
//        }

//        static void listEducations()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<Education> educationUnit = new Repository<Education>();
//                var educations = educationUnit.Get().ToList();
//                foreach(var education in educations)
//                {
//                    Console.WriteLine(education.Id + ": " + education.Name + " - " + education.Type);
//                }
//            }
//            Console.WriteLine("--------------------");
//        }

//        static void insertEducations()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<Education> educationUnit = new Repository<Education>();
//                Console.WriteLine();
//                Console.Write("New name for the education: ");
//                string educationName = Console.ReadLine();
//                while (educationName == "")
//                {
//                    Console.Write("Please enter name for the education: ");
//                    educationName = Console.ReadLine();
//                }
//                Console.Write("Type [1 - School, 2 - Course, 3 - Certificates]: ");
//                string tip = Console.ReadLine();
//                Education education = new Education()
//                {
//                    Name = educationName,
//                    Type = (EducationType)Convert.ToInt32(tip)
//                };
//                educationUnit.Insert(education);
//            }
//            Console.WriteLine("DONE!");
//            Console.WriteLine("--------------------");
//        }

//        static void editEducations()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Education ID: ");
//            string eid = Console.ReadLine();
//            if (eid != "")
//            {
//                int id = Convert.ToInt32(eid);

//                using (SchoolContext context = new SchoolContext())
//                {
//                    Repository<Education> educationUnit = new Repository<Education>();
//                    var education = educationUnit.Get(id);
//                    if (education != null)
//                    {
//                        Console.Write("Edit Education name: ");
//                        education.Name = Console.ReadLine();
//                        Console.Write("Type [1 - School, 2 - Course, 3 - Certificates]: ");
//                        EducationType type = (EducationType)Convert.ToInt32(Console.ReadLine());
//                        education.Type = type;
//                        educationUnit.Update(education, id);
//                    }
//                }
//                Console.WriteLine("DONE!");
//                Console.WriteLine("--------------------");
//            }
//        }

//        static void deleteEducations()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Education ID: ");
//            string id = Console.ReadLine();
//            int eid = Convert.ToInt32(id);
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<Education> educationUnit = new Repository<Education>();
//                educationUnit.Delete(eid);
//            }
//            Console.WriteLine("You deleted education: " + id);
//            Console.WriteLine("----------------------");
//        }


//        //Skill Categories
//        static void skillCategories()
//        {
//            string choice = "X";
//            do
//            {
//                Console.WriteLine("1. List Skill Categories");
//                Console.WriteLine("2. Insert Skill Categories");
//                Console.WriteLine("3. Edit Skill Categories");
//                Console.WriteLine("4. Delete Skill Categories");
//                Console.WriteLine("9. Return");
//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1": { listSkillCategories(); break; }
//                    case "2": { insertSkillCategories(); break; }
//                    case "3": { editSkillCategories(); break; }
//                    case "4": { deleteSkillCategories(); break; }
//                }
//            }
//            while (choice != "9");
//        }

//        static void listSkillCategories()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<SkillCategory> skillCategoryUnit = new Repository<SkillCategory>();
//                var skillCategories = skillCategoryUnit.Get().ToList();
//                foreach (var skillCategory in skillCategories)
//                {
//                    Console.WriteLine(skillCategory.Id + ": " + skillCategory.Name);
//                }
//            }
//            Console.WriteLine("--------------------");
//        }

//        static void insertSkillCategories()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<SkillCategory> skillCategoryUnit = new Repository<SkillCategory>();
//                Console.WriteLine();
//                Console.Write("New name for the skill category: ");
//                string skillCategoryName = Console.ReadLine();
//                while (skillCategoryName == "")
//                {
//                    Console.Write("Please enter name for the skills category: ");
//                    skillCategoryName = Console.ReadLine();
//                }
//                SkillCategory skillCategory = new SkillCategory()
//                {
//                    Name = skillCategoryName
//                };
//                skillCategoryUnit.Insert(skillCategory);
//            }
//            Console.WriteLine("DONE!");
//            Console.WriteLine("--------------------");
//        }

//        static void editSkillCategories()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Skill Category ID: ");
//            string skid = Console.ReadLine();
//            if (skid != "")
//            {
//                int id = Convert.ToInt32(skid);
//                using (SchoolContext context = new SchoolContext())
//                {
//                    Repository<SkillCategory> skillCategoryUnit = new Repository<SkillCategory>();
//                    var skillCategory = skillCategoryUnit.Get(id);
//                    if (skillCategory != null)
//                    {
//                        Console.Write("Edit Skill Category name: ");
//                        skillCategory.Name = Console.ReadLine();
//                        skillCategoryUnit.Update(skillCategory, id);
//                    }
//                }
//                Console.WriteLine("DONE!");
//                Console.WriteLine("--------------------");
//            }
//        }

//        static void deleteSkillCategories()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Skill Category ID: ");
//            string skid = Console.ReadLine();
//            int id = Convert.ToInt32(skid);
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<SkillCategory> skillCategoryUnit = new Repository<SkillCategory>();
//                skillCategoryUnit.Delete(id);
//            }
//            Console.WriteLine("You deleted skill category: " + id);
//            Console.WriteLine("----------------------");
//        }


//        //Tools
//        static void tools()
//        {
//            string choice = "X";
//            do
//            {
//                Console.WriteLine("1. List Tools");
//                Console.WriteLine("2. Insert ToolS");
//                Console.WriteLine("3. Edit Tools");
//                Console.WriteLine("4. Delete Tools");
//                Console.WriteLine("9. Return");
//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1": { listTools(); break; }
//                    case "2": { addTools(); break; }
//                    case "3": { editTools(); break; }
//                    case "4": { deleteTools(); break; }
//                }
//            }
//            while (choice != "9");
//        }

//        static void listTools()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                ToolUnit toolUnit = new ToolUnit(context);
//                var tools = toolUnit.Get().ToList();
//                foreach (var tool in tools)
//                {
//                    Console.WriteLine(tool.Id + ": " + tool.Name + ": " + tool.Category.Name);
//                }
//            }
//            Console.WriteLine("DONE!");
//            Console.WriteLine("--------------------");
//        }

//        static void addTools()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                ToolUnit toolUnit = new ToolUnit(context);
//                Repository<SkillCategory> skillCategory = new Repository<SkillCategory>(context);

//                Console.WriteLine();
//                Console.Write("New name for the tool: ");
//                string toolName = Console.ReadLine();
//                while (toolName == "")
//                {
//                    Console.Write("Please enter name for the tool: ");
//                    toolName = Console.ReadLine();
//                }
//                Console.Write("Category: ");
//                int category = Convert.ToInt32(Console.ReadLine());
//                SkillCategory newSkillCategory = skillCategory.Get(category);

//                Tool tool = new Tool()
//                {
//                    Name = toolName,
//                    Category = newSkillCategory
//                };
//                toolUnit.Insert(tool);
//            }
//        }

//        static void editTools()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Tool ID: ");
//            string tid = Console.ReadLine();
//            if (tid != "")
//            {
//                int id = Convert.ToInt32(tid);
//                using (SchoolContext context = new SchoolContext())
//                {
//                    ToolUnit toolUnit = new ToolUnit(context);
//                    Repository<SkillCategory> skillCategory = new Repository<SkillCategory>(context);
//                    var tool = toolUnit.Get(id);
//                    Console.Write("Edit tool name: ");
//                    tool.Name = Console.ReadLine();
//                    Console.Write("Category: ");
//                    int category = Convert.ToInt32(Console.ReadLine());
//                    SkillCategory skCat = skillCategory.Get(category);
//                    tool.Category = skCat;
//                    toolUnit.Update(tool, id);
//                }
//                Console.WriteLine("DONE!");
//                Console.WriteLine("--------------------");
//            }
//        }

//        static void deleteTools()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Skill Category ID: ");
//            string tid = Console.ReadLine();
//            int id = Convert.ToInt32(tid);
//            using (SchoolContext context = new SchoolContext())
//            {
//                ToolUnit toolUnit = new ToolUnit(context);
//                toolUnit.Delete(id);
//            }
//            Console.WriteLine("You deleted tool: " + id);
//            Console.WriteLine("----------------------");
//        }
//    }
//}
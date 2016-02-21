using Database;
using System;
using System.Linq;

namespace DataSeed
{
    class Program_AlfaCRUD
    {
        static void Main(string[] args)
        {
            string choice = "X";
            do
            {
                Console.WriteLine("1. Educations");
                Console.WriteLine("2. Skill Categories");
                Console.WriteLine("3. Tools");
                Console.WriteLine("4. Employee skills");
                Console.WriteLine("5. Project skills");
                Console.WriteLine("6. Employee Education");
                Console.WriteLine("9. END PROGRAM");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": { educations(); break; }
                    case "2": { skillCategories(); break; }
                    case "3": { tools(); break; }
                    case "4": { employeeSkills(); break; }
                    case "5": { projectSkills(); break; }
                    case "6": { employeeEducation(); break; }
                }
            } while (choice != "9");
        }


        //Educations
        static void educations()
        {
            string choice = "X";
            do
            {
                Console.WriteLine("1. List educations");
                Console.WriteLine("2. Insert educations");
                Console.WriteLine("3. Edit educations");
                Console.WriteLine("4. Delete educations");
                Console.WriteLine("9. Return");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": { listEducations(); break; }
                    case "2": { insertEducations(); break; }
                    case "3": { editEducations(); break; }
                    case "4": { deleteEducations(); break; }
                }
            }
            while (choice != "9");
        }

        static void listEducations()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Education> educationUnit = new Repository<Education>(context);
                var educations = educationUnit.Get().ToList();
                foreach (var education in educations)
                {
                    Console.WriteLine(education.Id + ": " + education.Name + " - " + education.Type);
                }
            }
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }

        static void insertEducations()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Education> educationUnit = new Repository<Education>(context);
                Console.WriteLine();
                Console.Write("New name for the education: ");
                string educationName = Console.ReadLine();
                while (educationName == "")
                {
                    Console.Write("Please enter name for the education: ");
                    educationName = Console.ReadLine();
                }
                Console.Write("Type [1 - School, 2 - Course, 3 - Certificates]: ");
                string tip = Console.ReadLine();
                Education education = new Education()
                {
                    Name = educationName,
                    Type = (EducationType)Convert.ToInt32(tip)
                };
                educationUnit.Insert(education);
            }
            Console.WriteLine("DONE!");
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }

        static void editEducations()
        {
            Console.WriteLine();
            Console.WriteLine("Education ID: ");
            string eid = Console.ReadLine();
            if (eid != "")
            {
                int id = Convert.ToInt32(eid);

                using (SchoolContext context = new SchoolContext())
                {
                    Repository<Education> educationUnit = new Repository<Education>(context);
                    var education = educationUnit.Get(id);
                    if (education != null)
                    {
                        Console.Write("Edit Education name: ");
                        education.Name = Console.ReadLine();
                        Console.Write("Type [1 - School, 2 - Course, 3 - Certificates]: ");
                        EducationType type = (EducationType)Convert.ToInt32(Console.ReadLine());
                        education.Type = type;
                        educationUnit.Update(education, id);
                    }
                }
                Console.WriteLine("DONE!");
                Console.WriteLine("--------------------");
                Console.ReadKey();
            }
        }

        static void deleteEducations()
        {
            Console.WriteLine();
            Console.WriteLine("Education ID: ");
            string id = Console.ReadLine();
            int eid = Convert.ToInt32(id);
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Education> educationUnit = new Repository<Education>(context);
                educationUnit.Delete(eid);
            }
            Console.WriteLine("You deleted education: " + id);
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }


        //Skill Categories
        static void skillCategories()
        {
            string choice = "X";
            do
            {
                Console.WriteLine("1. List Skill Categories");
                Console.WriteLine("2. Insert Skill Categories");
                Console.WriteLine("3. Edit Skill Categories");
                Console.WriteLine("4. Delete Skill Categories");
                Console.WriteLine("9. Return");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": { listSkillCategories(); break; }
                    case "2": { insertSkillCategories(); break; }
                    case "3": { editSkillCategories(); break; }
                    case "4": { deleteSkillCategories(); break; }
                }
            }
            while (choice != "9");
        }

        static void listSkillCategories()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<SkillCategory> skillCategoryUnit = new Repository<SkillCategory>(context);
                var skillCategories = skillCategoryUnit.Get().ToList();
                foreach (var skillCategory in skillCategories)
                {
                    Console.WriteLine(skillCategory.Id + ": " + skillCategory.Name);
                }
            }
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }

        static void insertSkillCategories()
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<SkillCategory> skillCategoryUnit = new Repository<SkillCategory>(context);
                Console.WriteLine();
                Console.Write("New name for the skill category: ");
                string skillCategoryName = Console.ReadLine();
                while (skillCategoryName == "")
                {
                    Console.Write("Please enter name for the skills category: ");
                    skillCategoryName = Console.ReadLine();
                }
                SkillCategory skillCategory = new SkillCategory()
                {
                    Name = skillCategoryName
                };
                skillCategoryUnit.Insert(skillCategory);
            }
            Console.WriteLine("DONE!");
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }

        static void editSkillCategories()
        {
            Console.WriteLine();
            Console.WriteLine("Skill Category ID: ");
            string skid = Console.ReadLine();
            if (skid != "")
            {
                int id = Convert.ToInt32(skid);
                using (SchoolContext context = new SchoolContext())
                {
                    Repository<SkillCategory> skillCategoryUnit = new Repository<SkillCategory>(context);
                    var skillCategory = skillCategoryUnit.Get(id);
                    if (skillCategory != null)
                    {
                        Console.Write("Edit Skill Category name: ");
                        skillCategory.Name = Console.ReadLine();
                        skillCategoryUnit.Update(skillCategory, id);
                    }
                }
                Console.WriteLine("DONE!");
                Console.WriteLine("--------------------");
                Console.ReadKey();
            }
        }

        static void deleteSkillCategories()
        {
            Console.WriteLine();
            Console.WriteLine("Skill Category ID: ");
            string skid = Console.ReadLine();
            int id = Convert.ToInt32(skid);
            using (SchoolContext context = new SchoolContext())
            {
                Repository<SkillCategory> skillCategoryUnit = new Repository<SkillCategory>(context);
                skillCategoryUnit.Delete(id);
            }
            Console.WriteLine("You deleted skill category: " + id);
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }


        //Tools
        static void tools()
        {
            string choice = "X";
            do
            {
                Console.WriteLine("1. List Tools");
                Console.WriteLine("2. Insert ToolS");
                Console.WriteLine("3. Edit Tools");
                Console.WriteLine("4. Delete Tools");
                Console.WriteLine("9. Return");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": { listTools(); break; }
                    case "2": { addTools(); break; }
                    case "3": { editTools(); break; }
                    case "4": { deleteTools(); break; }
                }
            }
            while (choice != "9");
        }

        static void listTools()
        {
            using (SchoolContext context = new SchoolContext())
            {
                ToolUnit toolUnit = new ToolUnit(context);
                var tools = toolUnit.Get().ToList();
                foreach (var tool in tools)
                {
                    Console.WriteLine(tool.Id + ": " + tool.Name + ": " + tool.Category.Name);
                }
            }
            Console.WriteLine("DONE!");
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }

        static void addTools()
        {
            using (SchoolContext context = new SchoolContext())
            {
                ToolUnit toolUnit = new ToolUnit(context);
                Repository<SkillCategory> skillCategory = new Repository<SkillCategory>(context);

                Console.WriteLine();
                Console.Write("New name for the tool: ");
                string toolName = Console.ReadLine();
                while (toolName == "")
                {
                    Console.Write("Please enter name for the tool: ");
                    toolName = Console.ReadLine();
                }
                Console.Write("Category: ");
                int category = Convert.ToInt32(Console.ReadLine());
                SkillCategory newSkillCategory = skillCategory.Get(category);

                Tool tool = new Tool()
                {
                    Name = toolName,
                    Category = newSkillCategory
                };
                toolUnit.Insert(tool);
            }
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }

        static void editTools()
        {
            Console.WriteLine();
            Console.WriteLine("Tool ID: ");
            string tid = Console.ReadLine();
            if (tid != "")
            {
                int id = Convert.ToInt32(tid);
                using (SchoolContext context = new SchoolContext())
                {
                    ToolUnit toolUnit = new ToolUnit(context);
                    Repository<SkillCategory> skillCategory = new Repository<SkillCategory>(context);
                    var tool = toolUnit.Get(id);
                    Console.Write("Edit tool name: ");
                    tool.Name = Console.ReadLine();
                    Console.Write("Category: ");
                    int category = Convert.ToInt32(Console.ReadLine());
                    SkillCategory skCat = skillCategory.Get(category);
                    tool.Category = skCat;
                    toolUnit.Update(tool, id);
                }
                Console.WriteLine("DONE!");
                Console.WriteLine("--------------------");
                Console.ReadKey();
            }
        }

        static void deleteTools()
        {
            Console.WriteLine();
            Console.WriteLine("Skill Category ID: ");
            string tid = Console.ReadLine();
            int id = Convert.ToInt32(tid);
            using (SchoolContext context = new SchoolContext())
            {
                ToolUnit toolUnit = new ToolUnit(context);
                toolUnit.Delete(id);
            }
            Console.WriteLine("You deleted tool: " + id);
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }


        //Employee Skills
        static void employeeSkills()
        {
            string choice = "X";
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Show employee skills");
                Console.WriteLine("2. Show one employee skill");
                Console.WriteLine("3. Add new skill to employee");
                Console.WriteLine("4. Delete employee skill");
                Console.WriteLine("5. Update employee skill");
                Console.WriteLine("9. Return");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": { printAllEmployeeSkills(); break; }
                    case "2": { printOneEmployeeSkill(); break; }
                    case "3": { insertEmployeeSkill(); break; }
                    case "4": { deleteEmployeeSkill(); break; }
                    case "5": { updateEmployeeSkill(); break; }
                }
            } while (choice != "9");
        }

        static void printAllEmployeeSkills()
        {
            using (SchoolContext context = new SchoolContext())
            {
                EmployeeSkillUnit employeeSkillUnit = new EmployeeSkillUnit(context);
                var employeeSkills = employeeSkillUnit.Get().ToList();
                foreach (var employeeSkill in employeeSkills)
                {
                    Console.WriteLine(employeeSkill.Id + " " + employeeSkill.Employee.FirstName + ": " + employeeSkill.Tool.Name);
                }
            }
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }

        static void printOneEmployeeSkill()
        {
            Console.WriteLine();
            Console.Write("Insert identification: ");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);

                using (SchoolContext context = new SchoolContext())
                {
                    EmployeeSkillUnit employeeSkillUnit = new EmployeeSkillUnit(context);
                    var employeeSkill = employeeSkillUnit.Get(id);
                    if (employeeSkill != null)
                    {
                        Console.WriteLine(employeeSkill.Id + "  " + employeeSkill.Employee.FirstName + " : " + employeeSkill.Tool.Name + "  Level: " + employeeSkill.Level + "  Experience: " + employeeSkill.Experience);
                        Console.WriteLine("--------------------");
                        Console.ReadKey();
                    }
                }
            }
        }

        static void insertEmployeeSkill()
        {
            Person employee = null;
            Tool tool = null;

            using (SchoolContext context = new SchoolContext())
            {
                EmployeeSkillUnit employeeSkillUnit = new EmployeeSkillUnit(context);
                Repository<Person> employeeUnit = new Repository<Person>(context);
                Repository<Tool> toolUnit = new Repository<Tool>(context);

                do
                {
                    Console.WriteLine();
                    Console.Write("Employee Id: ");
                    int empId = Convert.ToInt32(Console.ReadLine());

                    employee = employeeUnit.Get(empId);
                    if (employee == null)
                    {
                        Console.WriteLine("Employee with id " + empId + " does not exist, please enter another id.");
                    }
                    else
                    {
                        Console.WriteLine(employee.FirstName);
                    }
                } while (employee == null);

                do
                {
                    Console.WriteLine();
                    Console.Write("Tool Id: ");
                    int toolId = Convert.ToInt32(Console.ReadLine());

                    tool = toolUnit.Get(toolId);
                    if (tool == null)
                    {
                        Console.WriteLine("Tool with id " + toolId + " does not exist, please enter another id.");
                    }
                    else
                    {
                        Console.WriteLine(tool.Name);
                    }
                } while (tool == null);

                EmployeeSkill empSkill = new EmployeeSkill()
                {
                    Employee = employee,
                    Tool = tool,
                    Level = Level.BasicCapability,
                    Experience = 1
                };

                employeeSkillUnit.Insert(empSkill);
            }
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }

        static void deleteEmployeeSkill()
        {
            Console.WriteLine();
            Console.Write("Insert identification of employeeSkill you want to delete: ");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);

                using (SchoolContext context = new SchoolContext())
                {
                    EmployeeSkillUnit employeeSkillUnit = new EmployeeSkillUnit(context);
                    employeeSkillUnit.Delete(id);
                    Console.WriteLine("You have deleted the employee skill with id: " + sid);
                    Console.WriteLine("--------------------");
                    Console.ReadKey();
                }
            }
        }

        static void updateEmployeeSkill()
        {
            Console.WriteLine();
            Console.Write("Insert identification of employeeSkill you want to edit: ");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);

                Console.WriteLine();
                Console.Write("Insert new level for employee skill " + sid + "  ");
                string sLevel = Console.ReadLine();

                Console.WriteLine();
                Console.Write("Insert new experience for employee skill " + sid + " ");
                string sExp = Console.ReadLine();

                if (sLevel != "" && sExp != "")
                {
                    int level = Convert.ToInt32(sLevel);
                    int experience = Convert.ToInt32(sExp);

                    using (SchoolContext context = new SchoolContext())
                    {
                        EmployeeSkillUnit employeeSkillUnit = new EmployeeSkillUnit(context);
                        var selectedEmpSkill = employeeSkillUnit.Get(id);

                        if (selectedEmpSkill != null)
                        {
                            selectedEmpSkill.Level = (Level)level;
                            selectedEmpSkill.Experience = experience;
                        }

                        employeeSkillUnit.Update(selectedEmpSkill, id);
                        Console.WriteLine("Edited!");
                        Console.WriteLine("--------------------");
                        Console.ReadKey();
                    }
                }
            }
        }


        //Project Skills
        static void projectSkills()
        {
            string choice = "X";
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Show project skills");
                Console.WriteLine("2. Show one project skill");
                Console.WriteLine("3. Add new skill to project");
                Console.WriteLine("4. Delete project skill");
                Console.WriteLine("5. Update project skill");
                Console.WriteLine("9. Return");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": { printAllProjectSkills(); break; }
                    case "2": { printOneProjectSkill(); break; }
                    case "3": { insertProjectSkill(); break; }
                    case "4": { deleteProjectSkill(); break; }
                    case "5": { updateProjectSkill(); break; }
                }
            } while (choice != "9");
        }

        static void printAllProjectSkills()
        {
            using (SchoolContext context = new SchoolContext())
            {
                ProjectSkillUnit projectSkillUnit = new ProjectSkillUnit(context);
                var projectSkills = projectSkillUnit.Get().ToList();
                foreach (var projectSkill in projectSkills)
                {
                    Console.WriteLine(projectSkill.Id + " " + projectSkill.Team.Description + ": " + projectSkill.Tool.Name);
                }
            }
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }

        static void printOneProjectSkill()
        {
            Console.WriteLine();
            Console.Write("Insert identification: ");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);

                using (SchoolContext context = new SchoolContext())
                {
                    ProjectSkillUnit projectSkillUnit = new ProjectSkillUnit(context);
                    var projectSkills = projectSkillUnit.Get(id);
                    if (projectSkills != null)
                    {
                        Console.WriteLine(projectSkills.Id + "  " + projectSkills.Team.Name + " : " + "  " + projectSkills.Team.Description + " : " + projectSkills.Tool.Name + "  Level: " + projectSkills.Level);
                        Console.WriteLine("--------------------");
                        Console.ReadKey();
                    }
                }
            }
        }

        static void insertProjectSkill()
        {
            Team team = null;
            Tool tool = null;

            using (SchoolContext context = new SchoolContext())
            {
                ProjectSkillUnit projectSkillUnit = new ProjectSkillUnit(context);
                Repository<Team> teamUnit = new Repository<Team>(context);
                Repository<Tool> toolUnit = new Repository<Tool>(context);

                do
                {
                    Console.WriteLine();
                    Console.Write("Team Id: ");
                    int teamId = Convert.ToInt32(Console.ReadLine());

                    team = teamUnit.Get(teamId);
                    if (team == null)
                    {
                        Console.WriteLine("Team with id " + teamId + " does not exist, please enter another id.");
                    }
                    else
                    {
                        Console.WriteLine(team.Description);
                    }
                } while (team == null);

                do
                {
                    Console.WriteLine();
                    Console.Write("Tool Id: ");
                    int toolId = Convert.ToInt32(Console.ReadLine());

                    tool = toolUnit.Get(toolId);
                    if (tool == null)
                    {
                        Console.WriteLine("Tool with id " + toolId + " does not exist, please enter another id.");
                    }
                    else
                    {
                        Console.WriteLine(tool.Name);
                    }
                } while (tool == null);

                ProjectSkill projSkill = new ProjectSkill()
                {
                    Team = team,
                    Tool = tool,
                    Level = Level.BasicCapability
                };

                projectSkillUnit.Insert(projSkill);
            }
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }

        static void deleteProjectSkill()
        {
            Console.WriteLine();
            Console.Write("Insert identification of projectSkill you want to delete: ");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);

                using (SchoolContext context = new SchoolContext())
                {
                    ProjectSkillUnit projectSkillUnit = new ProjectSkillUnit(context);
                    projectSkillUnit.Delete(id);
                    Console.WriteLine("You have deleted the project skill with id: " + sid);
                    Console.WriteLine("--------------------");
                    Console.ReadKey();
                }
            }
        }

        static void updateProjectSkill()
        {
            Console.WriteLine();
            Console.Write("Insert identification of projectSkill you want to edit: ");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);

                Console.WriteLine();
                Console.Write("Insert new level for project skill " + sid + "  ");
                string sLevel = Console.ReadLine();

                if (sLevel != "")
                {
                    int level = Convert.ToInt32(sLevel);

                    using (SchoolContext context = new SchoolContext())
                    {
                        ProjectSkillUnit projectSkillUnit = new ProjectSkillUnit(context);
                        var selectedProjSkill = projectSkillUnit.Get(id);

                        if (selectedProjSkill != null)
                        {
                            selectedProjSkill.Level = (Level)level;
                        }

                        projectSkillUnit.Update(selectedProjSkill, id);
                        Console.WriteLine("Edited!");
                        Console.WriteLine("--------------------");
                        Console.ReadKey();
                    }
                }
            }
        }


        //Employee Education
        static void employeeEducation()
        {
            string choice = "X";
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Show employee educations");
                Console.WriteLine("2. Show one employee education");
                Console.WriteLine("3. Add new education to employee");
                Console.WriteLine("4. Delete employee education");
                Console.WriteLine("5. Update employee education");
                Console.WriteLine("9. Return");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": { printAllEmployeeEducations(); break; }
                    case "2": { printOneEmployeeEducation(); break; }
                    case "3": { insertEmployeeEducation(); break; }
                    case "4": { deleteEmployeeEducation(); break; }
                    case "5": { updateEmployeeEducation(); break; }
                }
            } while (choice != "9");
        }

        static void printAllEmployeeEducations()
        {
            using (SchoolContext context = new SchoolContext())
            {
                EmployeeEducationUnit employeeEducationUnit = new EmployeeEducationUnit(context);
                var employeeEducations = employeeEducationUnit.Get().ToList();
                foreach (var employeeEducation in employeeEducations)
                {
                    Console.WriteLine(employeeEducation.Id + " " + employeeEducation.Employee.FirstName + ": " + employeeEducation.Education.Name +"   Reference:  "+employeeEducation.Reference);
                }
            }
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }

        static void printOneEmployeeEducation()
        {
            Console.WriteLine();
            Console.Write("Insert identification: ");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);

                using (SchoolContext context = new SchoolContext())
                {
                    EmployeeEducationUnit employeeEducationUnit = new EmployeeEducationUnit(context);
                    var employeeEducation = employeeEducationUnit.Get(id);
                    if (employeeEducation != null)
                    {
                        Console.WriteLine(employeeEducation.Id + " " + employeeEducation.Employee.FirstName + ": " + employeeEducation.Education.Name + "   Reference:  " + employeeEducation.Reference);
                        Console.WriteLine("--------------------");
                        Console.ReadKey();
                    }
                }
            }
        }

        static void insertEmployeeEducation()
        {
            Person employee = null;
            Education education = null;

            using (SchoolContext context = new SchoolContext())
            {
                EmployeeEducationUnit employeeEducationUnit = new EmployeeEducationUnit(context);
                Repository<Person> employeeUnit = new Repository<Person>(context);
                Repository<Education> educationUnit = new Repository<Education>(context);

                do
                {
                    Console.WriteLine();
                    Console.Write("Employee Id: ");
                    int empId = Convert.ToInt32(Console.ReadLine());

                    employee = employeeUnit.Get(empId);
                    if (employee == null)
                    {
                        Console.WriteLine("Employee with id " + empId + " does not exist, please enter another id.");
                    }
                    else
                    {
                        Console.WriteLine(employee.FirstName);
                    }
                } while (employee == null);

                do
                {
                    Console.WriteLine();
                    Console.Write("Education Id: ");
                    int eduId = Convert.ToInt32(Console.ReadLine());

                    education = educationUnit.Get(eduId);
                    if (education == null)
                    {
                        Console.WriteLine("Educatiom with id " + eduId + " does not exist, please enter another id.");
                    }
                    else
                    {
                        Console.WriteLine(education.Name);
                    }
                } while (education == null);

                EmployeeEducation empEdu = new EmployeeEducation()
                {
                    Employee = employee,
                    Education = education,
                    Reference = "htttp://somereference"
                };

                employeeEducationUnit.Insert(empEdu);
            }
            Console.WriteLine("--------------------");
            Console.ReadKey();
        }

        static void deleteEmployeeEducation()
        {
            Console.WriteLine();
            Console.Write("Insert identification of employee education you want to delete: ");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);

                using (SchoolContext context = new SchoolContext())
                {
                    EmployeeEducationUnit employeeEducationUnit = new EmployeeEducationUnit(context);
                    employeeEducationUnit.Delete(id);
                    Console.WriteLine("You have deleted the employee education with id: " + sid);
                    Console.WriteLine("--------------------");
                    Console.ReadKey();
                }
            }
        }

        static void updateEmployeeEducation()
        {
            Console.WriteLine();
            Console.Write("Insert identification of employee education you want to edit: ");
            string sid = Console.ReadLine();
            if (sid != "")
            {
                int id = Convert.ToInt32(sid);

                Console.WriteLine();
                Console.Write("Insert new reference for employee education " + sid + "  ");
                string newReference = Console.ReadLine();

                if (newReference != "")
                {
                    using (SchoolContext context = new SchoolContext())
                    {
                        EmployeeEducationUnit empEduUnit = new EmployeeEducationUnit(context);
                        var selectedEmpEdu = empEduUnit.Get(id);

                        if (selectedEmpEdu != null)
                        {
                            selectedEmpEdu.Reference = newReference;
                        }

                        empEduUnit.Update(selectedEmpEdu, id);
                        Console.WriteLine("Edited!");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}

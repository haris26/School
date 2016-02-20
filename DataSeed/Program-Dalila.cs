using Database;
using System;
using System.Linq;

namespace DataSeed
{
    class Program_Dalila
    {
        static void Main(string[] args)
        {
            string choice = "X";
            do
            {
                Console.WriteLine("4. Employee skills");
                Console.WriteLine("5. Project skills");
                Console.WriteLine("6. Employee Education");
                Console.WriteLine("9. End of program");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "4": { employeeSkills(); break; }
                    case "5": { projectSkills(); break; }
                    case "6": { employeeEducation(); break; }
                }
            } while (choice != "9");
        }


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
                //Console.WriteLine("5. Update employee education");
                Console.WriteLine("9. Return");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": { printAllEmployeeEducations(); break; }
                    case "2": { printOneEmployeeEducation(); break; }
                    case "3": { insertEmployeeEducation(); break; }
                    case "4": { deleteEmployeeEducation(); break; }
                    //case "5": { updateEmployeeEducation(); break; }
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
                        Console.WriteLine(employeeSkill.Id + "  " + employeeSkill.Employee.FirstName + " : " + employeeSkill.Tool.Name +"  Level: "+employeeSkill.Level+"  Experience: "+employeeSkill.Experience);
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
                    Console.WriteLine("You have deleted the employee skill with id: "+sid);
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
                Console.Write("Insert new level for employee skill "+ sid +"  ");
                string sLevel = Console.ReadLine();

                Console.WriteLine();
                Console.Write("Insert new experience for employee skill " + sid + " ");
                string sExp = Console.ReadLine();

                if (sLevel != "" && sExp!="")
                {
                    int level = Convert.ToInt32(sLevel);
                    int experience = Convert.ToInt32(sExp);

                    using (SchoolContext context = new SchoolContext())
                    {
                        EmployeeSkillUnit employeeSkillUnit = new EmployeeSkillUnit(context);
                        var selectedEmpSkill = employeeSkillUnit.Get(id);

                        if (selectedEmpSkill!= null)
                        {
                            selectedEmpSkill.Level = (Level)level;
                            selectedEmpSkill.Experience = experience;
                        }

                        employeeSkillUnit.Update(selectedEmpSkill, id);
                        Console.WriteLine("Edited!");
                        Console.ReadKey();
                    }
                }
            }
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
                        Console.ReadKey();
                    }
                }
            }
        }


        static void printAllEmployeeEducations()
        {
            using (SchoolContext context = new SchoolContext())
            {
                EmployeeEducationUnit employeeEducationUnit = new EmployeeEducationUnit(context);
                var employeeEducations = employeeEducationUnit.Get().ToList();
                foreach (var employeeEducation in employeeEducations)
                {
                    Console.WriteLine(employeeEducation.Id + " " + employeeEducation.Employee.FirstName + ": " + employeeEducation.Education.Name);
                }
            }
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
                        Console.WriteLine(employeeEducation.Id + " " + employeeEducation.Employee.FirstName + ": " + employeeEducation.Education.Name);
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
                    Education = education
                };

                employeeEducationUnit.Insert(empEdu);
            }
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
                    Console.ReadKey();
                }
            }
        }

        //static void updateEmployeeEducation()
        //{
        //    Console.WriteLine();
        //    Console.Write("Insert identification of projectSkill you want to edit: ");
        //    string sid = Console.ReadLine();
        //    if (sid != "")
        //    {
        //        int id = Convert.ToInt32(sid);

        //        Console.WriteLine();
        //        Console.Write("Insert new level for project skill " + sid + "  ");
        //        string sLevel = Console.ReadLine();

        //        if (sLevel != "")
        //        {
        //            int level = Convert.ToInt32(sLevel);

        //            using (SchoolContext context = new SchoolContext())
        //            {
        //                ProjectSkillUnit projectSkillUnit = new ProjectSkillUnit(context);
        //                var selectedProjSkill = projectSkillUnit.Get(id);

        //                if (selectedProjSkill != null)
        //                {
        //                    selectedProjSkill.Level = (Level)level;
        //                }

        //                projectSkillUnit.Update(selectedProjSkill, id);
        //                Console.WriteLine("Edited!");
        //                Console.ReadKey();
        //            }
        //        }
        //    }
        //}
    }
}
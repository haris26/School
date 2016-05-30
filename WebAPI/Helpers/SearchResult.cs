using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using Database;

namespace WebAPI.Helpers
{
    public static class SearchResult
    {
        public static ResultModel Create(SchoolContext context, SearchModel search)
        {
            ResultModel result = new ResultModel();
            result.ExactMatches = GetExactMatches(context, search);

            //get list of employee ids that are already in exact matches
            var exactMatchesIds = result.ExactMatches.Select(x => x.EmployeeId).ToList();

            result.CloseMatches = GetCloseMatches(context, search, exactMatchesIds);

            return result;
        }

        public static List<EmployeeResultModel> GetCloseMatches (SchoolContext context, SearchModel search, List<int> exactMatches)
        {
            List<int> searchedSkills = search.QueriedSkills.Select(x => x.Id).ToList();

             var closeMatches = context.EmployeeSkills.Where(x => searchedSkills.Contains(x.Tool.Id) && !exactMatches.Contains(x.Employee.Id)).ToList()
                                             .GroupBy(x => x.Employee)
                                             .Select(x => CreateEmployeeResultModel(x, search.QueriedEducations.Count()))
                                             .OrderByDescending(x => x.Skills.Count())
                                             .ThenByDescending(x => x.Skills[0].Level)
                                             .ToList();

            return closeMatches;
        }

        public static List<EmployeeResultModel> GetExactMatches(SchoolContext context, SearchModel search)
        {
            List<EmployeeResultModel> exactMatches = new List<EmployeeResultModel>();
            Dictionary<int, Person> employees = new Dictionary<int, Person>();
            Dictionary<int, List<EmployeeSkill>> employeeSkills = new Dictionary<int, List<EmployeeSkill>>();
            List<int> employeesToRemove = new List<int>();

            //if any skills were chosen in the query
            if (search.QueriedSkills.Count > 0)
            {
                var firstCondition = search.QueriedSkills[0];
                //get all employees that match the first condition
                employees = context.EmployeeSkills.Where(x => x.Tool.Id == firstCondition.Id &&
                                                              (int)x.Level >= firstCondition.Level &&
                                                              x.Experience >= firstCondition.Experience).ToList()
                                                  .GroupBy(x => x.Employee)
                                                  .Select(x => x.Key)
                                                  .ToDictionary(x => x.Id);

                //for each employee that matches the first condition
                foreach (var employee in employees)
                {
                    EmployeeSkill searchedSkill = null;
                    int currentEmployee = employee.Key;
                    employeeSkills.Add(currentEmployee, new List<EmployeeSkill>());

                    //get the skills of that employee that are last approved by a supervisor
                    var currentSkills = GetCurrentSkills(employee.Value);
                    //get educations of employee (list of ids)
                    var educations = employee.Value.EmployeeEducations
                                             .Select(x => x.Education.Id)
                                             .ToList();

                    //for each remaining skill in the query, check if the current skills contain that skill
                    foreach (var skill in search.QueriedSkills)
                    {
                        searchedSkill = currentSkills.Where(x => x.Tool.Id == skill.Id &&
                                                                 (int)x.Level >= skill.Level &&
                                                                 x.Experience >= skill.Experience).FirstOrDefault();

                        //if skill is not present, remove the employee from the list of employees 
                        //that match the search condition and exit the skills loop 
                        if (searchedSkill == null)
                        {
                            employeesToRemove.Add(currentEmployee);
                            break;
                        }
                        //if the employee has that skill, add it to the list of his/her skills that need to be displayed
                        else
                            employeeSkills[currentEmployee].Add(searchedSkill);

                    }

                    //if the employee has passed all checks for rewuired skills, check his / her educations
                    if (!employeesToRemove.Contains(currentEmployee))
                    {
                        //if the employees educations don't contain some of the queried educations, delete employee
                        if (!search.QueriedEducations.All(i => educations.Contains(i)))
                        {
                            employeesToRemove.Add(currentEmployee);
                        }
                    }
                }

                //remove all employees from the employee dictionary that didn't match any subsequent criteria
                foreach (var person in employeesToRemove)
                {
                    employees.Remove(person);
                }

                exactMatches = employees.Select(x => CreateEmployeeResultModel(x.Value, employeeSkills[x.Value.Id], search.QueriedEducations)).ToList();
            }


            //else, if no skills were chosen but only educations
            else if (search.QueriedEducations.Count() > 0)
            {
                var firstCondition = search.QueriedEducations[0];
                //get all employees that match the first condition
                employees = context.EmployeeEducations.Where(x => x.Education.Id == firstCondition).ToList()
                                                  .GroupBy(x => x.Employee)
                                                  .Select(x => x.Key)
                                                  .ToDictionary(x => x.Id);

                //for each employee, check if they also match other conditions
                foreach (var employee in employees)
                {
                    //get educations of employee (list of ids)
                    var educations = employee.Value.EmployeeEducations
                                             .Select(x => x.Education.Id)
                                             .ToList();

                    //if the employees educations don't contain some of the queried education, delete employee
                    if (!search.QueriedEducations.All(i => educations.Contains(i)))
                    {
                        employeesToRemove.Add(employee.Value.Id);
                    }
                }

                //remove all employees from the employee dictionary that didn't match any subsequent criteria
                foreach (var person in employeesToRemove)
                {
                    employees.Remove(person);
                }

                //indicate that no skills were passed for search
                List<EmployeeSkill> searchedSkills = new List<EmployeeSkill>();
                exactMatches = employees.Select(x => CreateEmployeeResultModel(x.Value, searchedSkills, search.QueriedEducations)).ToList();
            }
            return exactMatches;
        }

        //for exact matches
        public static EmployeeResultModel CreateEmployeeResultModel(Person person, List<EmployeeSkill> searchedSkills, IList<int> searchedEducations)
        {
            EmployeeResultModel employee = new EmployeeResultModel()
            {
                 EmployeeId = person.Id,
                 FullName = person.FullName
            };

            employee.Skills = searchedSkills.Select(x => EmployeeSummary.CreateEmployeeSkillDetail(x)).ToList();
            employee.Educations = person.EmployeeEducations.Where(x => searchedEducations.Contains(x.Education.Id)).ToList()
                                                           .Select(x => new EmployeeEducationDetail()
                                                                            { Qualification = x.Education.Name,
                                                                              Reference = x.Reference })
                                                           .ToList();

            employee.Engagements = person.Roles.Where(x => x.EndDate == null && x.Time > 0).ToList()
                                               .Select(x => EmployeeSummary.CreateEngagementDetail(x)).ToList();

            return employee;
        }

        //for close matches
        public static EmployeeResultModel CreateEmployeeResultModel(IGrouping<Person, EmployeeSkill> employeeSkills, int queriedEducations)
        {
            EmployeeResultModel employee = new EmployeeResultModel()
            {
                EmployeeId = employeeSkills.Key.Id,
                FullName = employeeSkills.Key.FullName
            };

            employee.Skills = GetCurrentSkills(employeeSkills.ToList());
            employee.Engagements = employeeSkills.Key.Roles.Where(x => x.EndDate == null && x.Time > 0).ToList()
                                   .Select(x => EmployeeSummary.CreateEngagementDetail(x)).ToList();
            if (queriedEducations != 0)
            {
                employee.Educations = employeeSkills.Key.EmployeeEducations.ToList()
                                                              .Select(x => new EmployeeEducationDetail()
                                                              {
                                                                  Qualification = x.Education.Name,
                                                                  Reference = x.Reference
                                                              })
                                                              .ToList();
            }
            return employee;
        }

        //get all current skills of a person 
        public static List<EmployeeSkill> GetCurrentSkills(Person person)
        {
            var currentSkills = person.EmployeeSkills.Where(x => x.AssessedBy == AssessmentType.Supervisor)
                                      .GroupBy(x => x.Tool)
                                      .Select(x => x.ToList().Where(y => y.AssessedBy == AssessmentType.Supervisor)
                                                             .OrderByDescending(y => y.DateOfSupervisorAssessment)
                                                             .FirstOrDefault()).ToList();
            return currentSkills;
        }

        //get current skills from a list of skill assessments
        public static List<EmployeeSkillDetail> GetCurrentSkills(List<EmployeeSkill> employeeSkills)
        {
            var currentSkills = employeeSkills.GroupBy(x => x.Tool)
                                              .Select(x => x.ToList().Where(y => y.AssessedBy == AssessmentType.Supervisor)
                                              .OrderByDescending(y => y.DateOfSupervisorAssessment)
                                              .FirstOrDefault()).Select(x => EmployeeSummary.CreateEmployeeSkillDetail(x)).ToList();
            return currentSkills;
        }
    }
}
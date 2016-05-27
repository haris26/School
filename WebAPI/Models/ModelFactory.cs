using Database;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Models
{
    public class ModelFactory
    {
        public TeamModel Create(Team team)
        {
            TeamModel model = new TeamModel()
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                Type = team.Type.ToString()
            };
            foreach (var person in team.Roles)
            {
                model.Members.Add(new MemberModel() { Name = person.Person.FirstName + " " + person.Person.LastName, Role = person.Role.Name });
            }
            return model;
        }

        public RoleModel Create(Role role)
        {
            return new RoleModel()
            {
                Id = role.Id,
                Name = role.Name,
                Count = role.Roles.Count
            };
        }

        public ToolModel Create(Tool tool)
        {
            return new ToolModel()
            {
                Id = tool.Id,
                Name = tool.Name,
                Category = tool.Category.Id,
                CategoryName = tool.Category.Name,
                NumOfEmployees = tool.EmployeeSkills.ToList().Count()
            };
        }

        public SkillCategoryModel Create(SkillCategory category)
        {
            SkillCategoryModel model = new SkillCategoryModel()
            {
                Id = category.Id,
                Name = category.Name,
            };

            foreach (var tool in category.Tools)
            {
                model.Tools.Add(Create(tool));
            }

            return model;
        }

        public EducationModel Create (Education education)
        {
            return new EducationModel()
            {
                Id = education.Id,
                Name = education.Name,
                Type = education.Type,
                NumOfEmployees = education.EmployeeEducation.ToList().Count()
            };
        }

        public PersonModel Create (Person person)
        {
            return new PersonModel()
            {
                Id =person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
        }

        public EmployeeEducationModel Create(EmployeeEducation employeeEducation)
        {
            return new EmployeeEducationModel()
            {
                Id = employeeEducation.Id,
                Employee = employeeEducation.Employee.Id,
                EducationName = employeeEducation.Education.Name,
                Education = employeeEducation.Education.Id,
                Type = employeeEducation.Education.Type,
                Reference = employeeEducation.Reference
            };
        }

        public TokenModel Create(AuthToken token)
        {
            return new TokenModel()
            {
                Token = token.Token,
                Expiration = token.Expiration
            };
        }

        public EducationCategoryModel Create(IGrouping<EducationType, Education> educations)
        {
            Dictionary<int, string> educationNames = new Dictionary<int, string>();
            educationNames.Add(1, "Formal Education");
            educationNames.Add(2, "Courses");
            educationNames.Add(3, "Certificates");

            EducationCategoryModel model = new EducationCategoryModel()
            {
                Id = (int)educations.Key,
                Name = educationNames[(int)educations.Key]
            };

            foreach (var education in educations.ToList())
            {
                model.Educations.Add(Create(education));
            }

            return model;
        }
        public EmployeeNotificationModel Create(EmployeeNotification employeeNotification)
        {
            return new EmployeeNotificationModel()
            {
                Id = employeeNotification.Id,
                EmployeeId = employeeNotification.Employee.Id,
                AssessedBySupervisor = employeeNotification.AssessedBySupervisor,
            };
        }
    }
}
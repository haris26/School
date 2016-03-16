using Database;

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
                CategoryName = tool.Category.Name
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
    }
}
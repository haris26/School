using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                model.Members.Add(person.Person.FirstName + " " + person.Person.LastName);
            }
            return model;
        }
        public ResourceModel Create(Resource resource)
        {
            return new ResourceModel()
            {
                Id = resource.Id,
                Name = resource.Name,
                Status = resource.Status,
                ResourceCategory = resource.ResourceCategory.Id,
                ResourceCategoryName = resource.ResourceCategory.CategoryName
            };
        }
    }
}
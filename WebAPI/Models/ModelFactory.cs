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
        public RoleModel Create(Role role)
        {
            return new RoleModel()
            {
                Id = role.Id,
                Name = role.Name,
                Count = role.Roles.Count
            };
        }
        public CharacteristicModel Create(Characteristic characteristic)
        {
            return new CharacteristicModel
            {
                Id = characteristic.Id,
                Name = characteristic.Name,
                Value = characteristic.Value,
                Resource = characteristic.Resource.Id,
                ResourceName = characteristic.Resource.Name

            };
        }
        public CharacteristicNameModel Create(CharacteristicName characteristicName)
        {
            return new CharacteristicNameModel()
            {
                Id = characteristicName.Id,
                Name = characteristicName.Name,
                ResourceCategory = characteristicName.ResourceCategory.Id,

                ResourceCategoryName = characteristicName.ResourceCategory.CategoryName
            };
        }
    }
}
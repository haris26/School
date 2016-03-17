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

        public EventModel Create(Event ev)
        {
            return new EventModel()
            {
                Id = ev.Id,
                EventTitle = ev.EventTitle,
                StartDate = ev.EventStart,
                EndDate = ev.EventEnd,
                Person = ev.User.Id,
                PersonName = ev.User.FirstName + " " + ev.User.LastName,
                Resource = ev.Resource.Id,
                ResourceName = ev.Resource.Name,
                Category = ev.Resource.ResourceCategory.Id,
                CategoryName = ev.Resource.ResourceCategory.CategoryName
            };
        }

        public EventExtendModel Create(ExtendedEvent exEvent)
        {
            return new EventExtendModel()
            {
                Id = exEvent.Id,
                ParentEvent = exEvent.ParentEvent.Id,
                RepeatUntil = exEvent.RepeatUntil,
                RepeatingType = exEvent.RepeatingType,
                Frequency = exEvent.Frequency

            };
        }
        public ResourceCategoryModel Create(ResourceCategory resourceCat)
        {
            return new ResourceCategoryModel()
            {
                Id = resourceCat.Id,
                CategoryName = resourceCat.CategoryName
            };
        }
    }
}
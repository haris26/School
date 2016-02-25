using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ReservationSystem.Models
{
    public class ModelFactory
    {

        public EventModel Create(Event eEvent)
        {
            return new EventModel()
            {
                Id = eEvent.Id,
                EventTitle = eEvent.EventTitle,
                StartDate = eEvent.EventStart,
                EndDate = eEvent.EventEnd,
                Person = eEvent.User.Id,
                PersonName = eEvent.User.FirstName + " " + eEvent.User.LastName,
                Resource = eEvent.Resource.Id,
                ResourceName = eEvent.Resource.Name,
                Category = eEvent.Resource.ResourceCategory.Id,
                CategoryName = eEvent.Resource.ResourceCategory.CategoryName
            };
        }

     
        //Irhad on ModelFactory
        //public CharacteristicNameModel Create(CharacteristicName characteristicName)
        //{
        //    return new CharacteristicNameModel()
        //    {
        //        Id = characteristicName.Id,
        //        Name = characteristicName.Name,
        //        ResourceCategory = characteristicName.ResourceCategory.Id,
        //        ResourceCategoryName = characteristicName.ResourceCategory.CategoryName
        //    };
        //}
  
    }
}

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

        public EngagementModel Create(Engagement engagement)
        {
            return new EngagementModel()
            {
                Id = engagement.Id,
                StartDate = engagement.StartDate,
                EndDate = engagement.EndDate,
                Time = engagement.Time,
                Person = engagement.Person.Id,
                PersonName = engagement.Person.FirstName + " " + engagement.Person.LastName,
                Team = engagement.Team.Id,
                TeamName = engagement.Team.Name,
                Role = engagement.Role.Id,
                RoleName = engagement.Role.Name
            };
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


using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProcurementSystem.Models

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

        public RequestModel Create(Request request)
        {
            return new RequestModel()
            {
                Id = request.Id,
                requestType = request.requestType,
                RequestDescription = request.RequestDescription,
                RequestMessage = request.RequestMessage,
                RequestDate = request.RequestDate,
                Asset = request.Asset.Id,
                AssetModel = request.Asset.Model,
                Person = request.User.Id,
                PersonName = request.User.FirstName + " " + request.User.LastName

            };
        }
    }
}
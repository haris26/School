using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;
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

        public EngagementModel Create(Database.Engagement engagement)
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
        public AssetsModel Create(Asset asset)
        {
            return new AssetsModel()
            {
                Id = asset.Id,
                Name = asset.Name,
                Model = asset.Model,
                User = asset.User.Id,
                UserName = asset.User.FirstName,
                Vendor = asset.Vendor,
                Category = asset.AssetCategory.Id,
                CategoryName = asset.AssetCategory.CategoryName,
                DateOfTrade = asset.DateOfTrade,
                SerialNumber = asset.SerialNumber,
                Status = asset.Status,
                Price = asset.Price
            };
        }
        public CharacteristicNameModel Create(AssetCharacteristicNames characteristicNames)
        {
            return new CharacteristicNameModel()
            {
                Id = characteristicNames.Id,
                Name = characteristicNames.Name,
                
            };
        }
    }
}
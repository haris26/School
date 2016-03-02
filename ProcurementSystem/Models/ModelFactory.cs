
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace ProcurementSystem.Models


{
    public class ModelFactory
    {
        private SchoolContext context;

        public ModelFactory(SchoolContext ctx)
        {
            context = ctx;
        }
        public PeopleModel Create(Person person)
        {
            return new PeopleModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Category = person.Category,
                Phone = person.Phone,
                Status = person.Status
            };
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

        public HistoryModel Create(History history)
        {
            return new HistoryModel()
            {
                Id = history.Id,
                EventBegin =history.EventBegin,
                EventEnd = history.EventEnd,
                Description =history.Description,
                Person = history.Person.Id,
                PersonName = history.Person.FirstName + " " + history.Person.LastName,
                Asset=history.Asset.Id,
                AssetModel=history.Asset.Model
              

            };
        }


    }

   
}
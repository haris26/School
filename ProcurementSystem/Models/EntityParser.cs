using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ProcurementSystem.Models
{
    public class EntityParser
    {
        public Engagement Create(EngagementModel model, SchoolContext context )
        {

            return new Engagement()
            {
                Id = model.Id,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Time = model.Time,
                Person = context.People.Find(model.Person),
                Team = context.Teams.Find(model.Team),
                Role = context.Roles.Find(model.Role)
            };
        }
        public Asset Create(AssetsModel model, SchoolContext context)
        {
            return new Asset()
            {
                Id = model.Id,
                Name = model.Name,
                Model = model.Model,
                User = context.People.Find(model.User),
                //PersonName = Asset.Person
                Vendor = model.Vendor,
               AssetCategory = context.AssetCategory.Find(model.Category),
               // Category = model.AssetCategory.Id,
                DateOfTrade = model.DateOfTrade,
                SerialNumber = model.SerialNumber,
                Status = model.Status,
                Price = model.Price
            };
        }
        public AssetCharacteristicNames Create(CharacteristicNameModel model, SchoolContext context)
        {
            return new AssetCharacteristicNames()
            {
                Id = model.Id,
                Name = model.Name,

            };
        }
    }
}
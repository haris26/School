using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ProcurementSystem.Models
{
    public class EntityParser
    {

        private SchoolContext context;

        public EntityParser(SchoolContext ctx)
        {
            context = ctx;
        }
        public Person Create(PeopleModel model)
        {
            return new Person()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Category = model.Category,
                Phone = model.Phone,
                Status = model.Status
            };
        }

        public Engagement Create(EngagementModel model)
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
        public Asset Create(AssetsModel model)
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
        public AssetCharacteristicNames Create(CharacteristicNameModel model)
        {
            return new AssetCharacteristicNames()
            {
                Id = model.Id,
                Name = model.Name,

            };
        }

        public Request Create(RequestModel model)
        {
            return new Request()
            {
                Id = model.Id,
                requestType = model.requestType,
                RequestDescription = model.RequestDescription,
                RequestMessage = model.RequestMessage,
                RequestDate = model.RequestDate,
                Asset = context.Assets.Find(model.Asset),
                User = context.People.Find(model.Person)

            };
        }

        public History Create(HistoryModel model)
        {
            return new History()

            {
                Id = model.Id,
                EventBegin = model.EventBegin,
                EventEnd = model.EventEnd,
                Description = model.Description,
                Person = context.People.Find(model.Person),
                Status = model.Status,
                Asset = context.Assets.Find(model.Asset)

            };
        }
    }
}
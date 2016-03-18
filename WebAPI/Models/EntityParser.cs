using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EntityParser
    {
     

        public Request Create(RequestModel model, SchoolContext context)
        {
            return new Request()
            {
                Id = model.Id,
                requestType = model.requestType,
                RequestDescription = model.RequestDescription,
                RequestMessage = model.RequestMessage,
                RequestDate = model.RequestDate,
                Asset = context.Assets.Find(model.Asset),
                User = context.People.Find(model.Person),
                AssetCategory = context.AssetCategory.Find(model.Category),
                Quantity = model.Quantity,
                Status = model.Status,
                AssetType = model.AssetType,


            };
        }

        public Person Create(PeopleModel model, SchoolContext context)
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
        public History Create(HistoryModel model, SchoolContext context)
        {
            return new History()
            {
                Id = model.Id,
                EventBegin=model.EventBegin,
                EventEnd=model.EventEnd,
                Person = context.People.Find(model.Person),
                Asset = context.Assets.Find(model.Asset),
                Description = model.Description
                
            };
        }
    }
}
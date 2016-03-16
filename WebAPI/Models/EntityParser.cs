using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EntityParser
    {
        protected SchoolContext context;

        public EntityParser(SchoolContext _context)
        {
            context = _context;
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
                User = context.People.Find(model.Person),
                AssetCategory = context.AssetCategory.Find(model.Category),
                Quantity = model.Quantity,
                Status = model.Status,
                AssetType = model.AssetType,


            };
        }


    }
}
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
                AssetCategory = context.AssetCategories.Find(model.Category),
                Quantity = model.Quantity,
                Status = model.Status,
                AssetType = model.AssetType,


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
              Status = (AssetStatus)Enum.Parse(typeof(AssetStatus), model.Status),
            Vendor = model.Vendor,
                AssetCategory = context.AssetCategories.Find(model.Category),
                DateOfTrade = model.DateOfTrade,
                SerialNumber = model.SerialNumber,
                Price = model.Price
 };
        }


        public AssetCategory Create(AssetCategoriesModel model, SchoolContext context)
        {
            return new AssetCategory()
            {
                Id=model.Id,
                CategoryName= model.CategoryName,
                assetType = (AssetType)Enum.Parse(typeof(AssetType), model.Type),
       

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

        public AssetChar Create(AssetCharsModel model, SchoolContext context)
        {
            return new AssetChar()
            {
                Id = model.Id,
                Name=model.Name,
                Value=model.Value,
                Asset = context.Assets.Find(model.Asset),
               

            };

        }
    }
}
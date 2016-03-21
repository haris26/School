using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

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
                model.Members.Add(new MemberModel() { Name = person.Person.FirstName + " " + person.Person.LastName, Role = person.Role.Name });
            }
            return model;
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
               // Asset = request.Asset.Id,
              //  AssetModel = request.Asset.Name,
                Person = request.User.Id,
                PersonName = request.User.FirstName + " " + request.User.LastName,
                Category = request.AssetCategory.Id,
                CategoryName = request.AssetCategory.CategoryName,
                Quantity = request.Quantity,
                Status = request.Status,
                AssetType = request.AssetType,


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


        public AssetCategoriesModel Create(AssetCategory category)
        {
            AssetCategoriesModel model = new AssetCategoriesModel()
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Type = category.assetType.ToString()

            };
            foreach (var asset in category.Assets)
            {
                model.Assets.Add(new AssetsModel
                {
                    Name = asset.Name,
                    User = asset.User.Id,
                    UserName = asset.User.FullName,
                    Model = asset.Model,
                    SerialNumber = asset.SerialNumber,
                    Vendor = asset.Vendor,
                    DateOfTrade = asset.DateOfTrade,
                    Status = asset.Status.ToString(),
                    Category = asset.AssetCategory.Id,
                    CategoryName = asset.AssetCategory.CategoryName
                });
            }


            return model;
        }
        public AssetCharsModel Create(AssetChar characteristic)
        {
            AssetCharsModel model = new AssetCharsModel()
            {
                Id = characteristic.Id,
               Name = characteristic.Name,
             Value=characteristic.Value,
               Asset = characteristic.Asset.Id,
              AssetName=characteristic.Asset.Name

            };
            
              return model;
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
                Status = asset.Status.ToString(),
                Category = asset.AssetCategory.Id,
                CategoryName = asset.AssetCategory.CategoryName,
                DateOfTrade = asset.DateOfTrade,
                SerialNumber = asset.SerialNumber,
                Price = asset.Price
            };
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

        public HistoryModel Create(History history)
        {
            return new HistoryModel
            {
                Id = history.Id,
                EventBegin = history.EventBegin,
                EventEnd = history.EventEnd,
                Description = history.Description,
                Person = history.Person.Id,
                PersonName = history.Person.FullName,
                Asset = history.Asset.Id,
                AssetModel = history.Asset.Model,
                Status = history.Status
            };
        }


    }



}

using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

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
            if (request.Asset == null)
            {
                return new RequestModel()
                {
                    Id = request.Id,
                    RequestType = request.requestType.ToString(),
                    RequestDescription = request.RequestDescription,
                    RequestMessage = request.RequestMessage,
                    RequestDate = request.RequestDate,
                    Person = request.User.Id,
                    PersonName = request.User.FullName.ToString(),
                    Category = request.AssetCategory.Id,
                    CategoryName = request.AssetCategory.CategoryName,
                    Quantity = request.Quantity,
                    Status = request.Status.ToString(),
                    AssetType = request.AssetType.ToString(),
                    Email = request.User.Email.ToString(),
                    ServiceType = request.ServiceType.ToString()
                };
            }
            else
                return new RequestModel()
                {
                    Id = request.Id,
                    RequestType = request.requestType.ToString(),
                    RequestDescription = request.RequestDescription,
                    RequestMessage = request.RequestMessage,
                    RequestDate = request.RequestDate,
                    Asset = request.Asset.Id,
                    AssetModel = request.Asset.Name,
                    Person = request.User.Id,
                    PersonName = request.User.FullName.ToString(),
                    Category = request.AssetCategory.Id,
                    CategoryName = request.AssetCategory.CategoryName,
                    Quantity = request.Quantity,
                    Status = request.Status.ToString(),
                    AssetType = request.AssetType.ToString(),
                    Email = request.User.Email.ToString(),
                    ServiceType=request.ServiceType.ToString()
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

        public AssetCharacteristicNamesModel Create(AssetCharacteristicNames charNames)
        {
            AssetCharacteristicNamesModel model = new AssetCharacteristicNamesModel()
            {
                Id = charNames.Id,
                CategoryName = charNames.AssetCategory.CategoryName.ToString(),
                Category = charNames.AssetCategory.Id,
                Name = charNames.Name.ToString()
            };
            return model;
        }


        public AssetCategoriesModel Create(AssetCategory category)
        {
            AssetCategoriesModel model = new AssetCategoriesModel()
            {
               Id=category.Id,
                CategoryName = category.CategoryName,
                
                Type = category.assetType.ToString(),
                Assets=new List<AssetsModel>(),
                AssetCharacteristicNames = new List<AssetCharacteristicNamesModel>()
                 

        };
            foreach (var asset in category.Assets)
            {
                if (asset.User == null)
                {
                    model.Assets.Add(new AssetsModel
                    {
                        Id = asset.Id,
                        Name = asset.Name,
                        //User = asset.User.Id,
                        //UserName = asset.User.FullName,
                        Model = asset.Model,
                        SerialNumber = asset.SerialNumber,
                        Vendor = asset.Vendor,
                        Price = asset.Price,
                        DateOfTrade = asset.DateOfTrade,
                        Status = asset.Status.ToString(),
                        Category = asset.AssetCategory.Id,
                        CategoryName = asset.AssetCategory.CategoryName

                    });

                    
                }
                else
                    model.Assets.Add(new AssetsModel
                    {
                        Id = asset.Id,
                        Name = asset.Name,
                        User = asset.User.Id,
                        UserName = asset.User.FullName.ToString(),
                        Model = asset.Model,
                        SerialNumber = asset.SerialNumber,
                        Vendor = asset.Vendor,
                        Price = asset.Price,
                        DateOfTrade = asset.DateOfTrade,
                        Status = asset.Status.ToString(),
                        Category = asset.AssetCategory.Id,
                        CategoryName = asset.AssetCategory.CategoryName


                    });
            }

            foreach (var characteristic in category.AssetCharacteristicNames)
            {
               
                    model.AssetCharacteristicNames.Add(new AssetCharacteristicNamesModel
                    {
                        Id = characteristic.Id,
                        Name = characteristic.Name,

                        CategoryName = characteristic.AssetCategory.CategoryName.ToString(),
                        Category = characteristic.AssetCategory.Id
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
                Value = characteristic.Value,
                Asset = characteristic.Asset.Id,
                AssetName = characteristic.Asset.Name.ToString()

            };

            return model;
        }



        //public AssetsModel Create(Asset asset)
        //{
        //    if (asset.User == null)
        //    {
        //        AssetsModel am = new AssetsModel()
        //        {

        //            Id = asset.Id,
        //            Name = asset.Name,
        //            Model = asset.Model,
        //            //User = asset.User.Id,
        //            //UserName = asset.User.FirstName,
        //            Vendor = asset.Vendor,
        //            Price = asset.Price,
        //            Status = asset.Status.ToString(),
        //            Category = asset.AssetCategory.Id,
        //            CategoryName = asset.AssetCategory.CategoryName,
        //            DateOfTrade = asset.DateOfTrade,
        //            SerialNumber = asset.SerialNumber

        //        };

        //        foreach (var chars in asset.assetCharacteristics)
        //        {
        //            am.assetCharacteristics.Add
        //                (
        //                new AssetCharsModel()
        //                {
        //                    Id = chars.Id,
        //                    Name = chars.Name,
        //                    Asset = chars.Asset.Id,
        //                    AssetName = chars.Asset.Name,
        //                    Value = chars.Value
        //                }
        //                );

        //        }

        //        return am;
        //    }
        //    else
        //    {
        //        AssetsModel amod = new AssetsModel()
        //        {
        //            Id = asset.Id,
        //            Name = asset.Name,
        //            Model = asset.Model,
        //            User = asset.User.Id,
        //            UserName = asset.User.FirstName + ' ' + asset.User.LastName,
        //            Vendor = asset.Vendor,
        //            Price = asset.Price,
        //            Status = asset.Status.ToString(),
        //            Category = asset.AssetCategory.Id,
        //            CategoryName = asset.AssetCategory.CategoryName,
        //            DateOfTrade = asset.DateOfTrade,
        //            SerialNumber = asset.SerialNumber

        //        };

        //        foreach (var chars in asset.assetCharacteristics)
        //        {
        //            amod.assetCharacteristics.Add
        //                (
        //                new AssetCharsModel()
        //                {
        //                    Id = chars.Id,
        //                    Name = chars.Name,
        //                    Asset = chars.Asset.Id,
        //                    AssetName = chars.Asset.Name,
        //                    Value = chars.Value
        //                }
        //                );

        //            return amod;
        //        }
        //  };
        //    return new AssetsModel();
        //}

        public AssetsModel Create(Asset asset)
        {
            if (asset.User == null)
            {
                AssetsModel model = new AssetsModel()
                {
                    Id = asset.Id,
                    Name = asset.Name,
                    Model = asset.Model,
                    //User = asset.User.Id,
                    //UserName = asset.User.FirstName,
                    Vendor = asset.Vendor,
                    Price = asset.Price,
                    Status = asset.Status.ToString(),
                    Category = asset.AssetCategory.Id,
                    CategoryName = asset.AssetCategory.CategoryName,
                    DateOfTrade = asset.DateOfTrade,
                    SerialNumber = asset.SerialNumber,
                    assetCharacteristics = new List<AssetCharsModel>()

                };
                foreach (var chars in asset.assetCharacteristics)
                {
                    model.assetCharacteristics.Add
                        (
                        new AssetCharsModel()
                        {
                            Id = chars.Id,
                            Name = chars.Name,
                            Asset = chars.Asset.Id,
                            AssetName = chars.Asset.Name,
                            Value = chars.Value
                        });

                }
                return model;

            }
            else
            {
                AssetsModel model = new AssetsModel()
                {
                    Id = asset.Id,
                    Name = asset.Name,
                    Model = asset.Model,
                    User = asset.User.Id,
                    UserName = asset.User.FirstName + ' ' + asset.User.LastName,
                    Vendor = asset.Vendor,
                    Price = asset.Price,
                    Status = asset.Status.ToString(),
                    Category = asset.AssetCategory.Id,
                    CategoryName = asset.AssetCategory.CategoryName,
                    DateOfTrade = asset.DateOfTrade,
                    SerialNumber = asset.SerialNumber,
                    assetCharacteristics = new List<AssetCharsModel>()

                };
                foreach (var chars in asset.assetCharacteristics)
                {
                    model.assetCharacteristics.Add
                        (
                        new AssetCharsModel()
                        {
                            Id = chars.Id,
                            Name = chars.Name,
                            Asset = chars.Asset.Id,
                            AssetName = chars.Asset.Name,
                            Value = chars.Value
                        });

                }
                return model;

            }
     
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

        public TokenModel Create(AuthToken token)
        {
            return new TokenModel()
            {
                Token = token.Token,
                Expiration = token.Expiration
            };
        }


        



    }



}
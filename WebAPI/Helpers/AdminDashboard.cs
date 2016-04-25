using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;


namespace WebAPI.Helpers
{
    public static class AdminDashboard
    {
        public static AdminDashboardModel Create()
        {
            SchoolContext context = new SchoolContext();
            AdminDashboardModel dashboard = new AdminDashboardModel()
            {
                Id = AppGlobals.currentUser.Id,
                Username=AppGlobals.currentUser.FirstName
            };


            var requests = new RequestUnit(context).Get().
                Where(x => x.requestType == RequestType.New && x.Status == RequestStatus.InProccess && x.AssetCategory.assetType == AssetType.Device).ToList();
            foreach (var request in requests)
            {            
             dashboard.CountNewRequests++;

                dashboard.Requests.Add(new ListReqModel
                {
                    Id = request.Id,
                    Category = request.AssetCategory.CategoryName.ToString(),
                    Description = request.RequestDescription,
                    Message = request.RequestMessage,
                    Type = request.requestType.ToString(),
                    Quantity = request.Quantity,
                    Status = request.Status.ToString(),
                    Date = request.RequestDate.Date,
                    User = request.User.FirstName.ToString(),
                    AssetType = request.AssetCategory.assetType.ToString()
              });

                }



            var servicerequests = new RequestUnit(context).Get().Where(x => x.requestType == RequestType.Service && x.Status == RequestStatus.InProccess && x.AssetCategory.assetType == AssetType.Device).ToList();
            foreach (var request in servicerequests)
            {
               dashboard.CountServiceRequests++;
                dashboard.ServiceRequests.Add(new ListReqModel
                {
                    Id = request.Id,
                    Category = request.AssetCategory.CategoryName.ToString(),
                    Description = request.RequestDescription,
                    Message = request.RequestMessage,
                    Type = request.requestType.ToString(),
                    Quantity = request.Quantity,
                    Status = request.Status.ToString(),
                    Date = request.RequestDate.Date,
                    User = request.User.FirstName.ToString()
                });
            }



            //counting assets by type and status
            var freeassets = new AssetsUnit(context).Get().Where(x => x.AssetCategory.assetType == AssetType.Device && x.Status == AssetStatus.Free).ToList();
            foreach (var asset in freeassets)
            {
                dashboard.countFreeAssets++;

                dashboard.FreeAssets.Add(new ListAssetModel
                {
                    Category = asset.AssetCategory.CategoryName.ToString(),
                    Model = asset.Model, Name = asset.Name,
                    Vendor = asset.Vendor,
                    SerialNumber = asset.SerialNumber,
                    Status = asset.Status.ToString(),
                    Date = asset.DateOfTrade.Date,
                    
                });
            }

            var allassets = new AssetsUnit(context).Get().ToList();
            foreach (var asset in allassets)
            {
                dashboard.countAllAssets++;

                dashboard.AllAssets.Add(new ListAssetModel
                {
                    Category = asset.AssetCategory.CategoryName.ToString(),
                    Model = asset.Model,
                    Name = asset.Name,
                    Vendor = asset.Vendor,
                    SerialNumber = asset.SerialNumber,
                    Status = asset.Status.ToString(),
                    Date = asset.DateOfTrade.Date
                });
            }



            var outoforderassets = new AssetsUnit(context).Get().Where(x => x.AssetCategory.assetType == AssetType.Device && x.Status == AssetStatus.OutofOrder).ToList();
            foreach (var asset in outoforderassets)
            {
              dashboard.countOutOfOrderAssets++;
                dashboard.OutOfOrderAssets.Add(new ListAssetModel
                {
                    Category = asset.AssetCategory.CategoryName.ToString(),
                    Model = asset.Model,
                    Name = asset.Name,
                    Vendor = asset.Vendor,
                    SerialNumber = asset.SerialNumber,
                    Status = asset.Status.ToString(),
                    Date = asset.DateOfTrade.Date
                });
            }


            var assignedassets = new AssetsUnit(context).Get().Where(x => x.AssetCategory.assetType == AssetType.Device && x.Status == AssetStatus.Assigned).ToList();
            foreach (var asset in assignedassets)
            {
                dashboard.countAssignedAssets++;
                dashboard.AssignedAssets.Add(new ListAssetModel
                {
                    Category = asset.AssetCategory.CategoryName.ToString(),
                    Model = asset.Model,
                    Name = asset.Name,
                    Vendor = asset.Vendor,
                    SerialNumber = asset.SerialNumber,
                    Status = asset.Status.ToString(),
                    Date = asset.DateOfTrade.Date,
                    User = asset.User.FullName.ToString()
                });
            }

            return dashboard;
        }
    }
}
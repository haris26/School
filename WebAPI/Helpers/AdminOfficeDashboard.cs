using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;


namespace WebAPI.Helpers
{
    public static class AdminOfficeDashboard
    {
        public static AdminDashboardModel Create()
        {
            SchoolContext context = new SchoolContext();
            AdminDashboardModel dashboard = new AdminDashboardModel()
            {
                Id = AppGlobals.currentUser.Id,
                Username = AppGlobals.currentUser.FirstName
            };


            var requests = new RequestUnit(context).Get().
                Where(x => x.requestType == RequestType.New && x.Status == RequestStatus.New && x.AssetCategory.assetType == AssetType.Office).ToList();
            foreach (var request in requests)
            {
                dashboard.CountNewRequests++;
                dashboard.Requests.Add(new ListReqModel
                {
                    Category = request.AssetCategory.CategoryName.ToString(),
                    Description = request.RequestDescription,
                    Message = request.RequestMessage,
                    Type = request.requestType.ToString(),
                    Quantity = request.Quantity,
                    Status = request.Status.ToString(),
                    Date = request.RequestDate.Date,
                    User=request.User.Id,
                    UserName = request.User.FullName.ToString()
                });
            }



            var servicerequests = new RequestUnit(context).Get().Where(x => x.requestType == RequestType.Service && x.Status == RequestStatus.New && x.AssetCategory.assetType == AssetType.Office).ToList();
            foreach (var request in servicerequests)
            {
                dashboard.CountServiceRequests++;
                dashboard.ServiceRequests.Add(new ListReqModel
                {
                    Category = request.AssetCategory.CategoryName.ToString(),
                    Description = request.RequestDescription,
                    Message = request.RequestMessage,
                    Type = request.requestType.ToString(),
                    Quantity = request.Quantity,
                    Status = request.Status.ToString(),
                    Date = request.RequestDate.Date,
                    User = request.User.Id,
                    UserName=request.User.FullName.ToString()
                });
            }



            //counting assets by type and status
            var freeassets = new AssetsUnit(context).Get().Where(x => x.AssetCategory.assetType == AssetType.Office && x.Status == AssetStatus.Free).ToList();
            foreach (var asset in freeassets)
            {
                dashboard.countFreeAssets++;

                dashboard.FreeAssets.Add(new ListAssetModel
                {
                    Category = asset.AssetCategory.Id,
                    CategoryName=asset.AssetCategory.CategoryName.ToString(),
                    Model = asset.Model,
                    Name = asset.Name,
                    Vendor = asset.Vendor,
                    SerialNumber = asset.SerialNumber,
                    Status = asset.Status.ToString(),
                    Date = asset.DateOfTrade.Date
                   
                    
                });
            }

            var OutOfStockassets = new AssetsUnit(context).Get().Where(x => x.AssetCategory.assetType == AssetType.Office && x.Status == AssetStatus.OutOfStock).ToList();
            foreach (var asset in OutOfStockassets)
            {
                dashboard.countOutOfStockAssets++;
                dashboard.OutOfStockAssets.Add(new ListAssetModel
                {
                    Category = asset.AssetCategory.Id,
                    CategoryName=asset.AssetCategory.CategoryName.ToString(),
                    Model = asset.Model,
                    Name = asset.Name,
                    Vendor = asset.Vendor,
                    SerialNumber = asset.SerialNumber,
                    Status = asset.Status.ToString(),
                    Date = asset.DateOfTrade.Date
                });
            }


            var assignedassets = new AssetsUnit(context).Get().Where(x => x.AssetCategory.assetType == AssetType.Office && x.Status == AssetStatus.Assigned).ToList();
            foreach (var asset in assignedassets)
            {
                dashboard.countAssignedAssets++;
                dashboard.AssignedAssets.Add(new ListAssetModel
                {
                    Category = asset.AssetCategory.Id,
                    CategoryName=asset.AssetCategory.CategoryName.ToString(),
                    Model = asset.Model,
                    Name = asset.Name,
                    Vendor = asset.Vendor,
                    SerialNumber = asset.SerialNumber,
                    Status = asset.Status.ToString(),
                    Date = asset.DateOfTrade.Date,
                    User = asset.User.Id,
                    UserName = asset.User.FullName.ToString()
                });
            }

            return dashboard;
        }
    }
}
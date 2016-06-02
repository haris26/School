﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class Dashboard
    {
        public static DashboardModel Create(Person person)
        {

            DashboardModel dashboard = new DashboardModel()
            {
                Id = person.Id,
                Name = person.FullName
            };

           

            var assets = person.Assets.Select (x => new { x.Id,x.Status, x.DateOfTrade, x.Model,x.AssetCategory.assetType, x.Vendor, x.AssetCategory,
                    x.Name, x.SerialNumber }).ToList();
            foreach (var asset in assets)
            {
                dashboard.Assets.Add(new ListModel
                {   Id=asset.Id,
                    Category = asset.AssetCategory.Id,
                CategoryName=asset.AssetCategory.CategoryName.ToString(),
                assetType=asset.assetType.ToString(),
                    Model =asset.Model,Name=asset.Name,
                    Vendor =asset.Vendor,
                    SerialNumber =asset.SerialNumber,
                    Status=asset.Status.ToString(),
                    Date = asset.DateOfTrade.Date,
                     User=person.Id,
                    Asset = asset.Id
                });


            }

            
            var requests = person.Requests.Select(x => 
            new { x.Id,
                x.Status,
                x.RequestDate,
                x.CompletedRequestDate,
                x.RequestDescription,
                x.RequestMessage,
                x.requestType,
                x.Quantity,
                x.AssetCategory,
                x.AssetType,
            x.ServiceType}).ToList();

            foreach (var request in requests)
            {
                if ((request.requestType == RequestType.New) && (request.Status!=RequestStatus.Completed))
                {
                    dashboard.NewRequests.Add(new ListRequestsModel {
                        Id=request.Id,
                        Category=request.AssetCategory.Id,
                        CategoryName = request.AssetCategory.CategoryName.ToString(),
                        assetType=request.AssetType.ToString(),
                        Description = request.RequestDescription,
                        Message = request.RequestMessage,
                        Type = request.requestType.ToString(),
                        Quantity = request.Quantity,
                        Status = request.Status.ToString(),
                        Date = request.RequestDate.Date });
                }

                else if ((request.requestType == RequestType.Service) && (request.Status!=RequestStatus.Completed))
                {
                    dashboard.ServiceRequests.Add(new ListRequestsModel {
                        Id=request.Id,
                        Category = request.AssetCategory.Id,
                        CategoryName=request.AssetCategory.CategoryName.ToString(),
                        assetType = request.AssetType.ToString(),
                        Description = request.RequestDescription,
                        Message = request.RequestMessage,
                        Type = request.requestType.ToString(),
                        Quantity = request.Quantity,
                        Status = request.Status.ToString(),
                        Date = request.RequestDate.Date,
                        ServiceType=request.ServiceType.ToString()
                       });
                }

                else if (request.Status == RequestStatus.Completed)
                {
                    dashboard.CompletedRequests.Add(new ListRequestsModel
                    {
                        Id=request.Id,
                        Category = request.AssetCategory.Id,
                        CategoryName = request.AssetCategory.CategoryName.ToString(),
                        Description = request.RequestDescription,
                        Message = request.RequestMessage,
                        Type = request.requestType.ToString(),
                        Quantity = request.Quantity,
                        Status = request.Status.ToString(),
                        Date = request.RequestDate.Date,
                        DateOfComplete=request.CompletedRequestDate,
                        ServiceType = request.ServiceType.ToString()
                    });
                    dashboard.countStatusCompletedChange++;
                }


                if ((request.Status!= RequestStatus.New)&&(request.Status!=RequestStatus.Completed))
                {
                    dashboard.ChangedStatusRequests.Add(new ListRequestsModel
                    {
                        Id = request.Id,
                        Category = request.AssetCategory.Id,
                        CategoryName = request.AssetCategory.CategoryName.ToString(),
                        Description = request.RequestDescription,
                        Message = request.RequestMessage,
                        Type = request.requestType.ToString(),
                        Quantity = request.Quantity,
                        Status = request.Status.ToString(),
                        Date = request.RequestDate.Date,
                        ServiceType = request.ServiceType.ToString()
                    });
                    dashboard.countStatusChange++;
                }
            }


            return dashboard;
        }
    }
}
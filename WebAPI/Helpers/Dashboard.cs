using Database;
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

           

            var assets = person.Assets.Select(x => new { x.Status, x.DateOfTrade, x.Model, x.Vendor, x.AssetCategory, x.Name, x.SerialNumber }).ToList();
            foreach (var asset in assets)
            {
                dashboard.Assets.Add(new ListModel { Category = asset.AssetCategory.CategoryName.ToString(), Model=asset.Model,Name=asset.Name,Vendor=asset.Vendor, SerialNumber=asset.SerialNumber, Status=asset.Status.ToString(),Date = asset.DateOfTrade.Date });

            }

            var requests = person.Requests.Select(x => new { x.Status, x.RequestDate, x.RequestDescription, x.RequestMessage, x.requestType, x.Quantity, x.AssetCategory }).ToList();

            foreach (var request in requests)
            {
                dashboard.Requests.Add(new ListRequestsModel { Category = request.AssetCategory.CategoryName.ToString(), Description = request.RequestDescription, Message = request.RequestMessage, Type = request.requestType.ToString(),Quantity=request.Quantity, Status=request.Status.ToString(), Date=request.RequestDate.Date});


            }


            return dashboard;
        }
    }
}
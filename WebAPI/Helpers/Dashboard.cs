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

           

            var assets = person.Assets.GroupBy(x => x.AssetCategory.CategoryName).Select(x => new { type = x.Key, count = x.Count() }).ToList();
            foreach (var asset in assets)
            {
                dashboard.Assets.Add(new ListModel { Category = asset.type, Count = asset.count });
            }
            var requests = person.Requests.GroupBy(x => x.RequestDescription).Select(x => new { type = x.Key, count = x.Count(), message=x.Key }).ToList();

            foreach (var request in requests)
            {
                dashboard.Requests.Add(new ListModel { Category = request.type, Count = request.count, Message=request.message});


            }


            return dashboard;
        }
    }
}
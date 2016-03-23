using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

using Database;
using WebAPI.Filters;

namespace WebAPI.Helpers
{
    [SchoolAuthorize]
    public class Dashboard

    {
        public static DashboardModel Create(Person person)
        {
            DashboardModel dashboard = new DashboardModel()
            {
                Id = person.Id,
                Name = person.FullName
            };


            var details = person.Days.SelectMany(x => x.Details).GroupBy(x => x.Team.Name).Select(x => new { team = x.Key, time = x.Sum(y => y.WorkTime) }).ToList();
            foreach (var detail in details)
            {
                dashboard.Days.Add(new ListModel { Category = detail.team, Count = (int)detail.time });
            }
            return dashboard;
        }
    }
}
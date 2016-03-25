using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

using Database;


namespace WebAPI.Helpers
{

    public class Dashboard

    {
        public static DashboardModel Create(Person person)
        {
            DashboardModel dashboard = new DashboardModel()
            {
                Id = person.Id,
                Name = person.FullName

            };
            DateTime dd = DateTime.Now; //(year: 2016, month: 3, day: 1);
            int bd = DateTime.DaysInMonth(dd.Year, dd.Month);

            var days =
               person.Days.GroupBy(x => x.Person.FirstName)
                   .Select(x => new { type = x.Key, days = x.Count() })
                   .ToList();
            foreach (var d in days)
            {

                dashboard.CountEmpty = bd - d.days;
            }
            var details = person.Days.SelectMany(x => x.Details).GroupBy(x => x.Team.Name).Select(x => new { team = x.Key, time = x.Sum(y => y.WorkTime) }).ToList();
            foreach (var detail in details)
            {
                dashboard.Days.Add(new ListModel { Category = detail.team, Count = (int)detail.time });
            }
            return dashboard;
        }
    }
}
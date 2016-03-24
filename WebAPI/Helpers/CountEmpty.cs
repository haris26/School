using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;
using WebAPI.Helpers;
using WebAPI.Controllers;
using WebAPI.Filters;
using WebAPI.Services;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public class CountEmpty
    {
        //    public static DashboardModel Create(Person person)
        //    {
        //        DashboardModel dashboard = new DashboardModel()
        //        {
        //            Id = person.Id,
        //            Name = person.FullName
        //        };



        //        DateTime dd = new DateTime(year: 2016, month: 3, day: 1);
        //        int bd = 31; // DateTime.DaysInMonth(dd.Year, dd.Month);

        //        var days =
        //            person.Days.GroupBy(x => x.Person.FirstName)
        //                .Select(x => new { type = x.Key, days = x.Count() })
        //                .ToList();
        //        foreach (var d in days)
        //        {
        //            dashboard.Days.Add(new ListModel() { Category = d.type, Count = d.days, CountEmpty = 31 - d.days });
        //        }
        //        return dashboard;
        //    }


        //}
    }
}
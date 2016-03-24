using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

using Database;


namespace WebAPI.Helpers
{
    public class MonthList

    {
        public static MonthModel Create(Person person)
        {
            MonthModel dashboard = new MonthModel()
            {
                Id = person.Id,
                Name = person.FullName,

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
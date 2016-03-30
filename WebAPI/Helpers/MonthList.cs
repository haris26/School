﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

using Database;


namespace WebAPI.Helpers
{
    public class MonthList
    {
        public static MonthModel Create(Person person, int month)
        {
            MonthModel dashboard = new MonthModel()
            {
                Id = person.Id,
                Name = person.FullName,

            };
            int dd = DateTime.Now.Month; //(year: 2016, month: 3, day: 1);
            int dty = DateTime.Now.Year;
            int bd = DateTime.DaysInMonth(dty, month);
            var weekends = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            IEnumerable<int> businessDaysInMonth = Enumerable.Range(1, bd)
                                                   .Where(d => !weekends.Contains(new DateTime(dty, month, d).DayOfWeek));

            var details = person.Days.SelectMany(x => x.Details).GroupBy(x => x.Team.Name).Select(x => new { team = x.Key, time = x.Sum(y => y.WorkTime) }).ToList();

            foreach (var detail in details)
            {
                dashboard.Details.Add(new ListModel { Category = detail.team, Count = (int)detail.time });
            }

            var days = person.Days.SelectMany(x => x.Details).GroupBy(x => x.Team.Name).Select(x => new { team = x.Key, time = x.Sum(y => y.WorkTime), empty = x.GroupBy(z => z.Day.Date).Count() }).ToList();

            foreach (var day in days)
            {
                dashboard.Empty.Add(new EmptyModel { Category = day.team, EmptyDays = businessDaysInMonth.Count() - day.empty });
            }

            if (person.Days.Count() == 0)
            {
                dashboard.Empty.Add(new EmptyModel { Category = "Days not logged", EmptyDays = businessDaysInMonth.Count() });
            }

            return dashboard;
        }
    }
}
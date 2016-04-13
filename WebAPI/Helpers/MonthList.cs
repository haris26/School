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
        public static MonthModel Create(Person person, int month)
        {
            MonthModel dashboard = new MonthModel(month)
            {
                Id = person.Id,
                Name = person.FullName,

            };
            //int dd = DateTime.Now.Month; //(year: 2016, month: 3, day: 1);
            int dty = DateTime.Now.Year;
            int bd = DateTime.DaysInMonth(dty, month);
            var weekends = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            IEnumerable<int> businessDaysInMonth = Enumerable.Range(1, bd)
                                                   .Where(d => !weekends.Contains(new DateTime(dty, month, d).DayOfWeek));

            var details = person.Days.SelectMany(x => x.Details).GroupBy(x => x.Team.Name).Select(x => new { team = x.Key, time = x.Sum(y => y.WorkTime) }).ToList();

            foreach (var detail in details)
            {
                dashboard.TotalHours = 0;
                dashboard.Details.Add(new ListModel { Category = detail.team, Count = (int)detail.time });
                dashboard.TotalHours = dashboard.Details.Sum(item => item.Count);
               
            }

            //var days = person.Days.SelectMany(x => x.Details).GroupBy(x => x.Team.Name).Select(x => new { team = x.Key, time = x.Sum(y => y.WorkTime), empty = x.GroupBy(z => z.Day.Date).Count() }).ToList();
            var days = person.Roles.SelectMany(x=> x.Person.Days).GroupBy(x=> x.Person.Teams).Select(x => new { team = x.Key, empty = x.GroupBy(z => z.Date).Count() });
            foreach (var day in days)
            {    
                dashboard.EmptyDays = businessDaysInMonth.Count() - day.empty;
            }
            if (person.Days.Count == 0)
            {
                dashboard.EmptyDays = businessDaysInMonth.Count();
            }
            if (month == DateTime.Now.Month || month == DateTime.Now.Month - 1)
            {
                string deadline = System.Configuration.ConfigurationManager.AppSettings["deadline"];
                int deadln = Convert.ToInt32(deadline);
                if (DateTime.Now.Day <= deadln)
                {
                    dashboard.DeadLineIn = deadln - DateTime.Now.Day;
                }
            }
           
            return dashboard;
        }
    }
}
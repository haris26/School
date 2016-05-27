using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ReportController : ApiController
    {
        [Route("api/report/{team}/{year}/{month}")]
        public IHttpActionResult Get(int team, int year, int month)
        {
            MonthModel1 result;
            using (SchoolContext context = new SchoolContext())
            {
                result = new MonthModel1()
                {
                    Team = context.Teams.Find(team).Name,
                    Year = year,
                    Month = month
                };
                var query = context.Details.Where(x => x.Team.Id == team && x.Day.Date.Month == month && x.Day.Date.Year == year)
                                           .GroupBy(x => x.Day.Person)
                                           .Select(x => new { id = x.Key.Id, name = x.Key.FirstName, hours = x.Sum(y => y.WorkTime) }).ToList();
                foreach (var item in query)
                {
                    MonthWork work = new MonthWork(year, month)
                    {
                        Id = item.id,
                        Name = item.name,
                        Hours = (int)item.hours
                    };
                    var days = context.Days.Where(x => x.Date.Month == month && x.Date.Year == year && x.Person.Id == item.id).ToList();
                    foreach (var d in days)
                    {
                        int index = d.Date.Day - 1;
                        work.Days[index].Hours = (int)d.WorkTime;
                        work.Days[index].Class = (d.WorkTime > 0) ? "WorkTime" : "Vacation";
                    }
                    result.Lista.Add(work);
                }
            }

            return Ok(result);

        }
         [Route("api/report/{team}/{year}/0")]
        public IHttpActionResult GetAll(int team, int year)
        {
                MonthModel1 result;           
                using (SchoolContext context = new SchoolContext())
                {
                    result = new MonthModel1()
                    {
                        Team = context.Teams.Find(team).Name,
                        Year = year,
                        Month = 0
                    };
                    var query = context.Details.Where(x => x.Team.Id == team && x.Day.Date.Year == year)
                                               .GroupBy(x => x.Day.Person)
                                               .Select(x => new { id = x.Key.Id, name = x.Key.FirstName, hours = x.Sum(y => y.WorkTime)}).ToList();
                    foreach (var item in query)
                    {
                    MonthWork work = new MonthWork(year, 1)
                    {
                        Id = item.id,
                        Name = item.name,
                        Hours = (int)item.hours,
                        Days = { },
                        Skip = { }

                        };
                        result.Lista.Add(work);
                    }
                }
            
            return Ok(result);

        }
    }
}
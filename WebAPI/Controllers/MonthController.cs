using Database;
using System.Web.Http;
using WebAPI.Filters;
using WebAPI.Services;
using WebAPI.Controllers;
using WebAPI.Helpers;
using WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WebAPI.Controllers
{
    [SchoolAuthorize]
    public class MonthController : BaseController<Person>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public MonthController(Repository<Person> depo) : base(depo)
        { }

        public IList<DashboardModel> Get()
        {

            var people = Repository.Get().OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                        .ToList();

            List<DashboardModel> list = new List<DashboardModel>();
            foreach (var p in people)
            {
                list.Add(Dashboard.Create(p));
            }
            return list;
        }
        public IList<DashboardModel> GetByMonth(int month)
        {

            var people = Repository.Get().OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                        .ToList();

            List<DashboardModel> list = new List<DashboardModel>();
            foreach (var p in people)
            {
                foreach (var day in p.Days.ToList())
                {
                    if (day.Date.Month != month)
                        p.Days.Remove(day);
                }

                list.Add(Dashboard.Create(p));

            }
            return list;
        }
    }
}

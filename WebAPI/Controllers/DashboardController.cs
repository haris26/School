using Database;
using System.Web.Http;
using WebAPI.Filters;
using WebApi.Services;
using WebAPI.Controllers;
using WebAPI.Helpers;
using WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WebApi.Controllers
{
    [SchoolAuthorize]
    public class DashboardController : BaseController<Person>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public DashboardController(Repository<Person> depo) : base(depo)
        { }

        public IHttpActionResult Get(int id)
        {
            Person person;
            if (id == 0)
            {
                person = ident.currentUser;
            }
            else
                person = Repository.Get(id);

            return Ok(Dashboard.Create(person));
        }

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
                foreach(var day in p.Days.ToList())
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
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class DashboardController : BaseController<Person>
    {
        public DashboardController(Repository<Person> depo) : base(depo)
        { }

        public IHttpActionResult Get(int id = 0)
        {
            Person person = Repository.Get(id);

            return Ok(Dashboard.Create(person));
        }
    }
}

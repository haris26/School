using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    public class DashboardController : BaseController<Person>
    {
        public DashboardController(Repository<Person> depo) : base(depo) { }

        public IHttpActionResult Get(int id = 0)
        {
            Person person;
            if (id == 0)
                person = AppGlobals.currentUser;
            else 
                person = Repository.Get(id);

            return Ok(Dashboard.Create(person));
        }
    }
}

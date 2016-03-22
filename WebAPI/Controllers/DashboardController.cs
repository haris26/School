using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Helpers;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [SchoolAuthorized]
    public class DashboardController : BaseController<Person>
    {
        SchoolIdentity identity = new SchoolIdentity();
        public DashboardController(Repository<Person> depo) : base(depo) { }

        public IHttpActionResult Get(int id = 0)
        {
            Person person;
            if (id == 0)
                person = identity.currentUser;
            else
                person = Repository.Get(id);
            return Ok(Dashboard.Create(person));
        }
    }
}

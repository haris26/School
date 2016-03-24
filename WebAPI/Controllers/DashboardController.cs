using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using WebAPI.Services;
using WebAPI.Filters;

using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers

{
    [SchoolAuthorize]
    public class DashboardController : BaseController<Person>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public DashboardController(Repository<Person> depo) : base(depo)
        { }

        public IHttpActionResult Get(int id=0)
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

    }
}

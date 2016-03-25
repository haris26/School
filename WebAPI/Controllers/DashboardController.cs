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
    [SchoolAuthorize(true)]
    public class DashboardController : BaseController<Person>
    {
        
        SchoolIdentity ident = new SchoolIdentity();

        public DashboardController(Repository<Person> depo) : base(depo)
        { }

        public IHttpActionResult Get(int id = 0)
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
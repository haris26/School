using Database;
using System.Web.Http;
<<<<<<< HEAD
using WebAPI.Services;
=======
>>>>>>> dfe22a165b44b08b5063d3e0daec9df28bbdf9b7
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
    [TokenAuthorize]
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
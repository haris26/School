using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using WebAPI.Models;
using Database;
using System.Web;
using System.Web.Http;
using WebAPI.Helpers;
using System.Configuration;

namespace WebAPI.Controllers
{
    public class DashboardController : BaseController<Person>
    {
        public DashboardController(Repository<Person> depo) : base(depo)
        { }

        public IHttpActionResult Get(int id = 0)
        {
            int CY = Convert.ToInt32(ConfigurationManager.AppSettings["currentYear"]);
            Person person = Repository.Get(id);

            return Ok(Dashboard.Create(person));
        }
    }
}
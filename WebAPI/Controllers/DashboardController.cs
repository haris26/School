using Database;
using System;
using System.Configuration;

using System.Web.Http;
using WebAPI.Helpers;



namespace WebAPI.Controllers

{
    public class DashboardController : BaseController<Person>
    {
        public DashboardController(Repository<Person> depo) : base(depo)
        { }

        public IHttpActionResult Get(int id = 0)
        {

            int CY = Convert.ToInt32(ConfigurationManager.AppSettings["currentYear"]);


            Person person;
            if (id == 0)
                person = AppGlobals.currentUser;
            else
                person = Repository.Get(id);


            return Ok(Dashboard.Create(person));
        }
    }
}
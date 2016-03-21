using Database;
using System.Web.Http;
using WebApi.Helpers;
using WebAPI.Controllers;
using WebAPI.Helpers;

namespace WebApi.Controllers
{
    public class DashboardController : BaseController<Person>
    {
        public DashboardController(Repository<Person> depo) : base(depo)
        { }

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
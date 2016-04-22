using Database;
using System.Web.Http;
using WebAPI.Filters;
using WebAPI.Helpers;


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

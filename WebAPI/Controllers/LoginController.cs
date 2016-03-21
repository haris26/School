using Database;
using System.Web.Http;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    public class LoginController : ApiController
    {
        Repository<Person> people = new Repository<Person>(new SchoolContext());

        public IHttpActionResult Get(int id)
        {
            try
            {
                Person person = people.Get(id);
                if (person != null)
                {
                    AppGlobals.currentUser = person;
                    return Ok(person.FirstName);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

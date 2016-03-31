using Database;
using System;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using WebApi.Helpers;
using WebMatrix.WebData;

namespace WebApi.Controllers
{
    public class UserModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }

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
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(person.FirstName), null);
                    //AppGlobals.currentUser = person;
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

        public IHttpActionResult Get()
        {
            if (!WebSecurity.Initialized) WebSecurity.InitializeDatabaseConnection("SchoolLocal", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            WebSecurity.Logout();
            return Ok();
        }

        public IHttpActionResult Post(UserModel user)
        {
            try
            {
                if (!WebSecurity.Initialized) WebSecurity.InitializeDatabaseConnection("SchoolLocal", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                WebSecurity.CreateUserAndAccount(user.username, user.password, false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

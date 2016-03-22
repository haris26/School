using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using Database;
using WebAPI.Helpers;
using WebMatrix.WebData;

namespace WebAPI.Controllers
{
    public class UserModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class LoginController : ApiController
    {
        private Repository<Person> people = new Repository<Person>(new SchoolContext());

        public IHttpActionResult Get(int id)
        {
            try
            {
                Person person = people.Get(id);
                if (person != null)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(person.FirstName), null);
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

        public IHttpActionResult Get()
        {
            if (!WebSecurity.Initialized) WebSecurity.InitializeDatabaseConnection("School", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            WebSecurity.Logout();
            return Ok();
        }

        public IHttpActionResult Post(UserModel user)
        {
            try
            {
                if (!WebSecurity.Initialized) WebSecurity.InitializeDatabaseConnection("School", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                WebSecurity.CreateUserAndAccount(user.username, user.password, false);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}

using Database;
using System;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using WebAPI.Helpers;
using WebAPI.Models;
using WebMatrix.WebData;

namespace WebAPI.Controllers
{

    public class UserModel
    {
        public string Email { get; set; }
        public string Signature { get; set; }
        public string ApiKey { get; set; }
    }

    public class LoginController : ApiController
    {
        public IHttpActionResult Get(string username, string password)
        {
            if (!WebSecurity.Initialized) WebSecurity.InitializeDatabaseConnection("School", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            WebSecurity.CreateUserAndAccount(username, password, false);
            return Ok();
        }

        public IHttpActionResult Post(UserModel user)
        {
            using (SchoolContext context = new SchoolContext())
            {
                Repository<Person> people = new Repository<Person>(context);
                Repository<ApiUser> users = new Repository<ApiUser>(context);
                Repository<AuthToken> tokens = new Repository<AuthToken>(context);

                Person person = people.Get().Where(x => x.Email == user.Email).FirstOrDefault();
                if (person != null)
                {
                    ApiUser apiUser = users.Get().Where(x => x.AppId == user.ApiKey).FirstOrDefault();
                    if (AppGlobals.Signature(apiUser.Secret, apiUser.AppId) == user.Signature)
                    {
                        AuthToken authToken = new AuthToken()
                        {
                            Token = AppGlobals.GenerateToken(apiUser),
                            Expiration = DateTime.UtcNow.AddMinutes(20),
                            ApiUser = apiUser
                        };
                        tokens.Insert(authToken);

                        TokenModel Credentials = new TokenModel()
                        {
                            Id = person.Id,
                            Name = person.FullName,
                            Roles = AppGlobals.GetRoles(person),
                            Token = authToken.Token,
                            Expiration = authToken.Expiration
                        };
                        return Ok(Credentials);
                    }
                    else return Unauthorized();
                }
                else return Unauthorized();
            }
        }
    }
}


//using Database;
//using System;
//using System.Security.Principal;
//using System.Threading;
//using System.Web.Http;
//using WebAPI.Helpers;
//using WebMatrix.WebData;

//namespace WebApi.Controllers
//{
//    public class UserModel
//    {
//        public string username { get; set; }
//        public string password { get; set; }
//    }

//    public class LoginController : ApiController
//    {
//        Repository<Person> people = new Repository<Person>(new SchoolContext());

//        public IHttpActionResult Get(int id)
//        {
//            try
//            {
//                Person person = people.Get(id);
//                if (person != null)
//                {
//                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(person.FirstName), null);
//                    AppGlobals.currentUser = person;
//                    return Ok(person.FirstName);
//                }
//                else
//                {
//                    return NotFound();
//                }
//            }
//            catch
//            {
//                return BadRequest();
//            }
//        }

//        public IHttpActionResult Get()
//        {
//            if (!WebSecurity.Initialized) WebSecurity.InitializeDatabaseConnection("School", "UserProfile", "UserId", "UserName", autoCreateTables: true);
//            WebSecurity.Logout();
//            return Ok();
//        }

//        public IHttpActionResult Post(UserModel user)
//        {
//            try
//            {
//                if (!WebSecurity.Initialized) WebSecurity.InitializeDatabaseConnection("School", "UserProfile", "UserId", "UserName", autoCreateTables: true);
//                WebSecurity.CreateUserAndAccount(user.username, user.password, false);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//    }
//}

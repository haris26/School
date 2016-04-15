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
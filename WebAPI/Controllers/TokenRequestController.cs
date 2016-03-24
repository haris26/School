using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Filters;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [SchoolAuthorized]
    public class TokenRequestController : BaseController<AuthToken>
    {
        public TokenRequestController(Repository<AuthToken> depo) : base(depo)
        { }

        public IHttpActionResult Post(TokenRequestModel request)
        {
            try
            {
                ApiUser user = Repository.BaseContext().ApiUsers.Where(x => x.AppId == request.ApiKey).FirstOrDefault();
                if (user == null) return BadRequest();
                if (AppGlobals.Signature(user.Secret, user.AppId) == request.Signature)
                {
                    AuthToken authToken = new AuthToken()
                    {
                        Token = AppGlobals.GenerateToken(user),
                        Expiration = DateTime.UtcNow.AddMinutes(20),
                        ApiUser = user
                    };
                    Repository.Insert(authToken);
                    return Ok(Factory.Create(authToken));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Filters;
using WebAPI.Helpers;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [SchoolAuthorize]
    public class TokenRequestController : BaseController<AuthToken>
    {
        public TokenRequestController(Repository<AuthToken> depo) : base(depo)
        { }

        SchoolIdentity ident = new SchoolIdentity();

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

                    TokenModel Credentials = new TokenModel()
                    {
                        Id = ident.currentUser.Id,
                        Name = ident.currentUser.FullName,
                        Roles = AppGlobals.GetRoles(ident.currentUser),
                        Token = authToken.Token,
                        Expiration = authToken.Expiration
                    };
                    return Ok(Credentials);
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
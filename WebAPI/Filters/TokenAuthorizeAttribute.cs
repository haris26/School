using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Database;
using WebMatrix.WebData;
using WebAPI.Helpers;
using System.Linq;
using System;
using System.Net;
using System.Net.Http;

namespace WebAPI.Filters
{
  
    public class TokenAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                string ApiKey = actionContext.Request.Headers.GetValues("ApiKey").SingleOrDefault();
                string Token = actionContext.Request.Headers.GetValues("Token").SingleOrDefault();

                Repository<AuthToken> tokens = new Repository<AuthToken>(new SchoolContext());
                AuthToken authToken = tokens.Get().Where(x => x.Token == Token).FirstOrDefault();
                if (authToken != null)
                {
                    if (authToken.ApiUser.AppId == ApiKey && authToken.Expiration > DateTime.UtcNow) return;
                }
                HandleUnauthorize(actionContext);
            }
            catch
            {
                HandleUnauthorize(actionContext);
            }
        }

        public void HandleUnauthorize(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            // actionContext.Response.Headers.Add("WWW-Authenticate", "Basic Scheme='SchoolContext' location=''");
            // location='http://localhost:444/accounts/login'
        }
    }
}
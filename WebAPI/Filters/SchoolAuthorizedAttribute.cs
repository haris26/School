using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Database;
using WebAPI.Helpers;
using WebMatrix.WebData;

namespace WebAPI.Filters
{
    public class SchoolAuthorizedAttribute:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated) return;

            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader != null)
            {
                if (authHeader.Scheme.ToLower() == "basic" && authHeader.Parameter != "")
                {
                    var rawCredentials = authHeader.Parameter;
                    var encoding = Encoding.GetEncoding("iso-8859-1");
                    string credentials = encoding.GetString(Convert.FromBase64String(rawCredentials));
                    string[] split = credentials.Split(':');
                    string username = split[0];
                    string password = split[1];

                    if (!WebSecurity.Initialized) WebSecurity.InitializeDatabaseConnection("SchoolLocal", "UserProfile", "UserId", "UserName", autoCreateTables: true);

                    if (WebSecurity.Login(username, password))
                    {
                        var principal = new GenericIdentity(username);
                        Thread.CurrentPrincipal = new GenericPrincipal(principal, null);
                        return;
                    }
                }
            }
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic Scheme='SchoolContext' location=''");
            // location='http://localhost:444/accounts/login'
        }
    }
}
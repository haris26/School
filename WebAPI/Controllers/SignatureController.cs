using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    public class SignatureController : ApiController
    {
        Repository<ApiUser> apiUsers = new Repository<ApiUser>(new SchoolContext());

        public string Get()
        {
            var apiUser = apiUsers.Get().First();
            apiUsers.Insert(new ApiUser()
            {
                Name = "School",
                AppId = "R2lnaVNjaG9vbA==",
                Secret = "TWlzdHJhbFRhbGVudHM="
            });

            return AppGlobals.Signature(apiUser.Secret, apiUser.AppId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Filters;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    //[TokenAuthorize]
    public class UserReservationsController : ApiController
    {
        public IHttpActionResult Get()
        {
           return Ok(UserReservations.Create());
        }
    }
}

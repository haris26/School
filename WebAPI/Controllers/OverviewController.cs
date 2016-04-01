using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Helpers;
using WebAPI.Filters;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [TokenAuthorize]
    public class OverviewController : BaseController<Person>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public OverviewController(Repository<Person> depo) : base(depo)
        { }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(Overview.Create(Repository.BaseContext()));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }
    }
}

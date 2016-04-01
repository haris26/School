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
    public class OverviewController : BaseController<Person>
    {
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

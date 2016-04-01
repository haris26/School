using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;
using WebAPI.Helpers;
using WebAPI.Filters;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [TokenAuthorize]
    public class FindPeopleController : BaseController<EmployeeSkill>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public FindPeopleController(Repository<EmployeeSkill> depo) : base(depo) { }

        [HttpPost]
        public IHttpActionResult FindPeople ([FromBody] SearchModel search)
        {
            try
            {
                return Ok(SearchResult.Create(Repository.BaseContext(), search));
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

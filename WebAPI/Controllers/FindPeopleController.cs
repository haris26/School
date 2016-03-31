using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    public class FindPeopleController : BaseController<EmployeeSkill>
    {
        public FindPeopleController(Repository<EmployeeSkill> depo) : base(depo) { }

        [HttpPost]
        public IHttpActionResult FindPeople ([FromBody] SearchModel search)
        {
            //try
            //{
                return Ok(SearchResult.Create(Repository.BaseContext(), search));
            //}
            //catch(Exception ex)
            //{
            //    return BadRequest();
            //}
        }
    }
}

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
    [SchoolAuthorize]
    public class EmployeeAssessmentsController : BaseController<Person>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public EmployeeAssessmentsController(Repository<Person> depo) : base(depo)
        { }

        public IHttpActionResult Get (int id = 0)
        {
            try
            {
                Person person;
                if (id == 0)
                    person = ident.currentUser;
                else
                {
                    person = Repository.Get(id);
                    if (person == null)
                    {
                        return NotFound();
                    }
                }
                return Ok(EmployeeAssessment.Create(person));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

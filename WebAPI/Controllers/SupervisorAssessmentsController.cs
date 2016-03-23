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
    public class SupervisorAssessmentsController : BaseController<Person>
    {
        public SupervisorAssessmentsController(Repository<Person> depo) : base(depo)
        { }

        public IHttpActionResult Get(int id = 0)
        {
            try
            {
                Person person;
                if (id == 0)
                    person = AppGlobals.currentUser;
                else
                {
                    person = Repository.Get(id);
                    if (person == null)
                    {
                        return NotFound();
                    }
                }
                return Ok(SupervisorAssessment.Create(person));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

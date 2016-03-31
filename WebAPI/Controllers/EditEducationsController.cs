using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using System.Web;
using WebAPI.Helpers;
using WebAPI.Filters;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [TokenAuthorize]
    public class EditEducationsController : BaseController<Person>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public EditEducationsController(Repository<Person> depo):base(depo)
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
                return Ok(person.EmployeeEducations.ToList().Select(x => Factory.Create(x)).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

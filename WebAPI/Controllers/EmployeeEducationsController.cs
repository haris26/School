using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Filters;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [TokenAuthorize]
    public class EmployeeEducationsController : BaseController<EmployeeEducation>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public EmployeeEducationsController(Repository<EmployeeEducation> depo) : base(depo)
        { }

        public IHttpActionResult Post(EmployeeEducationModel model)
        {
            try
            {
                Repository.Insert(Parser.Create(model, Repository.BaseContext()));
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int id, EmployeeEducationModel model)
        {
            try
            {
                EmployeeEducation oldEmpEdu = Repository.Get(id);
                if (oldEmpEdu == null)
                    return NotFound();
                else
                    Repository.Update(Parser.Create(model, Repository.BaseContext()), model.Id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                EmployeeEducation employeeeducation = Repository.Get(id);
                if (employeeeducation == null)
                    return NotFound();
                else
                    Repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

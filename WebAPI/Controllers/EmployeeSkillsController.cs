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
    //[TokenAuthorize]
    public class EmployeeSkillsController : BaseController<EmployeeSkill>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public EmployeeSkillsController(Repository<EmployeeSkill> depo) : base(depo)
        { }

        public IHttpActionResult Post(EmployeeSkillModel model)
        {
            var skillAssessment = Repository.Get().ToList().Where(x => x.Employee.Id==model.Employee && x.Tool.Id==model.Tool && x.AssessedBy==AssessmentType.Self).FirstOrDefault();
            if (skillAssessment == null)
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
            else {
                model.Id = skillAssessment.Id;
                return Put(skillAssessment.Id,model);
            }
        }

        public IHttpActionResult Put(int id, EmployeeSkillModel model)
        {
            try
            {
                EmployeeSkill oldEmpSkill = Repository.Get(id);
                if (oldEmpSkill == null)
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
                EmployeeSkill employeeskill = Repository.Get(id);
                if (employeeskill == null)
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

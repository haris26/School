using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [TokenAuthorize]
    public class ProjectSkillsController : BaseController<ProjectSkill>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public ProjectSkillsController(Repository<ProjectSkill> depo) : base(depo)
        { }

        public IHttpActionResult Post(ProjectSkillModel model)
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

        public IHttpActionResult Put(int id, ProjectSkillModel model)
        {
            try
            {
                ProjectSkill oldProjectSkill = Repository.Get(id);
                if (oldProjectSkill == null)
                    return NotFound();
                else
                    Repository.Update(Parser.Create(model, Repository.BaseContext()), id);
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
                ProjectSkill projectSkill = Repository.Get(id);
                if (projectSkill == null)
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

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
    public class SkillsCategoriesController : BaseController<SkillCategory>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public SkillsCategoriesController(Repository<SkillCategory> depo) : base(depo)
        { }

        public IList<SkillCategoryModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                SkillCategory skillcategory = Repository.Get(id);
                if (skillcategory == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(Repository.Get(id)));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(SkillCategory skillcategory)
        {
            try
            {
                Repository.Insert(skillcategory);
                return Ok(Factory.Create(skillcategory));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int id, SkillCategory skillcategory)
        {
            try
            {
                SkillCategory oldSkillcategory = Repository.Get(id);
                if (oldSkillcategory == null)
                    return NotFound();
                else
                    Repository.Update(skillcategory, id);
                    return Ok(Factory.Create(skillcategory));
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
                SkillCategory skillcategory = Repository.Get(id);
                if (skillcategory == null)
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
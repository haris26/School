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
    [RoutePrefix("api/skillscategories")]
    public class SkillsCategoriesController : BaseController<SkillCategory>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public SkillsCategoriesController(Repository<SkillCategory> depo) : base(depo)
        { }

        public IList<SkillCategoryModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }
        [Route("{id:int}")]
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

        [Route("{name}")]
        public List<SkillCategoryModel> Get(string name)
        {
            return Repository.Get().Where(x => x.Name == name).ToList()
                             .Select(x => Factory.Create(x)).ToList();

        }

        [HttpPost]
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
        [Route("{id:int}")]
        [HttpPut]
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
        [Route("{id:int}")]
        [HttpDelete]
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
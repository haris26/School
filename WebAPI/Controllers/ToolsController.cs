using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Helpers;
using WebAPI.Filters;
using WebAPI.Services;
using System.Text;

namespace WebAPI.Controllers
{
    //[TokenAuthorize]
    [RoutePrefix("api/tools")]
    public class ToolsController : BaseController<Tool>
    {
        //SchoolIdentity ident = new SchoolIdentity();

        public ToolsController(Repository<Tool> depo) : base(depo)
        { }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(Criteria.Create(Repository.BaseContext()));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Tool tool = Repository.Get(id);
                if (tool == null)
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
        public List<ToolModel> Get(string name)
        {
            byte[] aName = Convert.FromBase64String(name);
            string realName = Encoding.UTF8.GetString(aName);
            return Repository.Get().Where(x => x.Name == realName).ToList()
                             .Select(x => Factory.Create(x)).ToList();

        }

        [HttpPost]
        public IHttpActionResult Post(ToolModel model)
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

        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult Put(int id, ToolModel model)
        {
            try
            {
                Tool tool = Parser.Create(model, Repository.BaseContext());
                Repository.Update(tool, id);
                return Ok(Factory.Create(tool));
            }
            catch
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
                Tool tool = Repository.Get(id);
                if (tool == null)
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

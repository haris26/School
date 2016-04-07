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

namespace WebAPI.Controllers
{
    //[TokenAuthorize]
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

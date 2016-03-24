using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    public class ToolsController : BaseController<Tool>
    {
        
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
                Tool oldTool = Repository.Get(id);
                if (oldTool == null)
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

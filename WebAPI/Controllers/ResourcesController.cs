using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ResourcesController : BaseController<Resource>
    {
        public ResourcesController(Repository<Resource> depo) : base(depo) { }
        
        public List<ResourceModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                Resource resource = Repository.Get(id);
                if (resource == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(resource));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Post(ResourceModel model)
        {
            try
            {
                Repository.Insert(Parser.Create(model, Repository.BaseContext()));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Put(ResourceModel model)
        {
            try
            {
                Resource resource = Parser.Create(model, Repository.BaseContext());
                Repository.Update(resource, resource.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }
        public IHttpActionResult Delete (int id)
        {
            Repository.Delete(id);
            return Ok();
        }
    }
}

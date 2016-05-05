using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    //[TokenAuthorize]
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

        public IHttpActionResult Put(int id, ResourceModel model)
        {
            try
            {
                Resource resource = Repository.Get(id);
                if (resource == null)
                {
                    return NotFound();
                }
                else
                {
                    Repository.Update(Parser.Create(model, Repository.BaseContext()), resource.Id);
                    return Ok(model);
                }
                            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }

        public IHttpActionResult Delete (int id)
        {
            try
            {
                Resource resource = Repository.Get(id);
                if (resource == null)
                    return NotFound();
                else
                {
                    Repository.Delete(id);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

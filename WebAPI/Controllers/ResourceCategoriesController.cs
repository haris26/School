using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ResourceCategoriesController : BaseController<ResourceCategory>
    {
        public ResourceCategoriesController(Repository<ResourceCategory> depo) : base(depo) { }

        public List<ResourceCategoryModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }
        public IHttpActionResult Get (int id)
        {
            try
            {
                ResourceCategory resourceCat = Repository.Get(id);
                if (resourceCat == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(resourceCat)); 
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Post (ResourceCategoryModel model)
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
        public IHttpActionResult Put (ResourceCategoryModel model)
        {
            try
            {
                ResourceCategory resourceCat = Parser.Create(model, Repository.BaseContext());
                if (resourceCat == null)
                    return NotFound();
                else
                {
                    Repository.Update(resourceCat, resourceCat.Id);
                    return Ok(Factory.Create(resourceCat));
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
                ResourceCategory resourceCat = Repository.Get(id);
                if (resourceCat == null)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    public class AssetCategoriesController : BaseController<AssetCategory>
    {
        public AssetCategoriesController(Repository<AssetCategory> depo) : base(depo)
        { }

        public IList<AssetCategoriesModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                AssetCategory category = Repository.Get(id);
                if (category == null)
                    return NotFound();
                else return
                        Ok(Factory.Create(category));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        public IHttpActionResult Post(AssetCategory category)
        {
            try
            {
                Repository.Insert(category);
                return Ok(Factory.Create(category));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        public AssetCategoriesModel Put(int id, AssetCategory category)
        {
            Repository.Update(category, id);
            return Factory.Create(category);
        }

        public IHttpActionResult Delete(int id)
        {
            Repository.Delete(id);
            return Ok();

        }
    }
}
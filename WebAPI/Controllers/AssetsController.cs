using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Controllers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AssetsController : BaseController<Asset>
    {
        public AssetsController(Repository<Asset> depo) : base(depo)
        { }

        public IList<AssetsModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Asset asset = Repository.Get(id);
                if (asset == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(asset));
                            
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(Asset asset)
        {
            try
            {
                Repository.Insert(asset);
                return Ok(Factory.Create(asset));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        public IHttpActionResult Put(int id, Asset asset)
        {
            try
            {
                Repository.Update(asset, id);
                if (asset == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(asset));

            }
               
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            Repository.Delete(id);
            return Ok();

        }
    }
}
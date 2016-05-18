using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class AssetController : BaseController<Asset>
    {
        public AssetController(Repository<Asset> depo) : base(depo)
        { }


        public IHttpActionResult Get(int id)
        {
            try
            {
                Asset asset = Repository.Get(id);
                if (asset == null)
                {
                    return NotFound();

                }
                else

                    return Ok(Factory.Create(asset));

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}

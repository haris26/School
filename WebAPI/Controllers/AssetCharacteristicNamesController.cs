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
    public class AssetCharacteristicNamesController : BaseController<AssetCharacteristicNames>
    {
        public AssetCharacteristicNamesController(Repository<AssetCharacteristicNames> depo) : base(depo) { }

        public IList<AssetCharacteristicNamesModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();

        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                AssetCharacteristicNames name = Repository.Get(id);
                if (name == null)
                {
                    return NotFound();

                }
                else

                    return Ok(Factory.Create(name));

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(AssetCharacteristicNamesModel model)
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

        public IHttpActionResult Put(int id, AssetCharacteristicNamesModel model)
        {
            try
            {
                Repository.Update(Parser.Create(model, Repository.BaseContext()), model.Id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }


        public IHttpActionResult Delete(int id)
        {
            try
            {
                Repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}

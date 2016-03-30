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
    public class CharacteristicNamesController : BaseController<CharacteristicName>
    {
        public CharacteristicNamesController(CharacteristicNameUnit depo) : base(depo)
        { }

        public IList<CharacteristicNameModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                CharacteristicName chName = Repository.Get(id);
                if (chName == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(Repository.Get(id)));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(CharacteristicNameModel model)
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

        public IHttpActionResult Put(int id, CharacteristicNameModel model)
        {
            try
            {
                CharacteristicName chName = Repository.Get(id);
                if (chName == null)
                    return NotFound();
                else
                {
                    Repository.Update(Parser.Create(model, Repository.BaseContext()), chName.Id);
                    return Ok(model);
                }
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
                CharacteristicName chName = Repository.Get(id);
                if (chName == null)
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

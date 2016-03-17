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
    public class DetailsController : BaseController<Detail>
    {
        public DetailsController(Repository<Detail> depo) : base(depo)
        { }

        public IList<DetailModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Detail detail = Repository.Get(id);
                if (detail == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(detail));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Post(DetailModel model)
        {
            var sch = Repository.BaseContext();

            try
            {
                if (model == null) return NotFound();
                else {
                    Repository.Insert(Parser.Create(model, sch));
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Put(int id, DetailModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                Detail detail1 = Repository.Get(id);
                if (detail1 == null || model == null) return NotFound();
                else {
                    Repository.Update(Parser.Create(model, sch), id);
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
                Detail detail = Repository.Get(id);
                if (detail == null)
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

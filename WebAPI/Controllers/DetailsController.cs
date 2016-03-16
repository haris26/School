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
            try {
                var detail = Repository.Get(id);
                if (detail == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(detail));
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(Detail detail)
        {
            try {
                Repository.Insert(detail);
                return Ok(Factory.Create(detail));
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int id, Detail detail)
        {
            try
            {
                Repository.Insert(detail);
                return Ok(Factory.Create(detail));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try { 
            Repository.Delete(id);
            return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

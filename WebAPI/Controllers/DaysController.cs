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
    public class DaysController : BaseController<Day>
    {

        
        public DaysController(Repository<Day> depo) : base(depo) {}
        
        public IList<DayModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var day = Repository.Get(id);
                if (day == null)
                {
                    return NotFound();
                }
                else
                    return Ok(Factory.Create(day));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
                
        }

        public IHttpActionResult Post(Day day)
        {
            try {
                Repository.Insert(day);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int id, Day day)
        {
            try
            {
                Repository.Update(day, id);
                return Ok();
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

using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Controllers.WebAPI.Controllers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DaysController : BaseController<Day>
    {

        public DaysController(Repository<Day> depo) : base(depo)
        { }

        public IList<DayModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id)
        {

            try {
                Day day = Repository.Get(id);
                if (day == null) return NotFound();
                else
                return Ok(Factory.Create(Repository.Get(id)));
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Post(DayModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                if (model == null) return NotFound();
                else {
                    Repository.Insert(Parser.Create(model,sch));
                    return Ok(model);
                }
            }
            catch (Exception ex) {
                return BadRequest();
            }
            
        }
        public IHttpActionResult Put(int id, DayModel model)
        {
            var sch = Repository.BaseContext();
            try {
                Day day1 = Repository.Get(id);
                if (day1==null || model == null) return NotFound();
                else {
                    Repository.Update(Parser.Create(model,sch), id);
                    return Ok(model);
                }
            }
            catch(Exception ex)

            {
                return BadRequest();
            }
        }

        public IHttpActionResult Delete(int id)
        {


            try
            {
                Day day = Repository.Get(id);
                if (day == null) return NotFound();
                else {
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

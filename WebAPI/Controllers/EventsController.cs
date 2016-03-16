using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EventsController : BaseController<Event>
    {
        public EventsController(Repository<Event> depo) : base(depo)
        { }

        public IList<EventModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Event ev = Repository.Get(id);
                if (ev == null)
                    return NotFound();
                else 
                    return Ok(Factory.Create(ev));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(EventModel ev)
        {
            try
            {
                Repository.Insert(Parser.Create(ev, Repository.BaseContext()));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(EventModel ev)
        {
            try
            {
                Event e = Parser.Create(ev, Repository.BaseContext());
                if (e == null)
                    return NotFound();
                else
                {
                    Repository.Update(e, e.Id);
                    return Ok(Factory.Create(e));
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
                Event e = Repository.Get(id);
                if (e == null)
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

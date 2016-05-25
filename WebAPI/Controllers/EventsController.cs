using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;
using WebAPI.Helpers;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    //[TokenAuthorize]
    public class EventsController : BaseController<Event>
    {
        //Person currentPerson = AppGlobals.currentUser;

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
                if (ev == null)
                {
                    return BadRequest();
                }

                else {
                    Repository.Insert(EventRestriction.Create(ev, Repository.BaseContext()));
                    return Ok();
                }

            }
               
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int id, EventModel model)
        {
            try
            {
                Event e = Repository.Get(id);
                if (e == null)
                    return NotFound();
                else
                {
                    Repository.Update(Parser.Create(model, Repository.BaseContext()), e.Id);
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

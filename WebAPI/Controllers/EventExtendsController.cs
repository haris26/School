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
    public class EventExtendsController : BaseController<ExtendedEvent>

    {
        public EventExtendsController(Repository<ExtendedEvent> depo) : base(depo)
        { }

        public IList<EventExtendModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                ExtendedEvent extendedEvent = Repository.Get(id);
                if (extendedEvent == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(extendedEvent));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(EventExtendModel extendEvent)
        {
            try
            {
                Repository.Insert(Parser.Create(extendEvent, Repository.BaseContext()));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(EventExtendModel extendedEvent)
        {
            try
            {
                ExtendedEvent e = Parser.Create(extendedEvent, Repository.BaseContext());
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
                ExtendedEvent e = Repository.Get(id);
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
                                                                               
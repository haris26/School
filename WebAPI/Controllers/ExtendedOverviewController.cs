using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Filters;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [TokenAuthorize]
    public class ExtendedOverviewController : BaseController<ExtendedEvent>
    {
        public ExtendedOverviewController(Repository<ExtendedEvent> depo) : base(depo)
        { }

        public IHttpActionResult Get()
        {
            return Ok(ExtendedOverview.Create(Repository.BaseContext()));
        }

        public IHttpActionResult Get(int id)
        {
            ExtendedEvent extendedEvent = ExtendedOverview.Get(id, Repository.BaseContext());
            try
            {
                if (extendedEvent == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(extendedEvent));
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}

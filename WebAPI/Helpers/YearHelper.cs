using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Controllers;

namespace WebAPI.Helpers

{
    public class YearController : BaseController<Day>
    {
        public YearController(Repository<Day> depo) : base(depo)
        { }
        public IHttpActionResult Get()
        {
            var query = Repository.Get().OrderBy(x => x.Date)
                            .Select(s => s.Date.Year)
                            .Distinct()
                            .ToList();
            return Ok(query);
        }
    }
}
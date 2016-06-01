using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Controllers;

namespace WebAPI.Helpers

{
    public class YearModel
    {
        public string year;
    }

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

            //List<YearModel> years = new List<YearModel>();

            //foreach (var y in query)
            //{

            //    //new YearModel()
                
            //}

            return Ok(query);
        }
    }
}
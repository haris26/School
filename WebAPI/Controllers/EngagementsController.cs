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
    public class EngagementsController : BaseController<Engagement>
    {
        public EngagementsController(Repository<Engagement> depo) : base(depo)
        { }

        public IList<EngagementModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }
    }
}
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class TeamsController : BaseController<Team>
    {
        public TeamsController(Repository<Team> depo) : base(depo)
        { }

        public IList<TeamModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }
    }
}

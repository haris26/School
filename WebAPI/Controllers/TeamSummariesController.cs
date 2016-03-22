using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TeamSummariesController : BaseController<Team>
    {
        public TeamSummariesController(Repository<Team> depo) : base(depo)
        { }

        public IList<TeamModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Team team;
                team = Repository.Get(id);
                if (team == null)
                {
                    return NotFound();
                }
                return Ok(TeamSummary.Create(team));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}

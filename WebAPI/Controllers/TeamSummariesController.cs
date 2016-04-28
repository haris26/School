using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Helpers;
using WebAPI.Models;
using WebAPI.Filters;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    //[TokenAuthorize]
    public class TeamSummariesController : BaseController<Team>
    {
        //SchoolIdentity ident = new SchoolIdentity();

        public TeamSummariesController(Repository<Team> depo) : base(depo)
        { }

        public IList<TeamSummaryModel> Get()
        {
            return Repository.Get().Where(x =>x.Type != ProjectType.Absence)
                                   .ToList().Select(x => TeamSummary.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Team team = Repository.Get(id);
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

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
    public class TeamsController : BaseController<Team>
    {
        public TeamsController(Repository<Team> depo) : base(depo)
        { }

        public IList<TeamModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Team team = Repository.Get(id);
                if (team == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(Repository.Get(id)));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(Team team)
        {
            try
            {
                Repository.Insert(team);
                return Ok(Factory.Create(team));
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int id, Team team)
        {
            try
            {
                Repository.Update(team, id);
                return Ok(Factory.Create(team));
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
                Team team = Repository.Get(id);
                if (team == null)
                    return NotFound();
                else
                    Repository.Delete(id);
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}

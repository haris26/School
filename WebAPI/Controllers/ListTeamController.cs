using Database;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Services;
using WebAPI.Helpers;
using WebAPI.Models;
using System;
using System.Configuration;
using System.Web.Configuration;

namespace WebAPI.Controllers
{
    public class ListTeamController : BaseController<Team>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public ListTeamController(Repository<Team> depo) : base(depo)
        { }

        public IList<ListTeamsModel> Get()
        {
            int month;
            string deadline = System.Configuration.ConfigurationManager.AppSettings["deadline"];
            if (DateTime.Now.Day <= Convert.ToInt32(deadline))
                month = DateTime.Now.Month - 1;
            else month = DateTime.Now.Month;
            var teams = Repository.Get().OrderBy(x => x.Name)
                        .ToList();

            List<ListTeamsModel> list = new List<ListTeamsModel>();
            foreach (var t in teams)
            {
                foreach (var day in t.Details.ToList())
                {
                    if (day.Day.Date.Month != month) //making the default landing page api/listteam to refer to current month
                    {
                        t.Details.Remove(day);
                    }
                }
                list.Add(ListTeams.Create(t, month));
            }
            return list;
        }

        public IList<ListTeamsModel> GetByMonth(int month)
        {
            var teams = Repository.Get().OrderBy(x => x.Name).ToList();
            Engagement eng = new Engagement();
            List<ListTeamsModel> list = new List<ListTeamsModel>();
            foreach (var t in teams)
            {
                foreach (var day in t.Details.ToList())  //making sure only details included into the month we have forwarded are included, and everthying
                {                                        //else is hidden
                    if (day.Day.Date.Month != month)
                    {
                        t.Details.Remove(day);
                    }
                }
                list.Add(ListTeams.Create(t, month));
            }
            return list;
        }
    }
}
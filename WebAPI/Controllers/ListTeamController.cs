using Database;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Services;
using WebAPI.Helpers;
using WebAPI.Models;
using System;

namespace WebAPI.Controllers
{
    public class ListTeamController : BaseController<Team>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public ListTeamController(Repository<Team> depo) : base(depo)
        { }

        public IList<ListTeamsModel> Get()
        {

            var teams = Repository.Get().OrderBy(x => x.Name)
                        .ToList();

            List<ListTeamsModel> list = new List<ListTeamsModel>();
            foreach (var t in teams)
            {
                list.Add(ListTeams.Create(t));
            }
            return list;
        }


        public IList<ListTeamsModel> GetByMonth(int month)
        {

            int dd = DateTime.Now.Month; //(year: 2016, month: 3, day: 1);
            int dty = DateTime.Now.Year;
            int bd = DateTime.DaysInMonth(dty, dd);
            var weekends = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            IEnumerable<int> businessDaysInMonth = Enumerable.Range(1, bd)
                                                   .Where(d => !weekends.Contains(new DateTime(dty, dd, d).DayOfWeek));

            var teams = Repository.Get().OrderBy(x => x.Name)
                   .ToList();
            ListTeamsModel model = new ListTeamsModel();
            List<ListTeamsModel> list = new List<ListTeamsModel>();
            foreach (var t in teams)
            {
                foreach (var day in t.Details.ToList())
                {
                    if (day.Day.Date.Month != month)
                        t.Details.Remove(day);
                    if (month == day.Day.Date.Month)
                    {
                        model.MissedDays = businessDaysInMonth.Count(); 
                    }
                } 

                list.Add(ListTeams.Create(t));

            }
            return list;
        }
    }
}

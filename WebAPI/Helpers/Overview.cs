using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using Database;

namespace WebAPI.Helpers
{
    public static class Overview
    {
        public static OverviewModel Create(SchoolContext context)
        {
            OverviewModel overview = new OverviewModel();
            var people = context.People.ToList();

            overview.NumOfPeople = context.People.ToList().Count();
            overview.NumOfTeams = context.Teams.ToList().Count();
            overview.NumOfSkills = context.Tools.ToList().Count();
            overview.AvgSkillLevel = people.Select(x => SearchResult.GetCurrentSkills(x)).ToList()
                                           .Where(x => x.Count() > 0).Select(x => x.Average(y => (int)y.Level)).Sum()/people.Count();
                             
            return overview;
        }
    }
}
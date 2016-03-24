using Database;
using System.Collections.Generic;
using System.Linq;
using WebApi.Services;
using WebAPI.Helpers;
using WebAPI.Models;

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
    }
}



//        public IList<ListTeamsModel> GetByTeam(int month)
//        {

//            var teams = Repository.Get().OrderBy(x => x.Name).ThenBy(x => x.Members)
//                        .ToList();

//            List<ListTeamsModel> list = new List<ListTeamsModel>();
//            foreach (var t in teams)
//            {
//                foreach (var day in t.Days.ToList())
//                {
//                    if (day.Date.Month != month)
//                        p.Days.Remove(day);
//                }

//                list.Add(MonthList.Create(p));

//            }
//            return list;
//        }
//    }
//}

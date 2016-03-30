//using Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using WebAPI.Models;


//namespace WebAPI.Helpers
//{
//    public class ListTeams
//    {
//        public static ListTeamsModel Create(Team team, int month)
//        {
//         //   Person person = new Person();



//            ListTeamsModel listteam = new ListTeamsModel()
//            {
//                Id = team.Id,
//                Name = team.Name,

//            };

//            //Declaring DateTime variables in order to select only working days for each month
//            int dd = month;
//            int dty = DateTime.Now.Year;
//            int bd = DateTime.DaysInMonth(dty, dd);
//            var weekends = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
//            IEnumerable<int> businessDaysInMonth = Enumerable.Range(1, bd)
//                                                   .Where(d => !weekends.Contains(new DateTime(dty, dd, d).DayOfWeek));

//            //Getting details sorted by Persons and forwarding time worked and days not logged into Members list
//            var members = team.Details.GroupBy(x => x.Day.Person.FullName).Select(x => new { person = x.Key, time = x.Sum(y => y.WorkTime), empty = x.GroupBy(z => z.Day.Date).Count() }).ToList();

//            foreach (var det in members)
//            {
//                listteam.Members.Add(new CountModel { Category = det.person, Count = (int)det.time, EmptyDays = businessDaysInMonth.Count() - det.empty });
//            }

//            //Getting details for the entire team and forwarding overall team work time invested
//            var time = team.Details.GroupBy(x => x.Team).Select(x => new { team = x.Key, time = x.Sum(y => y.WorkTime) }).ToList();

//            foreach (var tm in time)
//            {
//                listteam.Details.Add(new ListModel { Category = "Overall time worked", Count = (int)tm.time });
//            }

//            //Getting day count from Details table and forwarding it to display overall team days invested
//            var days = team.Details.GroupBy(x => x.Team).Select(x => new { type = x.Key, days = x.GroupBy(z => z.Day.Date).Count() }).ToList();

//            foreach (var day in days)
//            {
//                listteam.Days.Add(new ListModel { Category = "Overall days worked", Count = (int)day.days });
//            }

//            //Displaying days not logged for the entire team
//            foreach (var d in members)
//            {
//                listteam.MissedDays = businessDaysInMonth.Count() - d.empty;
//            }   

//            return listteam;         
//        }
//     }
//}

using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;


namespace WebAPI.Helpers
{
    public class ListTeams
    {
        public static ListTeamsModel Create(Engagement engagement, int month)
        {
            //   Person person = new Person();



            ListTeamsModel listteam = new ListTeamsModel()
            {
                Id = engagement.Id,
                Name = engagement.Team.Name,

            };
            Team team = new Team();
            //Declaring DateTime variables in order to select only working days for each month
            int dd = month;
            int dty = DateTime.Now.Year;
            int bd = DateTime.DaysInMonth(dty, month);
            var weekends = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            IEnumerable<int> businessDaysInMonth = Enumerable.Range(1, bd)
                                                   .Where(d => !weekends.Contains(new DateTime(dty, month, d).DayOfWeek));

            //Getting details sorted by Persons and forwarding time worked and days not logged into Members list
            var members = engagement.Team.Details.GroupBy(x => x.Day.Person.FullName).Select(x => new { person = x.Key, time = x.Sum(y => y.WorkTime), empty = x.GroupBy(z => z.Day.Date).Count() }).ToList();

            foreach (var det in members)
            {
                listteam.Members.Add(new CountModel { Category = det.person, Count = (int)det.time, EmptyDays = businessDaysInMonth.Count() - det.empty });
            }

            //Getting details for the entire team and forwarding overall team work time invested
            var time =  engagement.Team.Details.GroupBy(x => x.Team).Select(x => new { team = x.Key, time = x.Sum(y => y.WorkTime) }).ToList();

            foreach (var tm in time)
            {
                listteam.Details.Add(new ListModel { Category = "Overall time worked", Count = (int)tm.time });
            }

            //Getting day count from Details table and forwarding it to display overall team days invested
            var days = engagement.Team.Details.GroupBy(x => x.Team).Select(x => new { type = x.Key, days = x.GroupBy(z => z.Day.Date).Count() }).ToList();

            foreach (var day in days)
            {
                listteam.Days.Add(new ListModel { Category = "Overall days worked", Count = (int)day.days });
            }

            //Displaying days not logged for the entire team
            if (engagement.Team.Details.GroupBy(x=> x.Day.Date).Count() == 0)
            {
                listteam.EmptyDays.Add(new EmptyModel { Category = "Days not logged", EmptyDays = businessDaysInMonth.Count() });
            }            
            return listteam;
        }
    }
}
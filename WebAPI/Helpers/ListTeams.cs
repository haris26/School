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
        public static ListTeamsModel Create(Team team, int month)
        {
            ListTeamsModel listteam = new ListTeamsModel()
            {
                Id = team.Id,
                Name = team.Name,
            };

            //Declaring DateTime variables in order to select only working days for each month
            int dd = month;
            int dty = DateTime.Now.Year;
            int bd = DateTime.DaysInMonth(dty, dd);
            var weekends = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            IEnumerable<int> businessDaysInMonth = Enumerable.Range(1, bd)
                                                   .Where(d => !weekends.Contains(new DateTime(dty, dd, d).DayOfWeek));


            //Getting details sorted by Persons and forwarding time worked and days not logged into Members list
            var members = team.Details.GroupBy(x => x.Day.Person.FullName).Select(x => new { person = x.Key, time = x.Sum(y => y.WorkTime), empty = x.GroupBy(z => z.Day.Date).Count() }).ToList();
            foreach (var det in members)
            {
                if (team.Roles.GroupBy(x => x.Person.Days).Count() == 0)
                {
                    listteam.Members.Add(new CountModel { Category = det.person, Count = (int)det.time, EmptyDays = businessDaysInMonth.Count() });
                }
                else
                    listteam.Members.Add(new CountModel { Category = det.person, Count = (int)det.time, EmptyDays = businessDaysInMonth.Count() - det.empty });
            }

            //Getting details for the entire team and forwarding overall team work time invested
            var time = team.Details.GroupBy(x => x.Team.Members).Select(x => new { team = x.Key, time = x.Sum(y => y.WorkTime) }).ToList();

            foreach (var tm in time)
            {
                listteam.Details.Add(new ListModel { Category = "Overall time worked", Count = (int)tm.time });
            }

            //Getting day count from Details table and forwarding it to display overall team days invested
            //var days = team.Details.GroupBy(x => x.Team).Select(x => new { type = x.Key, days = x.GroupBy(z => z.Day.Date).Count() }).ToList();
            var days = team.Roles.SelectMany(x => x.Team.Details).GroupBy(x => x.Team).Select(x => new { type = x.Key, days = x.GroupBy(z => z.Day.Date).Count() }).ToList();
            foreach (var day in days)
            {
                listteam.Days.Add(new ListModel { Category = "Overall days worked", Count = (int)day.days });
            }

            //Displaying days not logged for the entire team

            if (team.Details.Count() == 0)
            {
                listteam.Members.Add(new CountModel { Category = "Days not logged", EmptyDays = businessDaysInMonth.Count() });
            }

            if (month == DateTime.Now.Month || month == DateTime.Now.Month -1)
            {
                string deadline = System.Configuration.ConfigurationManager.AppSettings["deadline"];
                if (DateTime.Now.Day < Convert.ToInt32(deadline))
                {
                    listteam.DeadlineIn.Add(new DeadlineModel { Deadline = Convert.ToInt32(deadline) - DateTime.Now.Day });
                }

                if (Convert.ToInt32(deadline) == DateTime.Now.Day)
                {
                    listteam.DeadlineIn.Add(new DeadlineModel { ZeroDeadline = "Deadline is today!" });
                }
            }
            return listteam;
        }
    }
}


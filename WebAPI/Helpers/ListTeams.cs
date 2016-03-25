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
        public static ListTeamsModel Create(Team team)
        {
            Person person = new Person();
            ListTeamsModel listteam = new ListTeamsModel()
            {
                Id = team.Id,
                Name = team.Name,

            };

           
            var members = team.Details.GroupBy(x => x.Day.Person.FullName).Select(x => new { person = x.Key, time = x.Sum(y => y.WorkTime) }).ToList();

            foreach (var det in members)
            {
                listteam.Members.Add(new ListModel { Category = det.person, Count = (int)det.time });
                
            }
            var time = team.Details.GroupBy(x => x.Team).Select(x => new { team = x.Key, time = x.Sum(y => y.WorkTime) }).ToList();

            foreach (var tm in time)
            {
                listteam.Details.Add(new ListModel { Category = "Overall time worked", Count = (int)tm.time });
            }

            var days = team.Details.GroupBy(x => x.Team).Select(x => new { team = x.Key, time = x.Sum(y => y.) }).ToList();

            foreach (var day in days)
            {
                listteam.Days.Add(new ListModel { Category = team.Name, Count = (int)day.time });
            }
            return listteam;

          
        }
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using WebAPI.Models;

//using Database;


//namespace WebAPI.Helpers
//{
//    public class MonthList

//    {
//        public static DashboardModel Create(Team team)
//        {
//            DashboardModel dashboard = new DashboardModel()
//            {
//                Id = team.Id,
//                Name = team.Name
//            };

//            //var engagements = person.Roles.GroupBy(x => x.Role.Name).Select(x => new { role = x.Key, count = x.Count() }).ToList();
//            //foreach (var eng in engagements)
//            //{
//            //    dashboard.Roles.Add(new ListModel { Category = eng.role, Count = eng.count });
//            //}

//            //dashboard.Days.Add(new ListModel { Category = "Calendar", Count = person.Days.Count() });

            

//            var details = team..Days.SelectMany(x => x.Details).GroupBy(x => x.Team.Name).Select(x => new { team = x.Key, time = x.Sum(y => y.WorkTime) }).ToList();
//            foreach (var detail in details)

//            {
//                dashboard.Days.Add(new ListModel { Category = detail.team, Count = (int)detail.time });
//            }
//            return dashboard;
//        }
//    }
//}
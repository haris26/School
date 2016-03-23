﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Helpers
{
    public static class Dashboard
    {
        public static DashboardModel Create(Person person)
        {
            DashboardModel dashboard = new DashboardModel()
            {
                Id = person.Id,
                Name = person.FullName
            };

            var engagements = person.Roles.GroupBy(x => x.Role.Name).Select(x => new { role = x.Key, count = x.Count() }).ToList();
            foreach (var eng in engagements)
            {
                dashboard.Roles.Add(new ListModel { Category = eng.role, Count = eng.count });
            }

            var skills = person.EmployeeSkills.GroupBy(x => x.Tool.Category.Name).Select(x => new { tool = x.Key, count = x.Count() }).ToList();
            foreach (var skill in skills)
            {
                dashboard.Skills.Add(new ListModel { Category = skill.tool, Count = skill.count });
            }

            var events = person.Events.GroupBy(x => x.Resource.ResourceCategory.CategoryName).Select(x => new { type = x.Key, count = x.Count() }).ToList();
            foreach (var evt in events)
            {
                dashboard.Reservations.Add(new ListModel { Category = evt.type, Count = evt.count });
            }

            dashboard.Days.Add(new ListModel { Category = "Calendar", Count = person.Days.Count() });

            var assets = person.Assets.GroupBy(x => x.AssetCategory.CategoryName).Select(x => new { type = x.Key, count = x.Count() }).ToList();
            foreach (var asset in assets)
            {
                dashboard.Assets.Add(new ListModel { Category = asset.type, Count = asset.count });
            }
            var requests = person.Requests.GroupBy(x => x.RequestDescription).Select(x => new { type = x.Key, count = x.Count() }).ToList();
            foreach (var request in requests)
            {
                dashboard.Requests.Add(new ListModel { Category = request.type, Count = request.count });
            }


            return dashboard;
        }
    }
}
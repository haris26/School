using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class Dashboard
    {
        public static DashboardModel Create(Person person)
        {
            DashboardModel dashboard = new DashboardModel()
            {
                Id =  person.Id,
                Name = person.FullName
            };

            var engagements = person.Roles.GroupBy(x => x.Role.Name).Select(x => new {role = x.Key, count = x.Count()}).ToList();
            foreach (var eng in engagements)
            {
                dashboard.Roles.Add(new ListModel() {Category = eng.role, Count = eng.count});
            }

            var skills =
                person.EmployeeSkills.GroupBy(x => x.Tool.Category.Name)
                    .Select(x => new {role = x.Key, count = x.Count()})
                    .ToList();
            foreach (var skill in skills)
            {
                dashboard.Skills.Add(new ListModel() {Category = skill.role, Count = skill.count});
            }

            var events =
                person.Events.GroupBy(x => x.Resource.ResourceCategory.CategoryName)
                    .Select(x => new {type = x.Key, count = x.Count()})
                    .ToList();
            foreach (var ev in events)
            {
                dashboard.Reservations.Add(new ListModel() { Category = ev.type, Count = ev.count });
            }

            dashboard.Days.Add(new ListModel() {Category = "Calendar", Count = person.Days.Count()});

            return dashboard;
        }

    }
}
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationSystem.Models
{
    public class EntityParser
    {
        public Engagement Create(EngagementModel model, SchoolContext context)
        {
            return new Engagement()
            {
                Id = model.Id,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Time = model.Time,
                Person = context.People.Find(model.Person),
                Team = context.Teams.Find(model.Team),
                Role = context.Roles.Find(model.Role)
            };
        }
        public Resource Create (ResourceModel model, SchoolContext context)
        {
            return new Resource()
            {
                Id = model.Id,
                Name = model.Name,
                Status = model.Status,
                ResourceCategory = context.ResourceCategories.Find(model.ResourceCategory)
            };
        }
    }
}
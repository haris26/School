using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracking.Models
{
    public class EntityParser
    {
        private SchoolContext context;

        public EntityParser(SchoolContext ctx)
        {
            context = ctx;
        }
        public Engagement Create(EngagementModel model)
        {
            return new Engagement()
            {
                Id = 0,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Time = model.Time,
                Person = context.People.Find(model.Person),
                Team = context.Teams.Find(model.Team),
                Role = context.Roles.Find(model.Role)
            };
        }

        public Day Create(DayModel model)
        {
            return new Day()
            {
                Id = 0,
                Person = context.People.Find(model.Person),
                Date = model.Date,
                WorkTime = model.WorkTime,
                PtoTime = model.PtoTime,
                EntryStatus = model.EntryStatus
            };
        }

        public Detail Create(DetailModel model)
        {
            return new Detail()
            {
                Id = 0,
                Day = context.Days.Find(model.Day),
                WorkTime = model.WorkTime,
                BillTime = model.BillTime,
                Description = model.Description,
                Team = context.Teams.Find(model.Team)
            };
        }
    }
}
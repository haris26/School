using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProcurementSystem.Models
{
    public class EntityParser
    {

        //public Engagement Create(EngagementModel model, SchoolContext context)
        //{

        //    return new Engagement();
        //}

        
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

        public History Create(HistoryModel history, SchoolContext context)
        {
            return new History()

            {
                Id = history.Id,
                EventBegin = history.EventBegin,
                EventEnd = history.EventEnd,
                Description = history.Description,
                Person = context.People.Find(history.Person),
               
                Asset = context.Assets.Find(history.Asset)

            };
        }
    }
}
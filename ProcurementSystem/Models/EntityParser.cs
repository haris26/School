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
         return   new Engagement()

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

        public Request Create(RequestModel model, SchoolContext context)
        {
            return new Request()
            {
                Id = model.Id,
                requestType = model.requestType,
                RequestDescription = model.RequestDescription,
                RequestMessage = model.RequestMessage,
                RequestDate = model.RequestDate,
                Asset = context.Assets.Find(model.Asset),
                User = context.People.Find(model.Person)

            };
        }
    }
}
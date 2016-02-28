using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Database;


namespace ReservationSystem.Models
{
    public class EntityParser
    {
        private SchoolContext context;

        public EntityParser(SchoolContext ctx)
        {
            context = ctx;
        }

        public Event Create(EventModel model, SchoolContext context)
        {
            return new Event()
            {
                Id = model.Id,
                EventTitle = model.EventTitle,
                EventStart = model.StartDate,
                EventEnd = model.EndDate,
                User = context.People.Find(model.Person),
                Resource = context.Resources.Find(model.Resource)
            };
        }
        //Irhad on EntityParser
        public CharacteristicName Create(CharacteristicNameModel model, SchoolContext context)
        {
            return new CharacteristicName()
            {
                Id = model.Id,
                Name = model.Name,
                ResourceCategory = context.ResourceCategories.Find(model.ResourceCategory)
            };

        }


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
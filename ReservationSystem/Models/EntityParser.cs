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

        public Event Create(EventModel model)
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

<<<<<<< HEAD
        public Engagement Create(EngagementModel model)
=======

            public Engagement Create(EngagementModel model)
>>>>>>> haris
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
<<<<<<< HEAD

        public Resource Create(ResourceModel model, SchoolContext context)
=======
        public Resource Create (ResourceModel model)
>>>>>>> haris
        {
            return new Resource()
            {
                Id = model.Id,
                Name = model.Name,
                Status = model.Status,
                ResourceCategory = context.ResourceCategories.Find(model.ResourceCategory)
            };
        }

        public ResourceCategory Create(ResourceCategoryModel model, SchoolContext context)
        {
            return new ResourceCategory()
            {
                Id = model.Id,
                CategoryName = model.CategoryName
            };
        }
<<<<<<< HEAD

        public Person Create(PeopleModel model)
=======
        public Person Create(PersonModel model)
>>>>>>> haris
        {
            return new Person()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Category = model.Category,
                Phone = model.Phone,
                Status = model.Status
            };
        }
<<<<<<< HEAD

        public ExtendedEvent Create(EventExtendModel model)
        {
            return new ExtendedEvent()
            {
                Id = model.Id,
                ParentEvent = context.Events.Find(model.ParentEvent),
                RepeatUntil = model.RepeatUntil,
                RepeatingType = model.RepeatingType,
                Frequency = model.Frequency
            };
        }
=======
        public Characteristic Create(CharacteristicModel model)
        {
            return new Characteristic()
            {
                Id = model.Id,
                Name = model.Name,
                Value = model.Value,
                Resource = context.Resources.Find(model.Resource)
            };
        }
        
>>>>>>> haris
    }
}
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class EventRestriction
    {
        public static Event Create(EventModel model, SchoolContext context)
        {
            Event ev = new Event()
            {
                Id = model.Id,
                EventTitle = model.EventTitle,
                User = context.People.Find(model.Person),
                Resource = context.Resources.Find(model.Resource)
            };

            if ((model.StartDate.DayOfWeek != DayOfWeek.Saturday && model.StartDate.DayOfWeek != DayOfWeek.Sunday) 
                && (model.EndDate.DayOfWeek != DayOfWeek.Saturday && model.EndDate.DayOfWeek != DayOfWeek.Sunday))
            {
                ev.EventStart = model.StartDate;
                ev.EventEnd = model.EndDate;
            }

            return ev;
        }
    }
}
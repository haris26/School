using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class EventExtendRestriction
    {
        public static ExtendedEvent Create(EventExtendModel model, SchoolContext context)
        {
            ExtendedEvent extendedEvent = new ExtendedEvent();

            var extendedEvents = new ExtendedEventUnit(context).Get().Where(x => x.ParentEvent.Id == model.ParentEvent).Count();
            if (extendedEvents == 0)
            {
                extendedEvent.Id = model.Id;
                extendedEvent.ParentEvent = context.Events.Find(model.ParentEvent);
                extendedEvent.RepeatingType = model.RepeatingType;
                extendedEvent.Frequency = model.Frequency;
            }
           
            if (model.RepeatUntil.DayOfWeek != DayOfWeek.Saturday && model.RepeatUntil.DayOfWeek != DayOfWeek.Sunday
                && model.RepeatUntil >= extendedEvent.ParentEvent.EventEnd)
                extendedEvent.RepeatUntil = model.RepeatUntil;

            return extendedEvent;
        }
    }
}
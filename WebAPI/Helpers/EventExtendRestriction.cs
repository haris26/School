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
            DateTime RepeatUntil = Convert.ToDateTime(model.RepeatUntil);

            if (RepeatUntil.DayOfWeek != DayOfWeek.Saturday && RepeatUntil.DayOfWeek != DayOfWeek.Sunday
                && RepeatUntil >= extendedEvent.ParentEvent.EventEnd)
                extendedEvent.RepeatUntil = RepeatUntil;

            return extendedEvent;
        }
        public static ExtendedEvent Update(EventExtendModel model, SchoolContext context)
        {
            ExtendedEvent extendedEvent = new ExtendedEventUnit(context).Get(model.Id);
            extendedEvent.Id = model.Id;
            extendedEvent.ParentEvent = context.Events.Find(model.ParentEvent);
            extendedEvent.RepeatingType = model.RepeatingType;
            extendedEvent.Frequency = model.Frequency;

            DateTime RepeatUntil = Convert.ToDateTime(model.RepeatUntil);

            if (RepeatUntil.DayOfWeek != DayOfWeek.Saturday && RepeatUntil.DayOfWeek != DayOfWeek.Sunday
               && RepeatUntil >= extendedEvent.ParentEvent.EventEnd)
                extendedEvent.RepeatUntil = RepeatUntil;

            return extendedEvent;
        }
    }
}
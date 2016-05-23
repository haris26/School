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
                User = context.People.Find(AppGlobals.currentUser.Id),
                Resource = context.Resources.Find(model.Resource),
                isExtended=model.isExtended,
                EventEnd=Convert.ToDateTime(model.EndDate),
                EventStart=Convert.ToDateTime(model.StartDate)

            };
            if (model.CategoryName == "Device")
            {
               ev.EventEnd= ev.EventEnd.AddHours(Convert.ToInt32(model.EndTime));
               ev.EventStart= ev.EventStart.AddHours(Convert.ToInt32(model.StartTime));
            }
           if(ev.EventStart.DayOfWeek==DayOfWeek.Saturday || ev.EventStart.DayOfWeek == DayOfWeek.Sunday)
            {
                return null;
            }
            return ev;
        }
      
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class ExtendedOverview
    {
        public static IList<ExtendedOverviewModel> Create(SchoolContext context)
        {
            var extendedEvents = new ExtendedEventUnit(context).Get().ToList()
                .Where(x => x.RepeatUntil.Date >= System.DateTime.Today.Date 
                && (x.ParentEvent.User.FullName == AppGlobals.currentUser.FullName)).ToList();
                //.OrderBy(y => y.RepeatUntil);

            IList<ExtendedOverviewModel> models = new List<ExtendedOverviewModel>();

            foreach (var exEvent in extendedEvents)
            {
                ExtendedOverviewModel model = new ExtendedOverviewModel()
                {
                    Id = exEvent.Id,
                    ParentEvent = exEvent.ParentEvent.Id,
                    EventTitle = exEvent.ParentEvent.EventTitle,
                    PersonName = exEvent.ParentEvent.User.FullName,
                    ResourceName = exEvent.ParentEvent.Resource.Name,
                    RepeatUntil = exEvent.RepeatUntil.ToShortDateString(),
                    DayOfWeek = exEvent.ParentEvent.EventStart.DayOfWeek.ToString(),
                    EventTime = exEvent.ParentEvent.EventStart.ToShortTimeString() + " - " + exEvent.ParentEvent.EventEnd.ToShortTimeString(),
                    RepeatingType = exEvent.RepeatingType.ToString(),
                    Frequency = exEvent.Frequency
                };
                models.Add(model);
            }
            return models;
        }

        public static ExtendedEvent Get(int id, SchoolContext context)
        {
            ExtendedEvent extendedEvent = new ExtendedEventUnit(context).Get().Where(x => x.ParentEvent.Id == id).FirstOrDefault();
             return extendedEvent;
        }
    }
}
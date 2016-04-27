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
                Resource = context.Resources.Find(model.Resource)
            };
            DateTime start = Convert.ToDateTime(model.StartDate);
            DateTime end = Convert.ToDateTime(model.EndDate);

            if ((start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday) 
                && (end.DayOfWeek != DayOfWeek.Saturday && end.DayOfWeek != DayOfWeek.Sunday)
                && (start >= DateTime.Today && start <= end))
            {
                ev.EventStart = SetTime(start,model.StartTime);
                ev.EventEnd = SetTime(end, model.EndTime);
            }

            return ev;
        }

        public static int GetEventDuration(EventModel model)
        {
            return Convert.ToInt32(model.EndTime) - Convert.ToInt32(model.StartTime);
        }

        public static IList<EventModel> CreateEvent(EventModel model, SchoolContext context)
        {
            IList<EventModel> events = new List<EventModel>();
            int start = Convert.ToInt32(model.StartTime);
            int end = Convert.ToInt32(model.EndTime);
            for (int i = start; i < end; i++)
            {
                EventModel newEvent = new EventModel()
                {
                    Person = model.Person,
                    PersonName = model.PersonName,
                    Category = model.Category,
                    CategoryName = model.CategoryName,
                    Resource = model.Resource,
                    ResourceName = model.ResourceName,
                    EventTitle = model.EventTitle,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                };
                newEvent.StartTime = i.ToString();
                newEvent.EndTime = (i + 1).ToString();
                events.Add(newEvent);
            }
            return events;            
        }

        public static DateTime SetTime(DateTime date, string time)
        {
            return date.AddHours(Convert.ToInt32(time)); 
        }

        public static void DecreaseQuantity(EventModel model, SchoolContext context)
        {
            Resource resource = context.Resources.Find(model.Resource);
            if (resource.ResourceCategory.CategoryName == "Device")
            {
                var resourceCharacteristics = resource.Characteristics;
                foreach(var characteristic in resourceCharacteristics)
                {
                    if (characteristic.Name == "Quantity")
                    {
                        int quantity = Convert.ToInt32(characteristic.Value);
                            quantity--;
                            characteristic.Value = Convert.ToString(quantity);
                    }
                }
            }
        }

        public static void IncreaseQuantity(Event ev, SchoolContext context)
        {
            Resource resource = context.Resources.Find(ev.Resource.Id);
            if (resource.ResourceCategory.CategoryName == "Device")
            {
                var resourceCharacteristics = resource.Characteristics;
                foreach (var characteristic in resourceCharacteristics)
                {
                    if (characteristic.Name == "Quantity")
                    {
                        int quantity = Convert.ToInt32(characteristic.Value);
                        quantity++;
                        characteristic.Value = Convert.ToString(quantity);
                    }
                }
            }
        }

        public static int GetResourceQuantity(EventModel model, SchoolContext context)
        {
            int quantity = 1;
            Resource resource = context.Resources.Find(model.Resource);
            if (resource.ResourceCategory.CategoryName == "Device")
            {
                var characteristics = resource.Characteristics;
                foreach (var c in characteristics)
                {
                    if (c.Name == "Quantity")
                        quantity = Convert.ToInt32(c.Value);
                }
            }
            return quantity;
        }
    }
}
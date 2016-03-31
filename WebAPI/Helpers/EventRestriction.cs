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
            int id = AppGlobals.currentUser.Id;
            Person p = context.People.Find(id);
            Event ev = new Event()
            {
                Id = model.Id,
                EventTitle = model.EventTitle,
                User = context.People.Find(AppGlobals.currentUser.Id),
                Resource = context.Resources.Find(model.Resource)
            };

            if ((model.StartDate.DayOfWeek != DayOfWeek.Saturday && model.StartDate.DayOfWeek != DayOfWeek.Sunday) 
                && (model.EndDate.DayOfWeek != DayOfWeek.Saturday && model.EndDate.DayOfWeek != DayOfWeek.Sunday)
                && (model.StartDate >= DateTime.Today && model.StartDate <= model.EndDate))
            {
                ev.EventStart = model.StartDate;
                ev.EventEnd = model.EndDate;
            }

            return ev;
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
    }
}
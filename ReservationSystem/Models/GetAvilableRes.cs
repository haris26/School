using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationSystem.Models
{
    public class GetAvilableRes
    {
        public IList<ReservationModel> Get(string s)
        {
            IList<ReservationModel> models = new List<ReservationModel>();
            var resources = new ResourceUnit(Context).Get().ToList().Where(x => (x.ResourceCategory.CategoryName == "Device" && x.Status == ReservationStatus.Available));
            var events = new EventUnit(Context).Get().ToList().Where(x => x.Resource.ResourceCategory.CategoryName == "Device");
            foreach (var res in resources)
            {
                ReservationModel model = new ReservationModel()
                {
                    Id = res.Id,
                    Name = res.Name
                };

                foreach (var ch in res.Characteristics)
                {
                    model.Characteristics.Add(new Characteristic() { Name = ch.Name, Value = ch.Value });
                }
                foreach (var ev in events)
                {
                    model.Events.Add(new Event() { EventTitle = ev.EventTitle, EventStart = ev.EventStart, EventEnd = ev.EventEnd });
                }
                models.Add(model);

            }
            return View(models);
        }
    }
}
    }
}
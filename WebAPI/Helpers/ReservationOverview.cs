using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class ReservationOverview
    {
        public static IList<ReservationOverviewModel> Create(SearchModel modelParameters)
        {
            SchoolContext context = new SchoolContext();
            IList<ReservationOverviewModel> models = new List<ReservationOverviewModel>();

            var resources = new ResourceUnit(context).Get().ToList().Where(x => (x.ResourceCategory.CategoryName == modelParameters.CategoryName));
            foreach (var res in resources)
            {
                ReservationOverviewModel model = new ReservationOverviewModel()
                {
                    Id = res.Id,
                    Name = res.Name
                };

                foreach (var ch in res.Characteristics)
                {
                    model.Characteristics.Add(new ResListModel() { Name = ch.Name, Value = ch.Value, ResName = ch.Resource.Name, ResId = ch.Resource.Id });
                }
                foreach (var ev in res.Events)
                {
                    if (ev.EventStart == modelParameters.FromDate)
                    {
                        model.Events.Add(new Event()
                        {
                            EventTitle = ev.EventTitle,
                            EventStart = ev.EventStart,
                            EventEnd = ev.EventEnd
                        });
                    }           
                }
                models.Add(model);
            }

            return models;
        }
    }
}
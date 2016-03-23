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
                    model.Characteristics.Add(new CharacteristicsListModel()
                    {
                        Id = ch.Id,
                        Name = ch.Name,
                        Value = ch.Value,
                    });
                }

                foreach (var ev in res.Events)
                {
                    if (ev.EventStart >= modelParameters.FromDate && ev.EventStart <= modelParameters.ToDate)
                    {
                        model.Events.Add(new EventsListModel()
                        {
                            Id = ev.Id,
                            EventTitle = ev.EventTitle,
                            FromDate = ev.EventStart,
                            ToDate = ev.EventEnd,
                            Person = ev.User.Id,
                            PersonName = ev.User.FullName,
                            Time = GetTimeForReservation(ev.EventStart)
                        });
                    }           
                }
                models.Add(model);
            }
            return models;
        }

        public static string GetTimeForReservation(DateTime date)
        {
            return Convert.ToString(date.Hour + ":" + date.Minute);
        }
    }
}
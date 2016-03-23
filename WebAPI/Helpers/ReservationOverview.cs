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
                    if (modelParameters.ToDate == null) {
                        if (modelParameters.FromDate.DayOfWeek != DayOfWeek.Saturday && modelParameters.FromDate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            model.Events.Add(new EventsListModel()
                            {
                                Id = ev.Id,
                                EventTitle = ev.EventTitle,
                                FromDate = ev.EventStart,
                                Person = ev.User.Id,
                                PersonName = ev.User.FullName,
                                Time = GetTimeForReservation(ev.EventStart)
                            });
                        }
                    }
                    else
                    {
                        SetWeeklyInterval(modelParameters.FromDate, modelParameters);
                        if (modelParameters.FromDate.DayOfWeek != DayOfWeek.Saturday && modelParameters.FromDate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            if (ev.EventStart >= modelParameters.FromDate && ev.EventStart <= modelParameters.ToDate)
                            {
                                model.Events.Add(new EventsListModel()
                                {
                                    Id = ev.Id,
                                    EventTitle = ev.EventTitle,
                                    FromDate = ev.EventStart,
                                    Person = ev.User.Id,
                                    PersonName = ev.User.FullName,
                                    Time = GetTimeForReservation(ev.EventStart)
                                });
                            }
                        }
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
        
        public static void SetWeeklyInterval(DateTime date,SearchModel model)
        {
            DayOfWeek Day = date.DayOfWeek;
            if (Day == DayOfWeek.Monday)
            {
                model.ToDate = model.FromDate.AddDays(4);
            }
            else if (Day == DayOfWeek.Tuesday)
            {
                model.ToDate = model.FromDate.AddDays(3);
                model.FromDate = model.FromDate.AddDays(-1);
            }
            else if (Day == DayOfWeek.Wednesday)
            {
                model.ToDate = model.FromDate.AddDays(2);
                model.FromDate = model.FromDate.AddDays(-2);
            }
            else if (Day == DayOfWeek.Thursday)
            {
                model.ToDate = model.FromDate.AddDays(1);
                model.FromDate = model.FromDate.AddDays(-3);
            }
            else  (Day == DayOfWeek.Friday)
            {

                model.FromDate = model.FromDate.AddDays(-4);
            }     
        }
        
       
    }
}
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

            var resources =
                new ResourceUnit(context).Get()
                    .ToList()
                    .Where(x => (x.ResourceCategory.CategoryName == modelParameters.CategoryName));
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
                    model.Quantity = CheckQuantity(res, context);
                }

                foreach (var ev in res.Events)
                {
                    if (modelParameters.ToDate != System.DateTime.Today)
                    {
                        SetWeeklyInterval(modelParameters.FromDate, modelParameters);
                        //model.Quantity = CheckQuantity(res, context);
                        if (modelParameters.FromDate.DayOfWeek != DayOfWeek.Saturday &&
                            modelParameters.FromDate.DayOfWeek != DayOfWeek.Sunday)
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
                    }
                    else
                    {
                        //model.Quantity = CheckQuantity(res, context);
                        if (modelParameters.FromDate.DayOfWeek != DayOfWeek.Saturday &&
                            modelParameters.FromDate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            if (ev.EventStart == modelParameters.FromDate)
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
                    }
                }
                models.Add(model);
                //model.Quantity = CheckQuantity(res, context);
            }
            return models;
        }

        public static string GetTimeForReservation(DateTime date)
        {
            return Convert.ToString(date.Hour + ":" + date.Minute);
        }

        public static void SetWeeklyInterval(DateTime date, SearchModel model)
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
            else if (Day == DayOfWeek.Friday)
            {
                model.FromDate = model.FromDate.AddDays(-4);
            }
        }

        public static int CheckQuantity(Resource res, SchoolContext context)
        {
            int quantity = 1;
            Resource resource = context.Resources.Find(res.Id);
            if (resource.ResourceCategory.CategoryName == "Device")
            {
                var characteristics = resource.Characteristics;
                foreach (var c in characteristics)
                {
                    if (c.Name == "Quantity")
                        quantity = Convert.ToInt32(c.Value);
                }
            }
            else
                quantity = 1;
            return quantity;
        }
    }
}
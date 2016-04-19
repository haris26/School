using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using Database;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class ReservationOverview
    {
        public static ReservationOverviewModel FindDeviceReservations(SearchModel modelParameters)
        {
            SchoolContext context = new SchoolContext();
            Resource resource = new Resource();
            ReservationOverviewModel model = new ReservationOverviewModel();

            var deviceResources = new ResourceUnit(context).Get()
                .Where(x =>(x.Name == modelParameters.ResourceName) &&(x.ResourceCategory.CategoryName == modelParameters.CategoryName))
                .ToList();

            foreach (var device in deviceResources)
            {
                foreach (var ch in device.Characteristics)
                {
                    if (ch.Name == "OsType" && ch.Value == modelParameters.OsType)
                    {
                        resource = device;
                        model.Id = resource.Id;
                        model.Name = resource.Name;                       
                    }
                    model.Characteristics.Add(new CharacteristicsListModel()
                    {
                        Id = ch.Id,
                        Name = ch.Name,
                        Value = ch.Value
                    });
                    model.Quantity = CheckQuantity(resource, context);
                }
            }

            foreach (var ev in resource.Events)
            {
                if (modelParameters.ToDate != System.DateTime.Today)
                {
                    SetWeeklyInterval(modelParameters.FromDate, modelParameters);
                    if (modelParameters.FromDate.DayOfWeek != DayOfWeek.Saturday &&
                        modelParameters.FromDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (ev.EventStart >= modelParameters.FromDate && ev.EventStart <= modelParameters.ToDate)
                        {
                            model.Events.Add(new EventsListModel()
                            {
                                Id = ev.Id,
                                EventTitle = ev.EventTitle,
                                FromDate = ev.EventStart.ToShortDateString(),
                                ToDate = ev.EventEnd.ToShortDateString(),
                                Person = ev.User.Id,
                                PersonName = ev.User.FullName,
                                Time = ev.EventStart.ToShortTimeString() + " - " + ev.EventEnd.ToShortTimeString()
                            });
                        }
                    }
                }
                else
                {
                    if (modelParameters.FromDate.DayOfWeek != DayOfWeek.Saturday &&
                        modelParameters.FromDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (ev.EventStart == modelParameters.FromDate)
                        {
                            model.Events.Add(new EventsListModel()
                            {
                                Id = ev.Id,
                                EventTitle = ev.EventTitle,
                                FromDate = ev.EventStart.ToShortDateString(),
                                ToDate = ev.EventEnd.ToShortDateString(),
                                Person = ev.User.Id,
                                PersonName = ev.User.FullName,
                                Time = ev.EventStart.ToShortTimeString() + " - " + ev.EventEnd.ToShortTimeString()
                            });
                        }
                    }
                }
            }
            return model;
        }

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
                        if (modelParameters.FromDate.DayOfWeek != DayOfWeek.Saturday &&
                            modelParameters.FromDate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            if (ev.EventStart >= modelParameters.FromDate && ev.EventStart <= modelParameters.ToDate)
                            {
                                model.Events.Add(new EventsListModel()
                                {
                                    Id = ev.Id,
                                    EventTitle = ev.EventTitle,
                                    FromDate = ev.EventStart.ToShortDateString(),
                                    ToDate = ev.EventEnd.ToShortDateString(),
                                    Person = ev.User.Id,
                                    PersonName = ev.User.FullName,
                                    Time = ev.EventStart.ToShortTimeString() + " - " + ev.EventEnd.ToShortTimeString()
                                });
                            }
                        }
                    }
                    else
                    {
                        if (modelParameters.FromDate.DayOfWeek != DayOfWeek.Saturday &&
                            modelParameters.FromDate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            if (ev.EventStart == modelParameters.FromDate)
                            {
                                model.Events.Add(new EventsListModel()
                                {
                                    Id = ev.Id,
                                    EventTitle = ev.EventTitle,
                                    FromDate = ev.EventStart.ToShortDateString(),
                                    ToDate = ev.EventEnd.ToShortDateString(),
                                    Person = ev.User.Id,
                                    PersonName = ev.User.FullName,
                                    Time = ev.EventStart.ToShortTimeString() + " - " + ev.EventEnd.ToShortTimeString()
                                });
                            }
                        }
                    }
                }
                models.Add(model);
            }
            return models;
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
            return quantity;
        }
    }
}
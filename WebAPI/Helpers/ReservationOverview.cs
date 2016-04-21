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
            IList<DeviceRowModel> days = new List<DeviceRowModel>(5);

            var deviceResource = new ResourceUnit(context).Get()
                .Where(x =>(x.Name == modelParameters.ResourceName) &&(x.ResourceCategory.CategoryName == modelParameters.CategoryName))
                .FirstOrDefault();

            resource = deviceResource;
            model.Id = resource.Id;
            model.Name = resource.Name;

            var events = new EventUnit(context).Get().Where(x => (x.Resource.Name == model.Name) && (x.EventStart >= modelParameters.FromDate && x.EventStart <= modelParameters.ToDate)).ToList();
            foreach (var ch in resource.Characteristics)
            {
                model.Characteristics.Add(new CharacteristicsListModel()
                {
                    Name = ch.Name,
                    Value = ch.Value
                });
                model.Quantity = CheckQuantity(resource, context);
            }

            foreach (var ev in events)
            {               
                SetWeeklyInterval(modelParameters.FromDate, modelParameters);
                if (modelParameters.FromDate.DayOfWeek != DayOfWeek.Saturday &&
                    modelParameters.FromDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (ev.EventStart.DayOfWeek == DayOfWeek.Monday)
                    {
                        DeviceRowModel newDay = new DeviceRowModel();
                        SetDay(events, ev, newDay);
                        model.table.Add(newDay);
                    }
                    else
                    {
                        DeviceRowModel newDay = new DeviceRowModel();
                        SetFreeDay(events, ev, newDay);
                        model.table.Add(newDay);
                    }

                    if (ev.EventStart.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        DeviceRowModel newDay = new DeviceRowModel();
                        SetDay(events, ev, newDay);
                        model.table.Add(newDay);
                    }
                    else
                    {
                        DeviceRowModel newDay = new DeviceRowModel();
                        SetFreeDay(events, ev, newDay);
                        model.table.Add(newDay);
                    }

                    if (ev.EventStart.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        DeviceRowModel newDay = new DeviceRowModel();
                        SetDay(events, ev, newDay);
                        model.table.Add(newDay);
                    }
                    else
                    {
                        DeviceRowModel newDay = new DeviceRowModel();
                        SetFreeDay(events, ev, newDay);
                        model.table.Add(newDay);
                    }

                    if (ev.EventStart.DayOfWeek == DayOfWeek.Thursday)
                    {
                        DeviceRowModel newDay = new DeviceRowModel();
                        SetDay(events, ev, newDay);
                        model.table.Add(newDay);
                    }
                    else
                    {
                        DeviceRowModel newDay = new DeviceRowModel();
                        SetFreeDay(events, ev, newDay);
                        model.table.Add(newDay);
                    }

                    if (ev.EventStart.DayOfWeek == DayOfWeek.Friday)
                    {
                        DeviceRowModel newDay = new DeviceRowModel();
                        SetDay(events, ev, newDay);
                        model.table.Add(newDay);
                    }
                    else
                    {
                        DeviceRowModel newDay = new DeviceRowModel();
                        SetFreeDay(events, ev, newDay);
                        model.table.Add(newDay);
                    }
                }   
            }
            return model;
        }

        public static DeviceRowModel SetDay(IList<Event> events, Event ev, DeviceRowModel day)
        {
            day.Day = ev.EventStart.DayOfWeek.ToString();
            day.Date = ev.EventStart.ToShortDateString();
            IList<DeviceCellModel> hours = new List<DeviceCellModel>(8);
            hours = SetHours(hours, events);
            day.Hours = hours;

            return day;
        }

        public static DeviceRowModel SetFreeDay(IList<Event> events, Event ev, DeviceRowModel day)
        {
            day.Day = "";
            day.Date = "";
            IList<DeviceCellModel> hours = new List<DeviceCellModel>(8);
            hours = SetHours(hours, events);
            day.Hours = hours;

            return day;
        }

        public static IList<DeviceCellModel> SetHours(IList<DeviceCellModel> day, IList<Event> events)
        {
            foreach (var ev in events)
            {
                if (ev.EventStart.ToShortTimeString() == "9:00")
                {
                    day.Add(SetHour(ev));
                }
                else
                {
                    day.Add(SetFree());
                }

                if (ev.EventStart.ToShortTimeString() == "10:00")
                {
                    day.Add(SetHour(ev));
                }
                else
                {
                    day.Add(SetFree()); ;
                }

                if (ev.EventStart.ToShortTimeString() == "11:00")
                {
                    day.Add(SetHour(ev));
                }
                else
                {
                    day.Add(SetFree());
                }

                if (ev.EventStart.ToShortTimeString() == "12:00")
                {
                    day.Add(SetHour(ev));
                }
                else
                {
                    day.Add(SetFree());
                }

                if (ev.EventStart.ToShortTimeString() == "13:00")
                {
                    day.Add(SetHour(ev));
                }
                else
                {
                    day.Add(SetFree());
                }

                if (ev.EventStart.ToShortTimeString() == "14:00")
                {
                    day.Add(SetHour(ev));
                }
                else
                {
                    day.Add(SetFree());
                }

                if (ev.EventStart.ToShortTimeString() == "15:00")
                {
                    day.Add(SetHour(ev));
                }
                else
                {
                    day.Add(SetFree());
                }

                if (ev.EventStart.ToShortTimeString() == "16:00")
                {
                    day.Add(SetHour(ev));
                }
                else
                {
                    day.Add(SetFree());
                }
            }
            return day;
        }

        public static DeviceCellModel SetHour(Event ev)
        {
            DeviceCellModel hour = new DeviceCellModel()
            {
                EventTitle = ev.EventTitle,
                PersonName = ev.User.FullName,
                IsReserved = true
            };
            return hour;          
        }

        public static DeviceCellModel SetFree()
        {
            DeviceCellModel hour = new DeviceCellModel()
            {
                EventTitle = "",
                PersonName = "",
                IsReserved = false
            };
            return hour;
        }

        //public static IList<ReservationOverviewModel> Create(SearchModel modelParameters)
        //{
        //    SchoolContext context = new SchoolContext();
        //    IList<ReservationOverviewModel> models = new List<ReservationOverviewModel>();

        //    var resources =
        //        new ResourceUnit(context).Get()
        //            .ToList()
        //            .Where(x => (x.ResourceCategory.CategoryName == modelParameters.CategoryName));
        //    foreach (var res in resources)
        //    {
        //        ReservationOverviewModel model = new ReservationOverviewModel()
        //        {
        //            Id = res.Id,
        //            Name = res.Name
        //        };

        //        foreach (var ch in res.Characteristics)
        //        {
        //            model.Characteristics.Add(new CharacteristicsListModel()
        //            {
        //                Name = ch.Name,
        //                Value = ch.Value,
        //            });
        //            model.Quantity = CheckQuantity(res, context);
        //        }

        //        foreach (var ev in res.Events)
        //        {
        //            if (modelParameters.ToDate != System.DateTime.Today)
        //            {
        //                SetWeeklyInterval(modelParameters.FromDate, modelParameters);
        //                if (modelParameters.FromDate.DayOfWeek != DayOfWeek.Saturday &&
        //                    modelParameters.FromDate.DayOfWeek != DayOfWeek.Sunday)
        //                {
        //                    if (ev.EventStart >= modelParameters.FromDate && ev.EventStart <= modelParameters.ToDate)
        //                    {
        //                        model.Events.Add(new EventsListModel()
        //                        {
        //                            Id = ev.Id,
        //                            EventTitle = ev.EventTitle,
        //                            FromDate = ev.EventStart.ToShortDateString(),
        //                            ToDate = ev.EventEnd.ToShortDateString(),
        //                            Person = ev.User.Id,
        //                            PersonName = ev.User.FullName,
        //                            Time = ev.EventStart.ToShortTimeString() + " - " + ev.EventEnd.ToShortTimeString()
        //                        });
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (modelParameters.FromDate.DayOfWeek != DayOfWeek.Saturday &&
        //                    modelParameters.FromDate.DayOfWeek != DayOfWeek.Sunday)
        //                {
        //                    if (ev.EventStart == modelParameters.FromDate)
        //                    {
        //                        model.Events.Add(new EventsListModel()
        //                        {
        //                            Id = ev.Id,
        //                            EventTitle = ev.EventTitle,
        //                            FromDate = ev.EventStart.ToShortDateString(),
        //                            ToDate = ev.EventEnd.ToShortDateString(),
        //                            Person = ev.User.Id,
        //                            PersonName = ev.User.FullName,
        //                            Time = ev.EventStart.ToShortTimeString() + " - " + ev.EventEnd.ToShortTimeString()
        //                        });
        //                    }
        //                }
        //            }
        //        }
        //        models.Add(model);
        //    }
        //    return models;
        //}

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
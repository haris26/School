using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            SetWeeklyInterval(modelParameters.FromDate, modelParameters);
            DeviceTableModel table = new DeviceTableModel(modelParameters.FromDate);          

            var deviceResource = new ResourceUnit(context).Get()
                .Where(x =>(x.Name == modelParameters.ResourceName) &&(x.ResourceCategory.CategoryName == modelParameters.CategoryName))
                .FirstOrDefault();

            resource = deviceResource;
            model.Id = resource.Id;
            model.Name = resource.Name;

            var events = new EventUnit(context).Get()
                .Where(x => (x.Resource.Name == model.Name) && 
                (DbFunctions.TruncateTime(x.EventStart) >= DbFunctions.TruncateTime(modelParameters.FromDate) && DbFunctions.TruncateTime(x.EventStart) <= DbFunctions.TruncateTime(modelParameters.ToDate))).ToList();
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
                int day = 0;
                int hour = 0;
                int hourValue = 0;
                //set day parametar
                if (ev.EventStart.DayOfWeek.ToString() == "Monday") { day = 0; }
                if (ev.EventStart.DayOfWeek.ToString()=="Tuesday") { day = 1; }
                if (ev.EventStart.DayOfWeek.ToString() == "Wednesday") { day = 2; }
                if (ev.EventStart.DayOfWeek.ToString() == "Thursday") { day = 3; }
                if (ev.EventStart.DayOfWeek.ToString() == "Friday") { day = 4; }
                // ser hour parametar
                if (ev.EventStart.ToShortTimeString() == "9:00") { hour = 0; hourValue = 9; }
                if (ev.EventStart.ToShortTimeString() == "10:00") { hour = 1; hourValue = 10; }
                if (ev.EventStart.ToShortTimeString() == "11:00") { hour = 2; hourValue = 11; }
                if (ev.EventStart.ToShortTimeString() == "12:00") { hour = 3; hourValue = 12; }
                if (ev.EventStart.ToShortTimeString() == "13:00") { hour = 4; hourValue = 13; }
                if (ev.EventStart.ToShortTimeString() == "14:00") { hour = 5; hourValue = 14; }
                if (ev.EventStart.ToShortTimeString() == "15:00") { hour = 6; hourValue = 15; }
                if (ev.EventStart.ToShortTimeString() == "16:00") { hour = 7; hourValue = 16; }
                // set device cell model
                var deviceCell = new DeviceCellModel
                {
                    EventTitle = ev.EventTitle,
                    PersonName = ev.User.FullName,
                    Hour = hourValue,
                    IsPast = false,
                    IsReserved = true
                };
                //if (DbFunctions.TruncateTime(ev.EventStart)< DbFunctions.TruncateTime(System.DateTime.Today))
                //{
                //    deviceCell.IsPast = true;
                //}
                table.Add(day, hour, deviceCell, hourValue);
            }
            model.DeviceTable = table;
            return model;
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
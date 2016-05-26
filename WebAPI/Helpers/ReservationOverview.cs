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
        public static DeviceOverviewModel FindDeviceReservations(SearchModel modelParameters)
        {
            SchoolContext context = new SchoolContext();
            Resource resource = new Resource();
            DeviceOverviewModel model = new DeviceOverviewModel();
            SetWeeklyInterval(modelParameters.FromDate, modelParameters);
            DeviceTableModel table = new DeviceTableModel(modelParameters.FromDate);

            var deviceResource = new ResourceUnit(context).Get()
                .Where(x => (x.Name == modelParameters.ResourceName) && (x.ResourceCategory.CategoryName == modelParameters.CategoryName))
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
                    Id = ch.Id,
                    Name = ch.Name,
                    Value = ch.Value
                });
               
            }

            foreach (var ev in events)
            {
                IList<Event> DeviceEvents = new List<Event>();

                while (ev.EventStart != ev.EventEnd)
                {
                    var newStart = Convert.ToDateTime(ev.EventStart);
                    var newEnd = newStart.AddHours(1);

                    Event newEvent = new Event()
                    {
                        Id = ev.Id,
                        User = ev.User,
                        Resource = ev.Resource,
                        EventTitle = ev.EventTitle,
                        EventStart = ev.EventStart,
                        EventEnd = ev.EventEnd,

                    };

                    ev.EventStart = newEnd;

                    DeviceEvents.Add(newEvent);
                }
                foreach (var deviceEv in DeviceEvents)
                {
                    int day = 0;
                    int hour = 0;
                    int hourValue = 0;
                    //set day parametar
                    if (deviceEv.EventStart.DayOfWeek.ToString() == "Monday") { day = 0; }
                    if (deviceEv.EventStart.DayOfWeek.ToString() == "Tuesday") { day = 1; }
                    if (deviceEv.EventStart.DayOfWeek.ToString() == "Wednesday") { day = 2; }
                    if (deviceEv.EventStart.DayOfWeek.ToString() == "Thursday") { day = 3; }
                    if (deviceEv.EventStart.DayOfWeek.ToString() == "Friday") { day = 4; }
                    // set hour parametar
                    if (deviceEv.EventStart.ToShortTimeString() == "9:00") { hour = 0; hourValue = 9; }
                    if (deviceEv.EventStart.ToShortTimeString() == "10:00") { hour = 1; hourValue = 10; }
                    if (deviceEv.EventStart.ToShortTimeString() == "11:00") { hour = 2; hourValue = 11; }
                    if (deviceEv.EventStart.ToShortTimeString() == "12:00") { hour = 3; hourValue = 12; }
                    if (deviceEv.EventStart.ToShortTimeString() == "13:00") { hour = 4; hourValue = 13; }
                    if (deviceEv.EventStart.ToShortTimeString() == "14:00") { hour = 5; hourValue = 14; }
                    if (deviceEv.EventStart.ToShortTimeString() == "15:00") { hour = 6; hourValue = 15; }
                    if (deviceEv.EventStart.ToShortTimeString() == "16:00") { hour = 7; hourValue = 16; }
                    // set device cell model
                    var deviceCell = new DeviceCellModel
                    {   Id=deviceEv.Id,
                        EventTitle = deviceEv.EventTitle,
                        PersonName = deviceEv.User.FullName,
                        Hour = hourValue,
                        IsPast = false,
                        IsReserved = true,
                        IsExtended=deviceEv.isExtended
                    };
                    table.Add(day, hour, deviceCell);
                }
            }
            model.DeviceTable = table;
            return model;
        }


        public static IList<RoomTableModel> FindRoomReservations(SearchModel modelParameters)
        {
            SchoolContext context = new SchoolContext();
            List<RoomTableModel> models = new List<RoomTableModel>();
            var rooms = new ResourceUnit(context).Get().Where(x => x.ResourceCategory.CategoryName == modelParameters.CategoryName).ToList();
            
            foreach (var room in rooms)
            {
                RoomTableModel roomModel = new RoomTableModel(modelParameters.FromDate, room);
                var events = new EventUnit(context).Get()
                .Where(x => (x.Resource.ResourceCategory.CategoryName == modelParameters.CategoryName && x.Resource.Name == room.Name) &&
                (DbFunctions.TruncateTime(x.EventStart) >= DbFunctions.TruncateTime(modelParameters.FromDate) && DbFunctions.TruncateTime(x.EventStart) <= DbFunctions.TruncateTime(modelParameters.ToDate))).ToList();
                var tmpEvents = new EventUnit(context).Get()
                .Where(x => (x.Resource.ResourceCategory.CategoryName == modelParameters.CategoryName && x.Resource.Name == room.Name && x.isExtended==true) &&
                (DbFunctions.TruncateTime(x.EventStart) <= DbFunctions.TruncateTime(modelParameters.FromDate) && DbFunctions.TruncateTime(x.EventStart) <= DbFunctions.TruncateTime(modelParameters.ToDate))).ToList();
                var extendedEvents = new ExtendedEventUnit(context).Get().Where(x => x.RepeatUntil >= modelParameters.FromDate.Date).ToList();
                IList<Event> RoomEvents = new List<Event>();
                IList<Event> TempEvents = new List<Event>();
                foreach (var tempEv in tmpEvents)
                {
                    foreach (var extendedEvent in extendedEvents)
                    {
                        if (tempEv.Id == extendedEvent.ParentEvent.Id)
                        {
                            if (extendedEvent.RepeatingType == RepeatType.Daily)
                            {
                                while (tempEv.EventStart.Date <= modelParameters.FromDate.Date)
                                {
                                    tempEv.EventStart = tempEv.EventStart.AddDays(1);
                                    tempEv.EventEnd = tempEv.EventEnd.AddDays(1);
                                    if (tempEv.EventStart.Date == modelParameters.FromDate.Date)
                                    {
                                        TempEvents.Add(new Event
                                        {
                                            Id = tempEv.Id,
                                            EventTitle = tempEv.EventTitle,
                                            Resource = tempEv.Resource,
                                            EventEnd = tempEv.EventEnd,
                                            EventStart = tempEv.EventStart,
                                            isExtended = tempEv.isExtended,
                                            User = tempEv.User
                                        });
                                    }
                                }
                            }
                            if (extendedEvent.RepeatingType == RepeatType.Weekly)
                            {
                                while (tempEv.EventStart.Date <= modelParameters.FromDate.Date)
                                {
                                    tempEv.EventStart = tempEv.EventStart.AddDays(7);
                                    tempEv.EventEnd = tempEv.EventEnd.AddDays(7);
                                    if (tempEv.EventStart.Date == modelParameters.FromDate.Date)
                                    {
                                        TempEvents.Add(new Event
                                        {
                                            Id = tempEv.Id,
                                            EventTitle = tempEv.EventTitle,
                                            Resource = tempEv.Resource,
                                            EventEnd = tempEv.EventEnd,
                                            EventStart = tempEv.EventStart,
                                            isExtended = tempEv.isExtended,
                                            User = tempEv.User
                                        });
                                    }
                                }
                            }
                            if (extendedEvent.RepeatingType == RepeatType.Monthly)
                            {
                                while (tempEv.EventStart.Date <= modelParameters.FromDate.Date)
                                {
                                    tempEv.EventStart = tempEv.EventStart.AddMonths(1);
                                    tempEv.EventEnd = tempEv.EventEnd.AddMonths(1);
                                    if (tempEv.EventStart.Date == modelParameters.FromDate.Date)
                                    {
                                        TempEvents.Add(new Event
                                        {
                                            Id = tempEv.Id,
                                            EventTitle = tempEv.EventTitle,
                                            Resource = tempEv.Resource,
                                            EventEnd = tempEv.EventEnd,
                                            EventStart = tempEv.EventStart,
                                            isExtended = tempEv.isExtended,
                                            User = tempEv.User
                                        });
                                    }
                                }
                            }

                        }
                    }
                }
                events.AddRange(TempEvents);
                foreach (var ev in events)
                {
                    while (ev.EventStart != ev.EventEnd)
                    {
                        var newStart = Convert.ToDateTime(ev.EventStart);
                        var newEnd = newStart.AddMinutes(15);

                        Event newEvent = new Event()
                        {
                            Id = ev.Id,
                            User = ev.User,
                            Resource = ev.Resource,
                            EventTitle = ev.EventTitle,
                            EventStart = ev.EventStart,
                            EventEnd = ev.EventEnd,

                        };

                        ev.EventStart = newEnd;

                        RoomEvents.Add(newEvent);
                    }
                }

                foreach (var roomEv in RoomEvents)
                {
                    foreach (var timeSlot in roomModel.Room.TimeSlots)
                    {
                        if (roomEv.EventStart == Convert.ToDateTime(timeSlot.EventStart))
                        {
                            timeSlot.Id = roomEv.Id;
                            timeSlot.EventTitle = roomEv.EventTitle;
                            timeSlot.EventStart = roomEv.EventStart.ToString();
                            timeSlot.EventEnd = roomEv.EventEnd.ToString();
                            timeSlot.StartTime = roomEv.EventStart.ToShortTimeString();
                            timeSlot.EndTime = roomEv.EventEnd.ToShortTimeString();
                            timeSlot.PersonName = roomEv.User.FullName;
                            timeSlot.IsReserved = true;
                            timeSlot.IsExtended = roomEv.isExtended;
                        }
                    }
                }
                models.Add(roomModel);

            }

            return models;
        }
        public static IList<List<RoomTableModel>> FindWeeklyRoomReservations(SearchModel modelParameters)
        {
            SchoolContext context = new SchoolContext();

            IList<List<RoomTableModel>> weekModels = new List<List<RoomTableModel>>();
            var rooms = new ResourceUnit(context).Get().Where(x => x.ResourceCategory.CategoryName == modelParameters.CategoryName).ToList();
            while (modelParameters.FromDate.Date <= modelParameters.ToDate.Date)
            {
                List<RoomTableModel> models = new List<RoomTableModel>();
                foreach (var room in rooms)
                {
                    RoomTableModel roomModel = new RoomTableModel(modelParameters.FromDate, room);
                    var events = new EventUnit(context).Get()
                    .Where(x => (x.Resource.ResourceCategory.CategoryName == modelParameters.CategoryName && x.Resource.Name == room.Name) &&
                    (DbFunctions.TruncateTime(x.EventStart) >= DbFunctions.TruncateTime(modelParameters.FromDate) && DbFunctions.TruncateTime(x.EventStart) <= DbFunctions.TruncateTime(modelParameters.FromDate))).ToList();
                    IList<Event> RoomEvents = new List<Event>();
                    foreach (var ev in events)
                    {


                        while (ev.EventStart != ev.EventEnd)
                        {
                            var newStart = Convert.ToDateTime(ev.EventStart);
                            var newEnd = newStart.AddMinutes(15);

                            Event newEvent = new Event()
                            {
                                Id = ev.Id,
                                User = ev.User,
                                Resource = ev.Resource,
                                EventTitle = ev.EventTitle,
                                EventStart = ev.EventStart,
                                EventEnd = ev.EventEnd,

                            };
                            ev.EventStart = newEnd;
                            RoomEvents.Add(newEvent);
                        }
                    }

                    foreach (var roomEv in RoomEvents)
                    {
                        foreach (var timeSlot in roomModel.Room.TimeSlots)
                        {
                            if (roomEv.EventStart == Convert.ToDateTime(timeSlot.EventStart))
                            {
                                timeSlot.Id = roomEv.Id;
                                timeSlot.EventTitle = roomEv.EventTitle;
                                timeSlot.EventStart = roomEv.EventStart.ToString();
                                timeSlot.EventEnd = roomEv.EventEnd.ToString();
                                timeSlot.StartTime = roomEv.EventStart.ToShortTimeString();
                                timeSlot.EndTime = roomEv.EventEnd.ToShortTimeString();
                                timeSlot.PersonName = roomEv.User.FullName;
                                timeSlot.IsReserved = true;
                                timeSlot.IsExtended = roomEv.isExtended;
                            }
                        }
                    }
                    models.Add(roomModel);
                }
                modelParameters.FromDate = modelParameters.FromDate.AddDays(1);
                weekModels.Add(models);
            }


            return weekModels;
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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Database;
using WebAPI.Models;
using System.Data.Entity;

namespace WebAPI.Helpers
{
    public static class UserReservations
    {
        public static UserReservationsModel Create()
        {
            SchoolContext context = new SchoolContext();

            UserReservationsModel model = new UserReservationsModel()
            {
                Id = AppGlobals.currentUser.Id,
                UserName = AppGlobals.currentUser.FirstName

            };

            var reservations = new EventUnit(context).Get().ToList().Where(x => (x.User.FullName == AppGlobals.currentUser.FullName && x.EventStart >= System.DateTime.Today)).OrderBy(y => y.EventStart).ToList();
            var extended = getExtendedEvents();
            reservations.AddRange(extended);
            foreach (var reservation in reservations)
            {
                if (reservation.EventStart.Date == System.DateTime.Today.Date)
                {
                    model.TodayReservations.Add(new EventListModel()
                    {
                        Id = reservation.Id,
                        EventTitle = reservation.EventTitle,
                        StartDate = reservation.EventStart.ToShortDateString(),
                        EndDate = reservation.EventEnd.ToShortDateString(),
                        PersonName = AppGlobals.currentUser.FullName,
                        ResourceName = reservation.Resource.Name,
                        CategoryName = reservation.Resource.ResourceCategory.CategoryName,
                        Time = reservation.EventStart.ToShortTimeString() + " - " + reservation.EventEnd.ToShortTimeString(),
                        Resource = reservation.Resource.Id,
                        StartTime = Int32.Parse(reservation.EventStart.ToShortTimeString().Split(':')[0]),
                        EndTime = Int32.Parse(reservation.EventEnd.ToShortTimeString().Split(':')[0]),
                        Person = reservation.User.Id,
                        Category = reservation.Resource.ResourceCategory.Id,
                        IsExtended = reservation.isExtended
                    });
                }
                else if (reservation.EventStart.Date > DateTime.Now.Date )
                {
                    model.UpcomingReservations.Add(new EventListModel()
                    {
                        Id = reservation.Id,
                        EventTitle = reservation.EventTitle,
                        StartDate = reservation.EventStart.ToShortDateString(),
                        EndDate = reservation.EventEnd.ToShortDateString(),
                        PersonName = AppGlobals.currentUser.FullName,
                        ResourceName = reservation.Resource.Name,
                        CategoryName = reservation.Resource.ResourceCategory.CategoryName,
                        Time = reservation.EventStart.ToShortTimeString() + " - " + reservation.EventEnd.ToShortTimeString(),
                        Resource = reservation.Resource.Id,
                        StartTime = Int32.Parse(reservation.EventStart.ToShortTimeString().Split(':')[0]),
                        EndTime = Int32.Parse(reservation.EventEnd.ToShortTimeString().Split(':')[0]),
                        Person = reservation.User.Id,
                        Category = reservation.Resource.ResourceCategory.Id,
                        IsExtended=reservation.isExtended

                    });
                }  
            }
            foreach (var activeReservation in reservations)
            {
                model.ActiveReservations.Add(new EventListModel()
                {
                    Id = activeReservation.Id,
                    EventTitle = activeReservation.EventTitle,
                    StartDate = activeReservation.EventStart.ToString(),
                    EndDate = activeReservation.EventEnd.ToString(),
                    PersonName = AppGlobals.currentUser.FullName,
                    ResourceName = activeReservation.Resource.Name,
                    CategoryName = activeReservation.Resource.ResourceCategory.CategoryName,
                    Time = activeReservation.EventStart.ToShortTimeString() + " - " + activeReservation.EventEnd.ToShortTimeString(),
                    Resource = activeReservation.Resource.Id,
                    Person = activeReservation.User.Id,
                    Category = activeReservation.Resource.ResourceCategory.Id,
                    IsExtended = activeReservation.isExtended
                    
                });
            }

            model.CountToday = model.TodayReservations.Count;
            model.CountUpcoming = model.UpcomingReservations.Count;
            return model;
        }

        public static IList<Event> getExtendedEvents()
        {
            var date = DateTime.Now;
            SchoolContext context = new SchoolContext();
            var tmpEvents = new EventUnit(context).Get()
               .Where(x => x.isExtended == true && DbFunctions.TruncateTime(x.EventStart) <= date.Date).ToList();
            var extendedEvents = new ExtendedEventUnit(context).Get().Where(x => x.RepeatUntil >= date.Date).ToList();
            IList<Event> TempEvents = new List<Event>();
            foreach (var tempEv in tmpEvents)
            {
                foreach (var extendedEvent in extendedEvents)
                {
                    if (tempEv.Id == extendedEvent.ParentEvent.Id)
                    {
                        if (extendedEvent.RepeatingType == RepeatType.Daily)
                        {
                            while (tempEv.EventStart.Date < date.Date)
                            {
                                tempEv.EventStart = tempEv.EventStart.AddDays(1);
                                tempEv.EventEnd = tempEv.EventEnd.AddDays(1);
                                if (tempEv.EventStart.Date == date.Date)
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
                            while (tempEv.EventStart.Date < date.Date)
                            {
                                tempEv.EventStart = tempEv.EventStart.AddDays(7);
                                tempEv.EventEnd = tempEv.EventEnd.AddDays(7);
                                if (tempEv.EventStart.Date == date.Date)
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
                            while (tempEv.EventStart.Date < date.Date)
                            {
                                tempEv.EventStart = tempEv.EventStart.AddMonths(1);
                                tempEv.EventEnd = tempEv.EventEnd.AddMonths(1);
                                if (tempEv.EventStart.Date == date.Date)
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
            return TempEvents;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Database;
using WebAPI.Models;

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

            var reservations = new EventUnit(context).Get().ToList().Where(x => (x.User.FullName == AppGlobals.currentUser.FullName && x.EventStart >= System.DateTime.Today)).OrderBy(y => y.EventStart);

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
                        Category = reservation.Resource.ResourceCategory.Id
                    });
                }
                else if (reservation.EventStart.Date > System.DateTime.Now.Date)
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
                        Category = reservation.Resource.ResourceCategory.Id
                    });
                }  
            }
            foreach (var activeReservation in reservations)
            {
                model.ActiveReservations.Add(new EventListModel()
                {
                    Id = activeReservation.Id,
                    EventTitle = activeReservation.EventTitle,
                    StartDate = activeReservation.EventStart.ToShortDateString(),
                    EndDate = activeReservation.EventEnd.ToShortDateString(),
                    PersonName = AppGlobals.currentUser.FullName,
                    ResourceName = activeReservation.Resource.Name,
                    CategoryName = activeReservation.Resource.ResourceCategory.CategoryName,
                    Time = activeReservation.EventStart.ToShortTimeString() + " - " + activeReservation.EventEnd.ToShortTimeString(),
                    Resource = activeReservation.Resource.Id,
                    StartTime = Int32.Parse(activeReservation.EventStart.ToShortTimeString().Split(':')[0]),
                    EndTime = Int32.Parse(activeReservation.EventEnd.ToShortTimeString().Split(':')[0]),
                    Person = activeReservation.User.Id,
                    Category = activeReservation.Resource.ResourceCategory.Id
                });
            }

            model.CountToday = model.TodayReservations.Count;
            model.CountUpcoming = model.UpcomingReservations.Count;
            return model;
        }
    }
}
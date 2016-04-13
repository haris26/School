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
                //Id = 4,
                //UserName = "Martina"
            };

            var reservations = new EventUnit(context).Get().ToList().Where(x => (x.User.FullName == AppGlobals.currentUser.FullName && x.EventStart >= System.DateTime.Today)).OrderBy(y => y.EventStart);
            //var reservations = new EventUnit(context).Get().ToList().Where(x => (x.User.FullName == "Martina Vistica" && x.EventStart.Date >= System.DateTime.Today.Date)).OrderBy(y => y.EventStart);

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
                        //Person = AppGlobals.currentUser.Id,
                        PersonName = AppGlobals.currentUser.FullName,
                        //PersonName = "Martina Vistica",
                        ResourceName = reservation.Resource.Name,
                        CategoryName = reservation.Resource.ResourceCategory.CategoryName,
                        Time = reservation.EventStart.ToShortTimeString() + " - " + reservation.EventEnd.ToShortTimeString()
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
                        //Person = AppGlobals.currentUser.Id,
                        PersonName = AppGlobals.currentUser.FullName,
                        //PersonName = "Martina Vistica",
                        ResourceName = reservation.Resource.Name,
                        CategoryName = reservation.Resource.ResourceCategory.CategoryName,
                        Time = reservation.EventStart.ToShortTimeString() + " - " + reservation.EventEnd.ToShortTimeString()
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
                    //Person = AppGlobals.currentUser.Id,
                    PersonName = AppGlobals.currentUser.FullName,
                    //PersonName = "Martina Vistica",
                    ResourceName = activeReservation.Resource.Name,
                    CategoryName = activeReservation.Resource.ResourceCategory.CategoryName,
                    Time = activeReservation.EventStart.ToShortTimeString() + " - " + activeReservation.EventEnd.ToShortTimeString()
                });
            }

            model.CountToday = model.TodayReservations.Count;
            model.CountUpcoming = model.UpcomingReservations.Count;
            return model;
        }
    }
}
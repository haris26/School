using System;
using System.Collections.Generic;
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

            var reservations = new EventUnit(context).Get().ToList().Where(x => (x.User.FullName == AppGlobals.currentUser.FullName));
            foreach (var reservation in reservations)
            {
                if (reservation.EventStart == System.DateTime.Today)
                {
                    model.TodayReservations.Add(new ReservationModel()
                    {
                        Id = reservation.Id,
                        ResourceName = reservation.Resource.Name,
                        StartDate = reservation.EventStart,
                        EndDate = reservation.EventEnd
                    });
                }
                else if (reservation.EventStart > System.DateTime.Now)
                {
                    model.UpcomingReservations.Add(new ReservationModel()
                    {
                        Id = reservation.Id,
                        ResourceName = reservation.Resource.Name,
                        StartDate = reservation.EventStart,
                        EndDate = reservation.EventEnd
                    });
                }
            }
            model.CountToday = model.TodayReservations.Count;
            model.CountUpcoming = model.UpcomingReservations.Count;

            return model;
        }
    }
}
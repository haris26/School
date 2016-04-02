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

            var reservations = new EventUnit(context).Get().ToList().Where(x => (x.User.FullName == AppGlobals.currentUser.FullName && x.EventStart>=System.DateTime.Today)).OrderBy(y=> y.EventStart);
            
            foreach (var reservation in reservations)
            {
                if (reservation.EventStart == System.DateTime.Today)
                {
                    model.TodayReservations.Add(new EventModel()
                    {
                        Id = reservation.Id,
                        EventTitle = reservation.EventTitle,
                        StartDate = reservation.EventStart,
                        EndDate = reservation.EventEnd,
                        Person = AppGlobals.currentUser.Id,
                        PersonName = AppGlobals.currentUser.FullName,
                        Resource = reservation.Resource.Id,
                        ResourceName = reservation.Resource.Name,
                        Category = reservation.Resource.ResourceCategory.Id,
                        CategoryName = reservation.Resource.ResourceCategory.CategoryName,
                    });
                }
                else if (reservation.EventStart > System.DateTime.Now)
                {
                    model.UpcomingReservations.Add(new EventModel()
                    {
                        Id = reservation.Id,
                        EventTitle = reservation.EventTitle,
                        StartDate = reservation.EventStart,
                        EndDate = reservation.EventEnd,
                        Person = AppGlobals.currentUser.Id,
                        PersonName = AppGlobals.currentUser.FullName,
                        Resource = reservation.Resource.Id,
                        ResourceName = reservation.Resource.Name,
                        Category = reservation.Resource.ResourceCategory.Id,
                        CategoryName = reservation.Resource.ResourceCategory.CategoryName,
                    });
                }
               
            }
            foreach (var activeReservation in reservations)
            {
                model.ActiveReservations.Add(new EventModel()
                {
                    Id = activeReservation.Id,
                    EventTitle = activeReservation.EventTitle,
                    StartDate = activeReservation.EventStart,
                    EndDate = activeReservation.EventEnd,
                    Person = AppGlobals.currentUser.Id,
                    PersonName = AppGlobals.currentUser.FullName,
                    Resource = activeReservation.Resource.Id,
                    ResourceName = activeReservation.Resource.Name,
                    Category = activeReservation.Resource.ResourceCategory.Id,
                    CategoryName = activeReservation.Resource.ResourceCategory.CategoryName,
                });
            }

            model.CountToday = model.TodayReservations.Count;
            model.CountUpcoming = model.UpcomingReservations.Count;
            return model;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class UserReservationsModel
    {
        public UserReservationsModel()
        {
            TodayReservations = new List<ReservationModel>();
            UpcomingReservations = new List<ReservationModel>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public int CountToday { get; set; }
        public int CountUpcoming { get; set; }
        public List<ReservationModel> TodayReservations { get; set; }
        public List<ReservationModel> UpcomingReservations { get; set; } 
    }
}
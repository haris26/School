using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UserReservationsModel
    {
        public UserReservationsModel()
        {
            TodayReservations = new List<EventModel>();
            UpcomingReservations = new List<EventModel>();
            ActiveReservations = new List<EventModel>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public int CountToday { get; set; }
        public int CountUpcoming { get; set; }
        public IList<EventModel> TodayReservations { get; set; }
        public IList<EventModel> UpcomingReservations { get; set; }
        public IList<EventModel> ActiveReservations { get; set; }
    }
}
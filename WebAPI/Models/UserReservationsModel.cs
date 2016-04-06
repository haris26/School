using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EventListModel
    {
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string PersonName { get; set; }
        public string ResourceName { get; set; }
        public string CategoryName { get; set; }
        public string Time { get; set; }
    }

    public class UserReservationsModel
    {
        public UserReservationsModel()
        {
            TodayReservations = new List<EventListModel>();
            UpcomingReservations = new List<EventListModel>();
            ActiveReservations = new List<EventListModel>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public int CountToday { get; set; }
        public int CountUpcoming { get; set; }
        public IList<EventListModel> TodayReservations { get; set; }
        public IList<EventListModel> UpcomingReservations { get; set; }
        public IList<EventListModel> ActiveReservations { get; set; }
    }
}
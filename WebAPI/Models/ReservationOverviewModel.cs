using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace WebAPI.Models
{
    public class CharacteristicsListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class EventsListModel
    {
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int Person { get; set; }
        public string PersonName { get; set; }
        public string Time { get; set; }
    }

    public class ReservationOverviewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public IList<CharacteristicsListModel> Characteristics { get; set; }
        public IList<EventsListModel> Events { get; set; }
        public ReservationOverviewModel()
        {
            Characteristics = new List<CharacteristicsListModel>();
            Events = new List<EventsListModel>();
        }
    }
}
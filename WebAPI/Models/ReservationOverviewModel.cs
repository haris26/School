using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace WebAPI.Models
{
    public class ResListModel
    {
        public string ResName { get; set; }
        public int ResId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class ReservationOverviewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ResListModel> Characteristics { get; set; }
        public IList<Event> Events { get; set; }

        public ReservationOverviewModel()
        {
            Characteristics = new List<ResListModel>();
            Events = new List<Event>();
        }
    }
}
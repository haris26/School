using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace WebAPI.Models
{
    public class ReservationOverviewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Characteristic> Characteristics { get; set; }
        public IList<Event> Events { get; set; }

        public ReservationOverviewModel()
        {
            Characteristics = new List<Characteristic>();
            Events = new List<Event>();
        }
    }
}
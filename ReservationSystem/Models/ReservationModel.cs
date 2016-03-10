using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace ReservationSystem.Models
{
    public class ReservationModel
    {
        public ReservationModel()
        {
            Characteristics = new List<Characteristic>();
            Events = new List<Event>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Characteristic> Characteristics { get; set; }
        public IList<Event> Events { get; set; }
    }
}
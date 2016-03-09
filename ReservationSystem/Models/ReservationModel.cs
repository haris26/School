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
            Resources = new List<ResourceModel>();
            ResourceCharacteristics = new List<Characteristic>();
            Events = new List<EventModel>();
        }
        public int Id { get; set; }
        public IList<ResourceModel> Resources { get; set; }
        public IList<Characteristic> ResourceCharacteristics { get; set; }
        public IList<EventModel> Events { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace ReservationSystem.Models
{
    public class EventExtendModel
    {
        public int Id { get; set; }
        public Event ParentEvent { get; set; }
        public DateTime RepeatUntil { get; set; }
        public RepeatType RepeatingType { get; set; }
        public int Frequency { get; set; }
        
    }
}
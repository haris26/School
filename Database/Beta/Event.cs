using System;
using System.ComponentModel.DataAnnotations;
using Database.Beta;

// RESERVATION SYSTEM
namespace Database
{
//  List of events (meetings, test process...)
    public class Event
    {
        public int Id { get; set; }                         // Identity[1]
        public virtual Resource Resource { get; set; }      // Navigation to resource 
        public virtual Person User { get; set; }            // Person who made reservation
        [EventTitleControl]
        public string EventTitle { get; set; }              // Description of the event
        public DateTime EventStart { get; set; }            // Reservation from...
        public DateTime EventEnd { get; set; }              // Reservation to...
        public bool isExtended { get; set; }
        public virtual ExtendedEvent ParentEvent { get; set; }
    }
}
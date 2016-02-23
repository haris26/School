using System;

// RESERVATION SYSTEM
namespace Database
{
//  List of events (meetings, test process...)
    public class Event
    {
        public int Id { get; set; }                         // Identity[1]
        public virtual Resource Resource { get; set; }      // Navigation to resource 
        public virtual Person User { get; set; }            // Person who made reservation
        public string EventTitle { get; set; }              // Description of the event
        public DateTime EventStart { get; set; }            // Reservation from...
        public DateTime EventEnd { get; set; }              // Reservation to...
<<<<<<< HEAD:Database/Event.cs

        // in case of reccuring event
        //public virtual Event ParentEvent { get; set; }      // Parent event
        //public DateTime RepeatUntil { get; set; }           // Time/Date of the last event in the chain
        //public RepeatType RepeatingType { get; set; }       // daily, weekly, monthly...
        //public int Frequency { get; set; }                  // each day, two days etc
=======
>>>>>>> dev:Database/Beta/Event.cs
    }
}
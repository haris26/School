using System;

namespace Database
{
    public class Event
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int ParentId { get; set; }
        public int EmployeeId { get; set; }
        public string EventTitle { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public DateTime RepeatUntil { get; set; }
        public TimeRepeat RepeatingType { get; set; }
        public int Frequency { get; set; }
    }
}

using System;

namespace Database
{
    public class Event
    {
        public int Id { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual  Event ParentEvent { get; set; }
        public virtual Person User { get; set; }
        public string EventTitle { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public DateTime RepeatUntil { get; set; }
        public TimeRepeat RepeatingType { get; set; }
        public int Frequency { get; set; }
    }
}

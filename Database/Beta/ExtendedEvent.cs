using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ExtendedEvent
    {
        public int Id { get; set; }
        public virtual Event ParentEvent { get; set; }      // Parent event
        public DateTime RepeatUntil { get; set; }           // Time/Date of the last event in the chain
        public RepeatType RepeatingType { get; set; }       // daily, weekly, monthly...
        public int Frequency { get; set; }                  // each day, two days etc
    }
}

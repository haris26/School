using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// TIME TRACKING
namespace Database
{
//  Class for one day in person's life
    public class Day
    {
        public Day()
        {
            Details = new Collection<Detail>();
        }

        public int Id { get; set; }                     // Indentity[1]
        public DateTime Date { get; set; }              // Date

        public double WorkTime { get; set; }                   // Total work time for that day

        public double PtoTime { get; set; }                    // Total PTO for that day
        public EntryStatus EntryStatus { get; set; }    // Flag: can person edit details or not
        
        public virtual Person Person { get; set; }      // Navigation to Person class
        // we need details for a day
        public virtual ICollection<Detail> Details { get; set; }    // work details for a day

        [NotMapped]
        public double totalHoursForDay {
            get {
                foreach (Detail detail in Details) {
                    totalHoursForDay += detail.WorkTime;
                }
                return totalHoursForDay;
            }

            set { totalHoursForDay = value; }

        }
}
}



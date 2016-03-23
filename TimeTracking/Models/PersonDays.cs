using Database;
using System.Collections.Generic;

namespace TimeTracking.Models
{
    public class PersonDays
    {
        public PersonDays()
        {
            Days = new List<DayModel>();
        }
        public Person Person { get; set; }
        public IList<DayModel> Days { get; set; }
    }
}
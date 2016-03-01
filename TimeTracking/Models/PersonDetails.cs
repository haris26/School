using Database;
using System.Collections.Generic;

namespace TimeTracking.Models
{
    public class PersonDetails
    {
        public PersonDetails()
        {
            Details = new List<DayModel>();
        }
        public Person Person { get; set; }
        public IList<DayModel> Details { get; set; }
    }
}
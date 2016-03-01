using Database;
using System.Collections.Generic;

namespace TimeTracking.Models
{
    public class DayDetail
    {
        public DayDetail()
        {
            Detail = new List<DetailModel>();
        }
        public Day Day { get; set; }
        public IList<DetailModel> Detail { get; set; }
    }
}
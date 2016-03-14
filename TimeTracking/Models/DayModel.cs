using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracking.Models
{
    public class DayModel
    {
        public DayModel()
        {
            Detail = new List<DetailModel>();
        }


        public int Id { get; set; }
        public int Person { get; set; }
        public string PersonName { get; set; }
        public DateTime Date { get; set; }
        public double WorkTime { get; set; }
        public double PtoTime { get; set; }
        public EntryStatus EntryStatus { get; set; }
        public int DetailId { get; set; }
        public List<DetailModel> Detail { get; set; }
    }
}
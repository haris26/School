using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class DetailsModel
    {
        public double WorkTime { get; set; }
        public string Description { get; set; }
        public int Team { get; set; }
        public string TeamName { get; set; }
    }
    public class DayModel
    {
        public DayModel()
        {
            Details = new List<DetailModel>();
            Detail detail = new Detail();
            EntryStatus = EntryStatus.Unlocked;
        }

        public IList<DetailModel> Details { get; set; }
        public int Id { get; set; }
        public int Person { get; set; }
        public string PersonName { get; set; }
        public DateTime Date { get; set; }
        public double WorkTime { get; set; }
        public double PtoTime { get; set; }
        public EntryStatus EntryStatus { get; set; }
        //public int DetailId { get; set; }
        //public IList<string> Detail { get; set; }
    }
}

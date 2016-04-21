using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ExtendedOverviewModel
    {
        public int Id { get; set; }
        public int ParentEvent { get; set; }
        public string EventTitle { get; set; }
        public string PersonName { get; set; }
        public string ResourceName { get; set; }
        public string RepeatUntil { get; set; }
        public string DayOfWeek { get; set; }
        public string EventTime { get; set; }
        public string RepeatingType { get; set; }
        public int Frequency { get; set; }
    }
}
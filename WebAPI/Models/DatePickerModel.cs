using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class DateFilterModel
    {
        public DateTime today { get; set; }
        public string type { get; set; }
        public int step { get; set; }
    }

    public class DayPickerModel
    {
        public DateTime today { get; set; }
       public string todayDay { get; set; }

    }

    public class WeekPickerModel
    {
       public DateTime today { get; set; }
       public DateTime weekStart { get; set; }
       public string weekStartDay { get; set; }
       public DateTime weekEnd { get; set; }
       public string weekEndDay { get; set; }
       public string month { get; set; }
    }
}
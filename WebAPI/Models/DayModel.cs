﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class DayModel
    {
        public DayModel()
        {
            Details = new List<CountModel>();
            EntryStatus = EntryStatus.Unlocked;
        }


        public int Id { get; set; }
        public int Person { get; set; }
        public string PersonName { get; set; }
        public DateTime Date { get; set; }
        public double WorkTime { get; set; }
        public double PtoTime { get; set; }
        public EntryStatus EntryStatus { get; set; }
        public IList<CountModel> Details { get; set; }
        //public int DetailId { get; set; }
        //public IList<string> Detail { get; set; }
    }
}

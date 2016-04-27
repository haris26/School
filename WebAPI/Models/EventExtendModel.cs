using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace WebAPI.Models
{
    public class EventExtendModel
    {
        public int Id { get; set; }
        public int ParentEvent { get; set; }
        public string RepeatUntil { get; set; }
        public RepeatType RepeatingType { get; set; }
        public int Frequency { get; set; }
    }
}
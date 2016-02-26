using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcurementSystem.Models
{
    public class EngagementModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Time { get; set; }
        public int Person { get; set; }
        public string PersonName { get; set; }
        public int Team { get; set; }
        public string TeamName { get; set; }
        public int Role { get; set; }
        public string RoleName { get; set; }
    }
}
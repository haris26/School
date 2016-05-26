using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EngagementModel
    {
        public int Id { get; set; }
        public int Person { get; set; }
        public string PersonName { get; set; }
        public double WorkTime { get; set; }
        public string Description { get; set; }
        public int Team { get; set; }
        public string TeamName { get; set; }
        public int Role { get; set; }
        public string RoleName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class OverviewModel
    {
        public int NumOfPeople { get; set; }
        public double AvgSkillLevel { get; set; }
        public int NumOfTeams { get; set; }
        public int NumOfSkills { get; set; }
    }
}
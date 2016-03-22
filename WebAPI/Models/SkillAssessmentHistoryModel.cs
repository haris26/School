using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SkillAssessment
    {
        public DateTime Date { get; set; }
        public int Level { get; set; }
    }

    public class SkillAssessmentHistoryModel
    {
        public string SkillName { get; set; }
        public IList<SkillAssessment> SkillAssessments { get; set; }
    }
}
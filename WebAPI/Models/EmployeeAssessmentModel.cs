using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Assessment
    {
        public DateTime? LastCompleted { get; set; }
        public DateTime? NextDue { get; set; }
        public string Status { get; set; }
    }
    
    public class AvailableSkill
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EmployeeAssessmentModel
    {
        public EmployeeAssessmentModel()
        {
            Engagements = new List<EngagementDetail>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public IList<EngagementDetail> Engagements { get; set; }
        public IList<AvailableSkill> AvailableSkills { get; set; }
        public Assessment SelfAssessment { get; set; }
        public Assessment SupervisorAssessment { get; set; }
    }
}
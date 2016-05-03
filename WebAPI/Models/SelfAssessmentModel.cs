using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SelfAssessmentModel
    {
        public SelfAssessmentModel()
        {
            Skills = new List<EmployeeSkillsSummary>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime SupervisorAssessmentDate { get; set; }
        public IList<EmployeeSkillsSummary> Skills { get; set; }

    }
}
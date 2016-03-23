using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SupervisorAssessmentModel
    {
        public SupervisorAssessmentModel()
        {
            Skills = new List<EmployeeSkillsSummary>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime SelfAssessmentDate { get; set; }
        public IList<EmployeeSkillsSummary> Skills { get; set; }

    }
}
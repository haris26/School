using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EmployeeEducationDetail
    {
        public string Qualification { get; set; }
        public string Reference { get; set; }
    }

    public class EngagementDetail
    {
        public string Team { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
    }

    public class EmployeeSummaryModel
    {
        public EmployeeSummaryModel()
        {
            Engagements = new List<EngagementDetail>();
            Skills = new List<EmployeeSkillsSummary>();
            Qualifications = new List<EmployeeEducationDetail>();
            PastProjects = new List<EngagementDetail>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public int Gender { get; set; }
        public IList<EngagementDetail> Engagements { get; set; }
        public IList<EmployeeSkillsSummary> Skills { get; set; }
        public IList<EmployeeEducationDetail> Qualifications { get; set; }
        public IList<EngagementDetail> PastProjects { get; set; }
    }
}
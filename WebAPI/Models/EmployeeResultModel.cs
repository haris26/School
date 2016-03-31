using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EmployeeResultModel
    {
        public EmployeeResultModel()
        {
            Skills = new List<EmployeeSkillDetail>();
            Educations = new List<EmployeeEducationDetail>();
        }

        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public IList<EngagementDetail> Engagements { get; set; }
        public IList<EmployeeSkillDetail> Skills { get; set; }
        public IList<EmployeeEducationDetail> Educations { get; set; }
    }
}
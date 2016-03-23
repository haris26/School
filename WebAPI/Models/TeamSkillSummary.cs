using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class TeamSkillSummary
    {
        public TeamSkillSummary()
        {
            MemberSkills = new Dictionary<int, EmployeeSkillDetail>();
        }

        public double AverageLevel { get; set; }
        public IDictionary<int, EmployeeSkillDetail> MemberSkills { get; set; }  //key is employee id
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EmployeeSkillDetail
    {
        public string Skill { get; set; }
        public int Level { get; set; }
        public int? Experience { get; set; }
    }

    public class EmployeeSkillsSummary
    {
        public EmployeeSkillsSummary()
        {
            Skills = new List<EmployeeSkillDetail>();
        }

        public string CategoryName { get; set; }
        public IList<EmployeeSkillDetail> Skills { get; set; }
    }
}
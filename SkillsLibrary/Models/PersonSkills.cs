using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillsLibrary.Models
{
    public class PersonSkills
    {
        public PersonSkills()
        {
            Skills = new List<EmployeeSkillModel>();
        }
        public Person Person { get; set; }
        public IList<EmployeeSkillModel> Skills { get; set; }
    }
}
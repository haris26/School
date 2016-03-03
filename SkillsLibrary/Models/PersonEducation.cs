using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillsLibrary.Models
{
    public class PersonEducation
    {
        public PersonEducation()
        {
            Educations = new List<EmployeeEducationModel>();
        }
        public Person Person { get; set; }
        public IList<EmployeeEducationModel> Educations { get; set; }
    }
}
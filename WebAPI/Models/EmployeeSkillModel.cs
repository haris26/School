using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EmployeeSkillModel
    {
        public int Id { get; set; }
        public int Employee { get; set; }
        public int Tool { get; set; }
        public Level Level { get; set; }
        public int? Experience { get; set; }
        public DateTime Date { get; set; }
        public AssessmentType AssessedBy { get; set; }
    }
}
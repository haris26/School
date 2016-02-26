using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillsLibrary.Models
{
    public class EmployeeSkillModel
    {
        public int Id { get; set; }
        public int Employee { get; set; }
        public string EmployeeName { get; set; }
        public int Tool { get; set; }
        public string ToolName { get; set; }
        public Level Level { get; set; }
        public int? Experience { get; set; }
    }
}
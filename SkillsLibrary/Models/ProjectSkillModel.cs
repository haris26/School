using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillsLibrary.Models
{
    public class ProjectSkillModel
    {
        public int Id { get; set; }
        public int Project { get; set; }
        public string TeamName { get; set; }
        public string ProjectName { get; set; }
        public int Tool { get; set; }
        public string ToolName { get; set; }
        public Level Level { get; set; }
    }
}
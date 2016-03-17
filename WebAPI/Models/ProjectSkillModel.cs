using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace WebAPI.Models
{
    public class ProjectSkillModel
    {
        public int Id { get; set; }
        public int Team { get; set; }
        public int Tool { get; set; }
        public Level Level { get; set; }
    }
}
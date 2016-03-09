using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkillsLibrary.Models
{
    public class ToolModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
    }
}
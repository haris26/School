using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkillsLibrary.Models
{
    public class SkillCategoryModel
    {
        public SkillCategoryModel()
        {
            Tools = new List<ToolModel>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<ToolModel> Tools { get; set; }
    }
}
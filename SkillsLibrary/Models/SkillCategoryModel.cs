using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillsLibrary.Models
{
    public class SkillCategoryModel
    {
        public SkillCategoryModel()
        {
            Tools = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<string> Tools { get; set; }
    }
}
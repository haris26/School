using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace WebAPI.Models
{
    public class SkillModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryModel
    {
        public CategoryModel()
        {
            Skills = new List<SkillModel>();
        }

        public string Name { get; set; }
        public CategoryType CategoryType { get; set; }          //tool, education or certificate
        public IList<SkillModel> Skills { get; set; }
    }

    public class CriteriaModel
    {
        public CriteriaModel()
        {
            Categories = new List<CategoryModel>();
        }

        public IList<CategoryModel> Categories { get; set; }
    }
}
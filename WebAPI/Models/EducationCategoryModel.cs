using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EducationCategoryModel
    {
        public EducationCategoryModel()
        {
            Educations = new List<EducationModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<EducationModel> Educations { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class Criteria
    {
        public static CriteriaModel Create(SchoolContext context)
        {
            var toolCategories = context.SkillCategories.ToList().Select(x => CreateCategoryModel(x)).ToList();
            var educationCategories = context.Educations.GroupBy(x => x.Type)
                                                        .ToList().Select(x => CreateCategoryModel(x))
                                                        .ToList();

            var allCategories = new List<CategoryModel>(toolCategories.Count + educationCategories.Count);
            allCategories.AddRange(toolCategories);
            allCategories.AddRange(educationCategories);

            return new CriteriaModel()
            {
                Categories = allCategories   
            };
        }

        public static CategoryModel CreateCategoryModel(SkillCategory skillCategory)
        {
            return new CategoryModel()
            {
                Name = skillCategory.Name,
                CategoryType = CategoryType.Skills,
                Skills = skillCategory.Tools.Select(x => CreateSkillModel(x)).ToList()
            };
        } 

        public static CategoryModel CreateCategoryModel (IGrouping<EducationType, Education> educationsCategory)
        {
            CategoryModel category = new CategoryModel() {  CategoryType = CategoryType.Educations};
            EducationType type = educationsCategory.Key;

            if (type == EducationType.School)
            {
                category.Name = "Education";
            }
            else if (type == EducationType.Course)
            {
                category.Name = "Course";
            }
            else
            {
                category.Name = "Certificate";
            }

            category.Skills = educationsCategory.ToList().Select(x => CreateSkillModel(x)).ToList();

            return category;
        }

        public static SkillModel CreateSkillModel (Tool tool)
        {
            return new SkillModel()
            {
                Id = tool.Id,
                Name = tool.Name
            };
        }

        public static SkillModel CreateSkillModel(Education education)
        {
            return new SkillModel()
            {
                Id = education.Id,
                Name = education.Name
            };
        }
    }
}
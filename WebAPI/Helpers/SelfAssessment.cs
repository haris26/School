using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using Database;

namespace WebAPI.Helpers
{
    public class SelfAssessment
    {
        public static SelfAssessmentModel Create(Person person)
        {
            SelfAssessmentModel selfAssessment = new SelfAssessmentModel()
            {
                Id = person.Id,
                FullName = person.FullName,
                Skills = person.EmployeeSkills.Where(x => x.AssessedBy == AssessmentType.Supervisor)
                                           .GroupBy(x => x.Tool.Category)
                                           .Select(x => EmployeeSummary.CreateEmployeeSkillsSummary(x, AssessmentType.Supervisor)).ToList()
            };

            return selfAssessment;
        }
    }
}
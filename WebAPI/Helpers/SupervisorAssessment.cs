using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using Database;

namespace WebAPI.Helpers
{
    public class SupervisorAssessment
    {
        public static SupervisorAssessmentModel Create(Person person)
        {
            SupervisorAssessmentModel supervisorAssessment = new SupervisorAssessmentModel()
            {
                Id = person.Id,
                FullName = person.FullName,
                SelfAssessmentDate = person.EmployeeSkills.ToList().Max(x => x.DateOfSelfAssessment),
                Skills = person.EmployeeSkills.Where(x=>x.AssessedBy== AssessmentType.Self)
                                           .GroupBy(x => x.Tool.Category)
                                           .Select(x => EmployeeSummary.CreateEmployeeSkillsSummary(x, AssessmentType.Self)).ToList()
            };

            return supervisorAssessment;
        }
    }
}
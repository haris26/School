using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class EmployeeAssessment
    {
        public static EmployeeAssessmentModel Create(Person person)
        {
            EmployeeAssessmentModel employeeAssessment = new EmployeeAssessmentModel()
            {
                Id = person.Id,
                FullName = person.FullName
            };

            employeeAssessment.Engagements = person.Roles.Where(x => x.EndDate == null && x.Time > 0).ToList()
                                                         .Select(x => EmployeeSummary.CreateEngagementDetail(x))
                                                         .ToList();

            var employeeSkills = person.EmployeeSkills.ToList();

            employeeAssessment.AvailableSkills = employeeSkills.GroupBy(x => x.Tool.Name).Select(x => new AvailableSkill() { Id = x.FirstOrDefault().Tool.Id, Name = x.Key }).OrderBy(y => y.Name).ToList();

            employeeAssessment.SelfAssessment = new Assessment() { Status = "No Assessments" };
            employeeAssessment.SupervisorAssessment = new Assessment() { Status = "No Supervisor Assessments" };

            if (employeeSkills.Count() > 0)
            {
                employeeAssessment.SelfAssessment.LastCompleted = employeeSkills.Max(x => x.DateOfSelfAssessment);
                employeeAssessment.SelfAssessment.Status = "Completed";
                employeeAssessment.SelfAssessment.NextDue = employeeAssessment.SelfAssessment.LastCompleted.Value.AddMonths(6);
                if (DateTime.Now.Date > employeeAssessment.SelfAssessment.NextDue.Value.Date)
                    employeeAssessment.SelfAssessment.Status = "Due";
            }

            var supervisorAssessments = employeeSkills.Where(x => x.AssessedBy == AssessmentType.Supervisor).ToList();

            if (supervisorAssessments.Count() > 0)
            {
                employeeAssessment.SupervisorAssessment.LastCompleted = supervisorAssessments.Max(x => x.DateOfSupervisorAssessment);
                employeeAssessment.SupervisorAssessment.Status = "Completed";
                employeeAssessment.SupervisorAssessment.NextDue = employeeAssessment.SelfAssessment.NextDue.Value.AddDays(10);
                if (employeeAssessment.SelfAssessment.LastCompleted.Value.Date > employeeAssessment.SupervisorAssessment.LastCompleted.Value.Date)
                {
                    employeeAssessment.SupervisorAssessment.Status = "Due";
                    employeeAssessment.SupervisorAssessment.NextDue = employeeAssessment.SelfAssessment.LastCompleted;
                }
            }

            return employeeAssessment;
            }
    }
}
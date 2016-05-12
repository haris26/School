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
                FullName = person.FullName,
                Avatar = person.Image,
                Gender = (int)person.Gender
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
                var lastCompletedSelf = employeeSkills.Max(x => x.DateOfSelfAssessment);
                var nextDueSelf = lastCompletedSelf.AddMonths(6);

                employeeAssessment.SelfAssessment.LastCompleted = lastCompletedSelf.ToString("d");
                employeeAssessment.SelfAssessment.Status = "Completed";
                employeeAssessment.SelfAssessment.NextDue = nextDueSelf.ToString("d");
                if (DateTime.Now.Date > nextDueSelf.Date)
                    employeeAssessment.SelfAssessment.Status = "Due";

                var supervisorAssessments = employeeSkills.Where(x => x.AssessedBy == AssessmentType.Supervisor).ToList();

                if (supervisorAssessments.Count() > 0)
                {
                    var lastCompletedSupervisor = supervisorAssessments.Max(x => x.DateOfSupervisorAssessment);
                    var nextDueSupervisor = nextDueSelf.AddDays(10);

                    employeeAssessment.SupervisorAssessment.LastCompleted = lastCompletedSupervisor.Value.ToString("d");
                    employeeAssessment.SupervisorAssessment.Status = "Completed";
                    employeeAssessment.SupervisorAssessment.NextDue = nextDueSupervisor.ToString("d");
                    if (lastCompletedSelf > lastCompletedSupervisor)
                    {
                        employeeAssessment.SupervisorAssessment.Status = "Due";
                        employeeAssessment.SupervisorAssessment.NextDue = employeeAssessment.SelfAssessment.LastCompleted;
                    }
                }
            }

            return employeeAssessment;
            }
    }
}
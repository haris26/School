using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;
using WebAPI.Filters;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [TokenAuthorize]
    public class SkillAssessmentHistoriesController : BaseController<Person>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public SkillAssessmentHistoriesController(Repository<Person> depo) : base(depo)
        { }

        [HttpPost]
        public IHttpActionResult Get([FromBody] AssessmentSearchModel search)
        {
            return Ok(Repository.Get(search.EmpId).EmployeeSkills
                                                  .Where(x => x.AssessedBy == AssessmentType.Supervisor 
                                                              && x.DateOfSupervisorAssessment.Value.Date >= search.StartDate
                                                              && x.DateOfSupervisorAssessment.Value.Date <= search.EndDate
                                                              && x.Tool.Id == search.Skill).ToList()
                                                  .Select(x => new SkillAssessment() {
                                                              Date = x.DateOfSupervisorAssessment.Value,
                                                              Level = (int)x.Level }).ToList());
        }
    }
}

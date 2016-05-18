﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Helpers;
using WebAPI.Filters;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [TokenAuthorize]
    public class SelfAssessmentsController : BaseController<Person>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public SelfAssessmentsController(Repository<Person> depo) : base(depo)
        { }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Person person = Repository.Get(id);
                if (person == null)
                {
                    return NotFound();
                }
                return Ok(SelfAssessment.Create(person));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
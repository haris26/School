
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Helpers;

namespace WebAPI.Controllers

{
    public class LoginController : ApiController
    {
        Repository<Person> people = new Repository<Person>(new SchoolContext());

        public IHttpActionResult Get(int id)
        {
            try
            {
                Person person = people.Get(id);
                if (person != null)
                {
                    AppGlobals.currentUser = person;
                    return Ok(person.FirstName);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }

}


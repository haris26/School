﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Filters;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //[TokenAuthorize]
    public class AdminDashboardController : ApiController
    {
        public IHttpActionResult Post( DashboardFilterModel model )
        {
            try
            {
                if (model.CategoryName != null)
                    return Ok(AdminDashboard.Create(model));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ReservationOverviewsController : ApiController
    {
        public IHttpActionResult Post(SearchModel model)
        {
            try
            {
                if (model.CategoryName != null) 
                    return Ok(ReservationOverview.Create(model));
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

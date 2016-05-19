using System;
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
    [TokenAuthorize]
    public class ReservationOverviewController : ApiController
    {
        public IHttpActionResult Post(SearchModel model)
        {
            try
            {
                if (model.OsType != "" && model.ResourceName != "")
                    return Ok(ReservationOverview.FindDeviceReservations(model));
                else if (model.CategoryName == "Room") 
                    return Ok(ReservationOverview.FindRoomReservations(model)); 
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

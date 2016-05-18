using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DatePickerController : ApiController
    {
        public IHttpActionResult Post(DateFilterModel model)
        {
            try
            {
                if (model.type == "daily")
                {
                    DayPickerModel day = new DayPickerModel();
                    TimeSpan ts = new TimeSpan(9, 0, 0);
                    var date = DateTime.Now.Date + ts;
                    day.today = date.AddDays(model.step);
                    day.todayDay = String.Format("{0:m}", day.today);

                    return Ok(day);
                }
                if (model.type == "weekly")
                {
                    WeekPickerModel week = new WeekPickerModel();
                    TimeSpan ts = new TimeSpan(9, 0, 0);
                    model.step = model.step * 7;
                    var date = DateTime.Now.Date + ts;
                    week.today = date.AddDays(model.step);
                    week.weekStart = week.today.AddDays(-Convert.ToInt32(week.today.DayOfWeek)+1);
                    week.weekStartDay = String.Format("{0:m}", week.weekStart);
                    week.Tuesday = week.weekStart.AddDays(1);
                    week.TuesdayDay= String.Format("{0:m}", week.Tuesday);
                    week.Wednesday = week.weekStart.AddDays(2);
                    week.WednesdayDay= String.Format("{0:m}", week.Wednesday);
                    week.Thursday = week.weekStart.AddDays(3);
                    week.ThursdayDay = string.Format("{0:m}", week.Thursday);
                    week.weekEnd = week.weekStart.AddDays(4).AddHours(14).AddMinutes(59);
                    week.weekEndDay = String.Format("{0:m}", week.weekEnd);
                    return Ok(week);
                }

                else return BadRequest();
                    
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

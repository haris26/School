using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;
using TimeTracking.Models;

namespace TimeTracking.Controllers
{
    public class TimeTrackingController : BaseController
    {
 
            public ActionResult CreateDetail()
            {
                FillBag();
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult CreateDetail(DetailModel model)
            {

                Repository<Day> days = new Repository<Day>(Context);
                var day = new DayUnit(Context).Get().Where(x => x.Person.Id == model.Person && x.Date == model.Date).FirstOrDefault();
                if (day == null)
                {
                    days.Insert(Parser.Create(new DayModel()
                    {
                        Person = model.Person,
                        Date = model.Date,

                    }));
                day = new DayUnit(Context).Get().Where(x => x.Person.Id == model.Person && x.Date == model.Date).FirstOrDefault();
                model.Day = day.Id;
                new DetailUnit(Context).Insert(Parser.Create(model));

            }
                else {
                    
                    day = new DayUnit(Context).Get().Where(x => x.Person.Id == model.Person && x.Date == model.Date).FirstOrDefault();
                    model.Day = day.Id;
                    new DetailUnit(Context).Insert(Parser.Create(model));
                    return RedirectToAction("CreateDetail");
                
                //FillBag();
                //return View(model);
            }
            return View(model);
            }

        public ActionResult Days(int id)

        {
            PersonDays model = new PersonDays();
            model.Person = new Repository<Person>(Context).Get(id);
            model.Days = new DayUnit(Context)
                               .Get().Where(x => x.Person.Id == id).ToList()
                               .Select(x => Factory.Create(x)).ToList();
            return View(model);
        }

        void FillBag()
            {
                ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
                ViewBag.TeamsList = new SelectList(new Repository<Team>(Context).Get().ToList(), "Id", "Name");

            }
        }
    }

    

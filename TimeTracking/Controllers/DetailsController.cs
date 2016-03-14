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
using TimeTracking.Help;

namespace TimeTracking.Controllers
{
    public class DetailsController : BaseController
    {
       
        public ActionResult Index()
        {
            return View(new DetailUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        // GET: Details/Details/5
        public ActionResult Details(int id)
        {
            return View(Factory.Create(new DetailUnit(Context).Get(id)));

        }

        // GET: Details/Create
        public ActionResult WeeklyView(PersonDays model)
        {
            
            FillBag();
            DateTime startDayOfWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            DateTime endDayOfWeek = startDayOfWeek.AddDays(6);
            using (SchoolContext context = new SchoolContext())
            {
                ModelFactory modelFactory = new ModelFactory(context);
                for (var day = startDayOfWeek; day <= endDayOfWeek; day = day.AddDays(1))
                {
                    DayModel dayModel = new DayModel();
                    DateTime yesterday = day.AddDays(-1);
                    DateTime tommorow = day.AddDays(1);
                    var days = context.Days.Where(x => x.Date > yesterday && x.Date < tommorow).Include(x=>x.Details).ToList();
                    List<DayModel> daysModel = new List<DayModel>();
                    foreach(var d in days)
                    {
                        dayModel = modelFactory.Create(d);
                        foreach(var detail in d.Details)
                        {
                            dayModel.Detail.Add(modelFactory.Create(detail));
                        }
                        daysModel.Add(dayModel);
                    }
                    model.Days.AddRange(daysModel);                   
                }
            }
            return View("WeeklyView", model);
        }

        // POST: Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult WeeklyView(DetailModel model)
        {
            if (ModelState.IsValid)
            {
                new DetailUnit(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Details/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(Factory.Create(new DetailUnit(Context).Get(id)));

        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(DetailModel model)
        {
            if (ModelState.IsValid)
            {
                new DetailUnit(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Details/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Factory.Create(new DetailUnit(Context).Get(id)));

        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            new DetailUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }


        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
            ViewBag.TeamsList = new SelectList(new Repository<Team>(Context).Get().ToList(), "Id", "Name");

        }
    }
}

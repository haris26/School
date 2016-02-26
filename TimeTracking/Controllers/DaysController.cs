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
    public class DaysController : Controller
    {
        static SchoolContext context = new SchoolContext();
        DayUnit days = new DayUnit(context);
        Repository<Person> people = new Repository<Person>(context);
        private ModelFactory factory = new ModelFactory();
        private EntityParser parser = new EntityParser();

       
        public ActionResult Index()
        {
            return View(days.Get().ToList().Select(x => factory.Create(x)).ToList());
        }

        
        public ActionResult Details(int id)
        {
            return View(factory.Create(days.Get(id)));
        }

        
        public ActionResult Create()
        {
            FillBag();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DayModel model)
        {
            if (ModelState.IsValid)
            {
                days.Insert(parser.Create(model, context));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Days/Edit/5
        public ActionResult Edit(int id)
        {
            Day day = days.Get(id);
            DayModel model = new DayModel()
            {
                Id = day.Id,
                Person = day.Person.Id,
                Date = day.Date,
                WorkTime = day.WorkTime,
                PtoTime = day.PtoTime,
                EntryStatus = day.EntryStatus
            };
            FillBag();
            return View(model);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DayModel model)
        {

            if (ModelState.IsValid)
            {

                days.Update(parser.Edit(model, context), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Days/Delete/5
        public ActionResult Delete(int id)
        {
            Day day = days.Get(id);
            return View(factory.Create(day));
        }

        // POST: Days/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            days.Delete(id);
            return RedirectToAction("Index");
        }

       void FillBag()
        {
            ViewBag.PeopleList = new SelectList(people.Get().ToList(), "Id", "FirstName");
        }
    }
}

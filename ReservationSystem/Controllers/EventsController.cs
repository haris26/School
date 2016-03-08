using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;
using ReservationSystem.Models;

namespace ReservationSystem.Controllers
{
    public class EventsController : BaseController
    {
        // GET: Events
        public ActionResult Index()
        {
            return View(new EventUnit(Context).Get().ToList().Select(x => Factory.Create(x)));
        }

        // GET: Events/Details/5
        public ActionResult Details(int id)
        {
            return View(Factory.Create(new EventUnit(Context).Get(id)));
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            FillBag();
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventModel model)
        {
            if (ModelState.IsValid)
            {
                new EventUnit(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            Event ev = new EventUnit(Context).Get(id);
            string catName = ev.Resource.ResourceCategory.CategoryName;
            FillResources(catName);
            return View(Factory.Create(new EventUnit(Context).Get(id)));
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventModel model)
        {
            if (ModelState.IsValid)
            {
                new EventUnit(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            FillResources(model.CategoryName);
            return View(model);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            Event evnt = new EventUnit(Context).Get(id);
            return View(evnt);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new EventUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.ResourceList = new SelectList(new Repository<Resource>(Context).Get().ToList().Where(x => x.Status == ReservationStatus.Available), "Id", "Name");
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
        }

        void FillResources(string catName)
        {
            ViewBag.ResourceList = new SelectList(new Repository<Resource>(Context).Get().ToList().Where(x => (x.ResourceCategory.CategoryName == catName && x.Status == ReservationStatus.Available)), "Id", "Name");
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
        }

        //GET - extended events
        public ActionResult Extensions(int id)
        {
            var ex = new ExtendedEventUnit(Context).Get().FirstOrDefault(x => x.ParentEvent.Id == id);
            EventExtendModel model = new EventExtendModel();
            model.ParentEvent = id;
            if (ex != null)
            {
                model.Id = ex.Id;
                model.Frequency = ex.Frequency;
                model.RepeatUntil = ex.RepeatUntil;
                model.RepeatingType = ex.RepeatingType;
            }

            return View(model);
        }

        public ActionResult ExtCreate(int id)   // id = Event.Id
        {
            Event exEv = new EventUnit(Context).Get(id);
            return View(new EventExtendModel()
            {
                Id = 0,
                ParentEvent = exEv.Id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExtCreate(EventExtendModel model)
        {
            if (ModelState.IsValid)
            {
                ExtendedEvent exEvent = Parser.Create(model);
                new ExtendedEventUnit(Context).Insert(exEvent);
                return RedirectToAction("Extensions/" + model.ParentEvent);
            }
            return View(model);
        }

        public ActionResult ExtEdit(int id)     // id = Event.Id
        {
            return View(Factory.Create(new ExtendedEventUnit(Context).Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExtEdit(EventExtendModel model)
        {
            if (ModelState.IsValid)
            {
                ExtendedEvent exEvent = Parser.Create(model);
                new ExtendedEventUnit(Context).Update(exEvent, exEvent.Id);
                return RedirectToAction("Extensions/" + model.ParentEvent);
            }
            return View(model);
        }

        public ActionResult ExtDelete(int id)
        {
            ViewBag.ExEventId = id;
            return View(Factory.Create(new ExtendedEventUnit(Context).Get(id)));
        }

        //POST events/extdelete/1
        [HttpPost, ActionName("ExtDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ExtDeleteConfirmed(int id)
        {
            ExtendedEventUnit exevents = new ExtendedEventUnit(Context);
            int exEvent = exevents.Get(id).ParentEvent.Id;
            exevents.Delete(id);
            return RedirectToAction("extensions/" + exEvent);
        }

    }
}
Status API Training Shop Blog About Pricing
© 2016 GitHub, Inc. Terms Privacy Security Contact Help
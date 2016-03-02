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
    public class EventsController : Controller
    {
        static SchoolContext context = new SchoolContext();
        EventUnit events = new EventUnit(context);
        Repository<Resource> resources = new Repository<Resource>(context); 
        Repository<Person> users = new Repository<Person>(context); 
        private ModelFactory factory = new ModelFactory(context);
        private EntityParser parser = new EntityParser(context);

        // GET: Events
        public ActionResult Index()
        {
            return View(events.Get().ToList().Select(x => factory.Create(x)).ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int id)
        {
            return View(factory.Create(events.Get(id)));
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
                Event evnt = new Event()
                {
                    Id = 0,
                    EventTitle = model.EventTitle,
                    EventStart = model.StartDate,
                    EventEnd = model.EndDate,
                    User = users.Get(model.Person),
                    Resource = resources.Get(model.Resource)
                };
                events.Insert(parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(factory.Create(events.Get(id)));
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventModel model)
        {
            if (ModelState.IsValid)
            {
                events.Update(parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            Event evnt = events.Get(id);
            if (evnt == null)
            {
                return HttpNotFound();
            }
            return View(evnt);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            events.Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.ResourceList = new SelectList(resources.Get().ToList(), "Id", "Name");
            ViewBag.PeopleList = new SelectList(users.Get().ToList(), "Id", "FirstName");
        }

        void FillResources(string catName)
        {
            ViewBag.ResourceList = new SelectList(resources.Get().ToList().Where(x => x.ResourceCategory.CategoryName == catName), "Id", "Name");
            ViewBag.PeopleList = new SelectList(users.Get().ToList(), "Id", "FirstName");
        } 
    }
}

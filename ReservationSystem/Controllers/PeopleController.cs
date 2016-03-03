using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;
using ReservationSystem.Models;

namespace ReservationSystem.Controllers
{
    public class PeopleController : BaseController
    {
        // GET: People
        public ActionResult Index()
        {
            return View(new Repository<Person>(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        // GET: People/Details/5

        public ActionResult Details(int id)
        {
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonModel model)

        {
            if (ModelState.IsValid)
            {
                new Repository<Person>(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }

            return View(model);
        }
        // GET: People/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonModel model)

        {
            if (ModelState.IsValid)
            {
                new Repository<Person>(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        // POST: People/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new Repository<Person>(Context).Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Engagements(int id)
        {
            PersonEngagement model = new PersonEngagement();
            model.Person = new Repository<Person>(Context).Get(id);
            model.Engagements = new EngagementUnit(Context).Get().Where(x => x.Person.Id == id).ToList().Select(x => Factory.Create(x)).ToList();
            return View(model);
        }
        public ActionResult EngCreate(int id)
        {
            FillBag();
            Person person = new Repository<Person>(Context).Get(id);
            return View(new EngagementModel()
            {
                Id = 0,
                Person = person.Id,
                PersonName = person.FirstName + " " + person.LastName
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EngCreate(EngagementModel model)
        {
            if (ModelState.IsValid)
            {
                Engagement engagement = Parser.Create(model);
                new EngagementUnit(Context).Insert(engagement);
                return RedirectToAction("Engagements/" + model.Person);
            }
            return View(model);
        }
        public ActionResult EngEdit(int id)
        {
            FillBag();
            return View(Factory.Create(new EngagementUnit(Context).Get(id)));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EngEdit(EngagementModel model)
        {
            if (ModelState.IsValid)
            {
                Engagement engagement = Parser.Create(model);
                new EngagementUnit(Context).Update(engagement, engagement.Id);
                return RedirectToAction("Engagements/" + model.Person);
            }
            return View(model);
        }
        public ActionResult EngDelete (int id)
        {
            return View(Factory.Create(new EngagementUnit(Context).Get(id)));
        }

        [HttpPost, ActionName("EngDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult EngDeleteConfirmed(int id)
        {
            new EngagementUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }
        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
            ViewBag.RolesList = new SelectList(new Repository<Role>(Context).Get().ToList(), "Id", "Name");
            ViewBag.TeamsList = new SelectList(new Repository<Team>(Context).Get().ToList(), "Id", "Name");
        }
    }
}
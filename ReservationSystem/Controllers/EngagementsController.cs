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
    public class EngagementsController : Controller
    {
        static SchoolContext context = new SchoolContext();
        EngagementUnit engagements = new EngagementUnit(context);
        Repository<Person> people = new Repository<Person>(context);
        Repository<Team> teams = new Repository<Team>(context);
        Repository<Role> roles = new Repository<Role>(context);
        private ModelFactory factory = new ModelFactory(context);
        private EntityParser parser = new EntityParser(context);

        public ActionResult Index()
        {
            return View(engagements.Get().ToList().Select(x => factory.Create(x)).ToList());
        }

        public ActionResult Details(int id)
        {
            return View(factory.Create(engagements.Get(id)));
        }

        public ActionResult Create()
        {
            FillBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EngagementModel model)
        {
            if (ModelState.IsValid)
            {
                engagements.Insert(parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
          
            FillBag();
            return View(factory.Create(engagements.Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EngagementModel model)
        {
            if (ModelState.IsValid)
            {                
                engagements.Update(parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Engagement engagement = engagements.Get(id);
            return View(factory.Create(engagement));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            engagements.Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(people.Get().ToList(), "Id", "FirstName");
            ViewBag.RolesList = new SelectList(roles.Get().ToList(), "Id", "Name");
            ViewBag.TeamsList = new SelectList(teams.Get().ToList(), "Id", "Name");
        }
    }
}

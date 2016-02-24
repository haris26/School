using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;

namespace SkillsLibrary.Controllers
{
    public class EngagementsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Engagements
        public ActionResult Index()
        {
            return View(db.Engagements.ToList());
        }

        // GET: Engagements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engagement engagement = db.Engagements.Find(id);
            if (engagement == null)
            {
                return HttpNotFound();
            }
            return View(engagement);
        }

        // GET: Engagements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Engagements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,Time")] Engagement engagement)
        {
            if (ModelState.IsValid)
            {
                db.Engagements.Add(engagement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(engagement);
        }

        // GET: Engagements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engagement engagement = db.Engagements.Find(id);
            if (engagement == null)
            {
                return HttpNotFound();
            }
            ViewBag.PeopleList = new SelectList(db.People.ToList(), "Id", "FirstName");
            ViewBag.RolesList = new SelectList(db.Roles.ToList(), "Id", "Name");
            ViewBag.TeamsList = new SelectList(db.Teams.ToList(), "Id", "Name");
            return View(engagement);
        }

        // POST: Engagements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,Time")] Engagement engagement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(engagement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(engagement);
        }

        // GET: Engagements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engagement engagement = db.Engagements.Find(id);
            if (engagement == null)
            {
                return HttpNotFound();
            }
            return View(engagement);
        }

        // POST: Engagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Engagement engagement = db.Engagements.Find(id);
            db.Engagements.Remove(engagement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

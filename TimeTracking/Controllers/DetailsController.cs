using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;
<<<<<<< HEAD

namespace TimeTracking.Controllers
{
    public class DetailsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Details
        public ActionResult Index()
        {
            return View(db.Details.ToList());
        }

        // GET: Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
=======
using TimeTracking.Models;

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
>>>>>>> 3362ff002d7c37b0137071d2af0f41ed31c55c95
        }

        // GET: Details/Create
        public ActionResult Create()
        {
<<<<<<< HEAD
=======
            FillBag();
>>>>>>> 3362ff002d7c37b0137071d2af0f41ed31c55c95
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Create([Bind(Include = "Id,WorkTime,BillTime,Description")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                db.Details.Add(detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detail);
        }

        // GET: Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.DateList = new SelectList(db.Days.ToList(), "Id", "Date");
            ViewBag.PeopleList = new SelectList(db.People.ToList(), "Id", "FirstName");
            ViewBag.TeamsList = new SelectList(db.Teams.ToList(), "Id", "Name");
            return View(detail);
=======
        public ActionResult Create(DetailModel model)
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
>>>>>>> 3362ff002d7c37b0137071d2af0f41ed31c55c95
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Edit([Bind(Include = "Id,WorkTime,BillTime,Description")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detail);
        }

        // GET: Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
=======
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
>>>>>>> 3362ff002d7c37b0137071d2af0f41ed31c55c95
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
<<<<<<< HEAD
            Detail detail = db.Details.Find(id);
            db.Details.Remove(detail);
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
=======
            new DetailUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }


        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
            ViewBag.TeamList = new SelectList(new Repository<Team>(Context).Get().ToList(), "Id", "TeamName");

>>>>>>> 3362ff002d7c37b0137071d2af0f41ed31c55c95
        }
    }
}

<<<<<<< HEAD
﻿using System;
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
    public class EngagementsController : Controller
    {
        static SchoolContext context = new SchoolContext();
        EngagementUnit engagements = new EngagementUnit(context);
        Repository<Person> people = new Repository<Person>(context);
        Repository<Team> teams = new Repository<Team>(context);
        Repository<Role> roles = new Repository<Role>(context);
        private ModelFactory factory = new ModelFactory();
        private EntityParser parser = new EntityParser();

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
            Engagement engagement = engagements.Get(id);
            EngagementModel model = new EngagementModel()
            {
                Id = engagement.Id,
                StartDate = engagement.StartDate,
                EndDate = engagement.EndDate,
                Time = engagement.Time,
                Person = engagement.Person.Id,
                Team = engagement.Team.Id,
                Role = engagement.Role.Id
            };
            FillBag();
            return View(model);
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









//using System;
=======
﻿//using System;
>>>>>>> dev
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Database;
//using TimeTracking.Models;


//namespace TimeTracking.Controllers
//{
//    public class EngagementsController : Controller
//    {
//        static SchoolContext context = new SchoolContext();
//        EngagementUnit engagements = new EngagementUnit(context);
//        Repository<Person> people = new Repository<Person>(context);
//        Repository<Team> teams = new Repository<Team>(context);
//        Repository<Role> roles = new Repository<Role>(context);
 

//        public ActionResult Index()
//        {
//            return View(engagements.Get().ToList().Select(x => factory.Create(x)).ToList());
//        }

//        public ActionResult Details(int id)
//        {
//            return View(factory.Create(engagements.Get(id)));
//        }

//        public ActionResult Create()
//        {
//            FillBag();
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(EngagementModel model)
//        {
//            if (ModelState.IsValid)
//            {
                
//                engagements.Insert(parser.Create(model));
//                return RedirectToAction("Index");
//            }
//            FillBag();
//            return View(model);
//        }

//        public ActionResult Edit(int id)
//        {
//            Engagement engagement = engagements.Get(id);
//            EngagementModel model = new EngagementModel()
//            {
//                Id = engagement.Id,
//                StartDate = engagement.StartDate,
//                EndDate = engagement.EndDate,
//                Time = engagement.Time,
//                Person = engagement.Person.Id,
//                Team = engagement.Team.Id,
//                Role = engagement.Role.Id
//            };
//            FillBag();
//            return View(model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(EngagementModel model)
//        {
            
//            if (ModelState.IsValid)
//            {
               
//                engagements.Update(parser.Create(model), model.Id);
//                return RedirectToAction("Index");
//            }
//            return View(model);
//        }

//        public ActionResult Delete(int id)
//        {
//            Engagement engagement = engagements.Get(id);
//            return View(factory.Create(engagement));
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            engagements.Delete(id);
//            return RedirectToAction("Index");
//        }

//        void FillBag()
//        {
//            ViewBag.PeopleList = new SelectList(people.Get().ToList(), "Id", "FirstName");
//            ViewBag.RolesList = new SelectList(roles.Get().ToList(), "Id", "Name");
//            ViewBag.TeamsList = new SelectList(teams.Get().ToList(), "Id", "Name");
//        }
//    }
//}









////using System;
////using System.Collections.Generic;
////using System.Data;
////using System.Data.Entity;
////using System.Linq;
////using System.Net;
////using System.Web;
////using System.Web.Mvc;
////using Database;

////namespace TimeTracking.Controllers
////{
////    public class EngagementsController : Controller
////    {
////        private SchoolContext db = new SchoolContext();

////        // GET: Engagements
////        public ActionResult Index()
////        {
////            return View(db.Engagements.ToList());
////        }

////        // GET: Engagements/Details/5
////        public ActionResult Details(int? id)
////        {
////            if (id == null)
////            {
////                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
////            }
////            Engagement engagement = db.Engagements.Find(id);
////            if (engagement == null)
////            {
////                return HttpNotFound();
////            }
////            return View(engagement);
////        }

////        // GET: Engagements/Create
////        public ActionResult Create()
////        {
////            return View();
////        }

////        // POST: Engagements/Create
////        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
////        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
////        [HttpPost]
////        [ValidateAntiForgeryToken]
////        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,Time")] Engagement engagement)
////        {
////            if (ModelState.IsValid)
////            {
////                db.Engagements.Add(engagement);
////                db.SaveChanges();
////                return RedirectToAction("Index");
////            }

////            return View(engagement);
////        }

////        // GET: Engagements/Edit/5
////        public ActionResult Edit(int? id)
////        {
////            if (id == null)
////            {
////                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
////            }
////            Engagement engagement = db.Engagements.Find(id);
////            if (engagement == null)
////            {
////                return HttpNotFound();
////            }

////            ViewBag.PeopleList = new SelectList(db.People.ToList(), "Id", "FirstName");
////            ViewBag.RolesList = new SelectList(db.Roles.ToList(), "Id", "Name");
////            ViewBag.TeamsList = new SelectList(db.Teams.ToList(), "Id", "Name");
////            return View(engagement);
////        }

////        // POST: Engagements/Edit/5
////        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
////        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
////        [HttpPost]
////        [ValidateAntiForgeryToken]
////        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,Time")] Engagement engagement)
////        {
////            if (ModelState.IsValid)
////            {
////                db.Entry(engagement).State = EntityState.Modified;
////                db.SaveChanges();
////                return RedirectToAction("Index");
////            }
////            return View(engagement);
////        }

////        // GET: Engagements/Delete/5
////        public ActionResult Delete(int? id)
////        {
////            if (id == null)
////            {
////                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
////            }
////            Engagement engagement = db.Engagements.Find(id);
////            if (engagement == null)
////            {
////                return HttpNotFound();
////            }
////            return View(engagement);
////        }

////        // POST: Engagements/Delete/5
////        [HttpPost, ActionName("Delete")]
////        [ValidateAntiForgeryToken]
////        public ActionResult DeleteConfirmed(int id)
////        {
////            Engagement engagement = db.Engagements.Find(id);
////            db.Engagements.Remove(engagement);
////            db.SaveChanges();
////            return RedirectToAction("Index");
////        }

////        protected override void Dispose(bool disposing)
////        {
////            if (disposing)
////            {
////                db.Dispose();
////            }
////            base.Dispose(disposing);
////        }
////    }
////}

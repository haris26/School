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
        public ActionResult Create()
        {

            FillBag();

            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

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
            ViewBag.TeamList = new SelectList(new Repository<Team>(Context).Get().ToList(), "Id", "TeamName");

        }
    }
}

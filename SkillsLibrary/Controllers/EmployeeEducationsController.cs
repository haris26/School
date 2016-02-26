using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;
using SkillsLibrary.Models;

namespace SkillsLibrary.Controllers
{
    public class EmployeeEducationsController : BaseController
    {
        // GET: EmployeeEducations
        public ActionResult Index()
        {
            return View(new EmployeeEducationUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        // GET: EmployeeEducations/Details/5
        public ActionResult Details(int id)
        {
            return View(Factory.Create(new EmployeeEducationUnit(Context).Get(id)));
        }

        // GET: EmployeeEducations/Create
        public ActionResult Create()
        {
            FillBag();
            return View();
        }

        // POST: EmployeeEducations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeEducationModel model)
        {
            if (ModelState.IsValid)
            {
                new EmployeeEducationUnit(Context).Insert(Parser.Create(model));
            return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: EmployeeEducations/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(Factory.Create(new EmployeeEducationUnit(Context).Get(id)));
        }

        // POST: EmployeeEducations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeEducationModel model)
        {
            if (ModelState.IsValid)
            {
                new EmployeeEducationUnit(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: EmployeeEducations/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Factory.Create(new EmployeeEducationUnit(Context).Get(id)));
        }

        // POST: EmployeeEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new EmployeeEducationUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
            ViewBag.EducationsList = new SelectList(new Repository<Education>(Context).Get().ToList(), "Id", "Name");
        }
    }
}

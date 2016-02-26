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
    public class EmployeeSkillsController : BaseController
    {

        // GET: EmployeeSkills
        public ActionResult Index()
        {
            return View(new EmployeeSkillUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        // GET: EmployeeSkills/Details/5
        public ActionResult Details(int id)
        {
            return View(Factory.Create(new EmployeeSkillUnit(Context).Get(id)));
        }

        // GET: EmployeeSkills/Create
        public ActionResult Create()
        {
            FillBag();
            return View();
        }

        // POST: EmployeeSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeSkillModel model)
        {
            if (ModelState.IsValid)
            {
                new EmployeeSkillUnit(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: EmployeeSkills/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(Factory.Create(new EmployeeSkillUnit(Context).Get(id)));
        }

        // POST: EmployeeSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeSkillModel model)
        {
            if (ModelState.IsValid)
            {
                new EmployeeSkillUnit(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: EmployeeSkills/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeSkill employeeSkill = new EmployeeSkillUnit(Context).Get(id);
            return View(Factory.Create(employeeSkill));
        }

        // POST: EmployeeSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new EmployeeSkillUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
            ViewBag.ToolsList = new SelectList(new Repository<Tool>(Context).Get().ToList(), "Id", "Name");
        }
    }
}

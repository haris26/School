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
    public class EmployeeSkillsController : Controller
    {
        private EmployeeSkillUnit employeeSkills = new EmployeeSkillUnit(new SchoolContext());
        private ToolUnit tools = new ToolUnit(new SchoolContext());
        private Repository<Person> employees = new Repository<Person>(new SchoolContext());

        // GET: EmployeeSkills
        public ActionResult Index()
        {
            return View(employeeSkills.Get().ToList());
        }

        // GET: EmployeeSkills/Details/5
        public ActionResult Details(int id)
        {
            EmployeeSkill employeeSkill = employeeSkills.Get(id);
            if (employeeSkill == null)
            {
                return HttpNotFound();
            }
            return View(employeeSkill);
        }

        // GET: EmployeeSkills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Level,Experience")] EmployeeSkill employeeSkill)
        {
            if (ModelState.IsValid)
            {
                employeeSkills.Insert(employeeSkill);
                return RedirectToAction("Index");
            }

            return View(employeeSkill);
        }

        // GET: EmployeeSkills/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeSkill employeeSkill = employeeSkills.Get(id);
            if (employeeSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.PeopleList = new SelectList(employees.Get().ToList(), "Id", "FirstName");
            ViewBag.ToolsList = new SelectList(tools.Get().ToList(), "Id", "Name");
            return View(employeeSkill);
        }

        // POST: EmployeeSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Level,Experience")] EmployeeSkill employeeSkill)
        {
            if (ModelState.IsValid)
            {
                employeeSkills.Update(employeeSkill, employeeSkill.Id);
                return RedirectToAction("Index");
            }
            return View(employeeSkill);
        }

        // GET: EmployeeSkills/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeSkill employeeSkill = employeeSkills.Get(id);
            if (employeeSkill == null)
            {
                return HttpNotFound();
            }
            return View(employeeSkill);
        }

        // POST: EmployeeSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeSkills.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

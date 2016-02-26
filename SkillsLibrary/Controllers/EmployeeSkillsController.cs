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
    public class EmployeeSkillsController : Controller
    {
        static SchoolContext context = new SchoolContext();
        EmployeeSkillUnit employeeSkills = new EmployeeSkillUnit(context);
        Repository<Tool> tools = new Repository<Tool>(context);
        Repository<Person> employees = new Repository<Person>(context);
        private ModelFactory factory = new ModelFactory();
        private EntityParser parser = new EntityParser();

        // GET: EmployeeSkills
        public ActionResult Index()
        {
            return View(employeeSkills.Get().ToList().Select(x => factory.Create(x)).ToList());
        }

        // GET: EmployeeSkills/Details/5
        public ActionResult Details(int id)
        {
            return View(factory.Create(employeeSkills.Get(id)));
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
                employeeSkills.Insert(parser.Create(model, context));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: EmployeeSkills/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(factory.Create(employeeSkills.Get(id)));
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
                employeeSkills.Update(parser.Create(model, context), model.Id);
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: EmployeeSkills/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeSkill employeeSkill = employeeSkills.Get(id);
            return View(factory.Create(employeeSkill));
        }

        // POST: EmployeeSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeSkills.Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(employees.Get().ToList(), "Id", "FirstName");
            ViewBag.ToolsList = new SelectList(tools.Get().ToList(), "Id", "Name");
        }
    }
}

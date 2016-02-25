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
    public class EmployeeEducationsController : Controller
    {
        static SchoolContext context = new SchoolContext();
        EmployeeEducationUnit employeeEducation = new EmployeeEducationUnit(context);
        Repository<Person> employees = new Repository<Person>(context);
        Repository<Education> educations = new Repository<Education>(context);
        private ModelFactory factory = new ModelFactory();
        private EntityParser parser = new EntityParser();

        // GET: EmployeeEducations
        public ActionResult Index()
        {
            return View(employeeEducation.Get().ToList().Select(x => factory.Create(x)).ToList());
        }

        // GET: EmployeeEducations/Details/5
        public ActionResult Details(int id)
        {
            return View(factory.Create(employeeEducation.Get(id)));
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
            employeeEducation.Insert(parser.Create(model, context));
            return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: EmployeeEducations/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(factory.Create(employeeEducation.Get(id)));
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
                employeeEducation.Update(parser.Create(model, context), model.Id);
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: EmployeeEducations/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeEducation employeeEdu = employeeEducation.Get(id);
            return View(factory.Create(employeeEdu));
        }

        // POST: EmployeeEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeEducation.Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(employees.Get().ToList(), "Id", "FirstName");
            ViewBag.EducationsList = new SelectList(educations.Get().ToList(), "Id", "Name");
        }
    }
}

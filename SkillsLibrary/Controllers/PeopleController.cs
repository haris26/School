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
    public class PeopleController : BaseController
    {
        // GET: People
        public ActionResult Index()
        {
            return View(new Repository<Person>(Context).Get().ToList().Select(x=>Factory.Create(x)).ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int id)
        {
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                new Repository<Person>(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                new Repository<Person>(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new Repository<Person>(Context).Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Engagements(int id)

        {
            PersonEngagement model = new PersonEngagement();
            model.Person = new Repository<Person>(Context).Get(id);
            model.Engagements = new EngagementUnit(Context)
                               .Get().Where(x => x.Person.Id == id).ToList()
                               .Select(x => Factory.Create(x)).ToList();
            return View(model);
        }

        public ActionResult EngCreate(int id)   // id = Person.Id
        {
            FillBag();
            Person person = new Repository<Person>(Context).Get(id);
            return View(new EngagementModel()
            { Id = 0, Person = person.Id, PersonName = person.FirstName + " " + person.LastName });
        }

        public ActionResult EngEdit(int id)     // id = Egagement.Id
        {
            FillBag();
            return View(Factory.Create(new EngagementUnit(Context).Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EngCreate(EngagementModel model)
        {
            if (ModelState.IsValid)
            {
                Engagement engagement = Parser.Create(model);
                new EngagementUnit(Context).Insert(engagement);
                return RedirectToAction("Engagements/" + model.Person);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EngEdit(EngagementModel model)
        {
            if (ModelState.IsValid)
            {
                Engagement engagement = Parser.Create(model);
                new EngagementUnit(Context).Update(engagement, engagement.Id);
                return RedirectToAction("Engagements/" + model.Person);
            }
            return View(model);
        }

        // GET: People/EngDelete/5
        public ActionResult EngDelete(int id)
        {
            return View(Factory.Create(new EngagementUnit(Context).Get(id)));
        }

        // POST: People/EngDelete/5
        [HttpPost, ActionName("EngDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult EngDeleteConfirmed(int id)
        {
            EngagementUnit engagements = new EngagementUnit(Context);
            int employee = engagements.Get(id).Person.Id;
            engagements.Delete(id);
            return RedirectToAction("engagements/" + employee);
        }

        public ActionResult EmployeeSkills(int id)
        {
            PersonSkills model = new PersonSkills();
            model.Person = new Repository<Person>(Context).Get(id);
            model.Skills = new EmployeeSkillUnit(Context)
                              .Get().Where(x => x.Employee.Id == id).ToList()
                              .Select(x => Factory.Create(x)).ToList();
            return View(model);
        }

        public ActionResult SkillCreate(int id)  //Person id
        {
            FillBag();
            Person person = new Repository<Person>(Context).Get(id);
            return View(new EmployeeSkillModel()
            {
                 Employee=person.Id,
                 EmployeeName=person.FirstName +" "+ person.LastName
            }
            );
        }

        public ActionResult SkillEdit(int id)
        {
            FillBag();
            return View(Factory.Create(new EmployeeSkillUnit(Context).Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SkillCreate(EmployeeSkillModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeSkill skill = Parser.Create(model);
                new EmployeeSkillUnit(Context).Insert(skill);
                return RedirectToAction("EmployeeSkills/" + model.Employee);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SkillEdit(EmployeeSkillModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeSkill skill = Parser.Create(model);
                new EmployeeSkillUnit(Context).Update(skill, skill.Id);
                return RedirectToAction("EmployeeSkills/" + model.Employee);
            }
            return View(model);
        }

        // GET: People/SkillDelete/5
        public ActionResult SkillDelete(int id)
        {
            return View(Factory.Create(new EmployeeSkillUnit(Context).Get(id)));
        }

        // POST: People/SkillDelete/5
        [HttpPost, ActionName("SkillDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult SkillDeleteConfirmed(int id)
        {
            EmployeeSkillUnit skills = new EmployeeSkillUnit(Context);
            int employee = skills.Get(id).Employee.Id;
            skills.Delete(id);
            return RedirectToAction("EmployeeSkills/" + employee);
        }



        public ActionResult EmployeeEducation(int id)         //Person id
        {
            PersonEducation model = new PersonEducation();
            model.Person = new Repository<Person>(Context).Get(id);
            model.Educations = new EmployeeEducationUnit(Context)
                              .Get().Where(x => x.Employee.Id == id).ToList()
                              .Select(x => Factory.Create(x)).ToList();
            return View(model);
        }

        public ActionResult EduCreate(int id)  //Person id
        {
            FillBag();
            Person person = new Repository<Person>(Context).Get(id);
            return View(new EmployeeEducationModel()
            {
                Employee = person.Id,
                EmployeeName = person.FirstName + " " + person.LastName
            }
            );
        }

        public ActionResult EduEdit(int id)
        {
            FillBag();
            return View(Factory.Create(new EmployeeEducationUnit(Context).Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EduCreate(EmployeeEducationModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeEducation education = Parser.Create(model);
                new EmployeeEducationUnit(Context).Insert(education);
                return RedirectToAction("EmployeeEducation/" + model.Employee);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EduEdit(EmployeeEducationModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeEducation education = Parser.Create(model);
                new EmployeeEducationUnit(Context).Update(education, education.Id);
                return RedirectToAction("EmployeeEducation/" + model.Employee);
            }
            return View(model);
        }

        // GET: People/SkillDelete/5
        public ActionResult EduDelete(int id)
        {
            return View(Factory.Create(new EmployeeEducationUnit(Context).Get(id)));
        }

        // POST: People/SkillDelete/5
        [HttpPost, ActionName("EduDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult EduDeleteConfirmed(int id)
        {
            EmployeeEducationUnit education = new EmployeeEducationUnit(Context);
            int employee = education.Get(id).Employee.Id;
            education.Delete(id);
            return RedirectToAction("EmployeeEducation/" + employee);
        }

        void FillBag()
        {
            ViewBag.RolesList = new SelectList(new Repository<Role>(Context).Get().ToList(), "Id", "Name");
            ViewBag.TeamsList = new SelectList(new Repository<Team>(Context).Get().ToList(), "Id", "Name");
            ViewBag.ToolsList = new SelectList(new Repository<Tool>(Context).Get().ToList(), "Id", "Name");
            ViewBag.EducationList = new SelectList(new Repository<Education>(Context).Get().ToList(), "Id", "Name");
        }
    }
}

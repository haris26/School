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
    public class EducationsController : Controller
    {
        private Repository<Education> educations = new Repository<Education>(new SchoolContext());

        // GET: Educations
        public ActionResult Index()
        {
            return View(educations.Get().ToList());
        }

        // GET: Educations/Details/5
        public ActionResult Details(int id)
        {
            Education education = educations.Get(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // GET: Educations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type")] Education education)
        {
            if (ModelState.IsValid)
            {
                educations.Insert(education);
                return RedirectToAction("Index");
            }

            return View(education);
        }

        // GET: Educations/Edit/5
        public ActionResult Edit(int id)
        {
            Education education = educations.Get(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type")] Education education)
        {
            if (ModelState.IsValid)
            {
                educations.Update(education, education.Id);
                return RedirectToAction("Index");
            }
            return View(education);
        }

        // GET: Educations/Delete/5
        public ActionResult Delete(int id)
        {
            Education education = educations.Get(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            educations.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

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
    public class SkillCategoriesController : Controller
    {
        private Repository<SkillCategory> skillCategories = new Repository<SkillCategory>(new SchoolContext());

        // GET: SkillCategories
        public ActionResult Index()
        {
            return View(skillCategories.Get().ToList());
        }

        // GET: SkillCategories/Details/5
        public ActionResult Details(int id)
        {
            SkillCategory skillCategory = skillCategories.Get(id);
            if (skillCategory == null)
            {
                return HttpNotFound();
            }
            return View(skillCategory);
        }

        // GET: SkillCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkillCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] SkillCategory skillCategory)
        {
            if (ModelState.IsValid)
            {
                skillCategories.Insert(skillCategory);
                return RedirectToAction("Index");
            }

            return View(skillCategory);
        }

        // GET: SkillCategories/Edit/5
        public ActionResult Edit(int id)
        {
            SkillCategory skillCategory = skillCategories.Get(id);
            if (skillCategory == null)
            {
                return HttpNotFound();
            }
            return View(skillCategory);
        }

        // POST: SkillCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] SkillCategory skillCategory)
        {
            if (ModelState.IsValid)
            {
                skillCategories.Update(skillCategory, skillCategory.Id);
                return RedirectToAction("Index");
            }
            return View(skillCategory);
        }

        // GET: SkillCategories/Delete/5
        public ActionResult Delete(int id)
        {
            SkillCategory skillCategory = skillCategories.Get(id);
            if (skillCategory == null)
            {
                return HttpNotFound();
            }
            return View(skillCategory);
        }

        // POST: SkillCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            skillCategories.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

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
    public class ProjectSkillsController : BaseController
    {
        // GET: ProjectSkills
        public ActionResult Index()
        {
            return View(new ProjectSkillUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        // GET: ProjectSkills/Details/5
        public ActionResult Details(int id)
        {
            return View(Factory.Create(new ProjectSkillUnit(Context).Get(id)));
        }

        // GET: ProjectSkills/Create
        public ActionResult Create()
        {
            FillBag();
            return View();
        }

        // POST: ProjectSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectSkillModel model)
        {
            if (ModelState.IsValid)
            {
                new ProjectSkillUnit(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: ProjectSkills/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(Factory.Create(new ProjectSkillUnit(Context).Get(id)));
        }

        // POST: ProjectSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectSkillModel model)
        {
            if (ModelState.IsValid)
            {
                new ProjectSkillUnit(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: ProjectSkills/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Factory.Create(new ProjectSkillUnit(Context).Get(id)));
        }

        // POST: ProjectSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new ProjectSkillUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.ProjectsList = new SelectList(new Repository<Team>(Context).Get().ToList(), "Id", "Description");
            ViewBag.ToolsList = new SelectList(new Repository<Tool>(Context).Get().ToList(), "Id", "Name");
        }
    }
}

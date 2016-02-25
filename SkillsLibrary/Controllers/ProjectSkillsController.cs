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
    public class ProjectSkillsController : Controller
    {
        static SchoolContext context = new SchoolContext();
        ProjectSkillUnit projectSkills = new ProjectSkillUnit(context);
        Repository<Team> teams = new Repository<Team>(context);
        Repository<Tool> tools = new Repository<Tool>(context);
        private ModelFactory factory = new ModelFactory();
        private EntityParser parser = new EntityParser();

        // GET: ProjectSkills
        public ActionResult Index()
        {
            return View(projectSkills.Get().ToList().Select(x => factory.Create(x)).ToList());
        }

        // GET: ProjectSkills/Details/5
        public ActionResult Details(int id)
        {
            return View(factory.Create(projectSkills.Get(id)));
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
                projectSkills.Insert(parser.Create(model, context));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: ProjectSkills/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(factory.Create(projectSkills.Get(id)));
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
                projectSkills.Update(parser.Create(model, context), model.Id);
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: ProjectSkills/Delete/5
        public ActionResult Delete(int id)
        {
            return View(factory.Create(projectSkills.Get(id)));
        }

        // POST: ProjectSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            projectSkills.Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.ProjectsList = new SelectList(teams.Get().ToList(), "Id", "Description");
            ViewBag.ToolsList = new SelectList(tools.Get().ToList(), "Id", "Name");
        }
    }
}

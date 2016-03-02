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
    public class TeamsController : BaseController
    {
        private Repository<Team> teams = new Repository<Team>(new SchoolContext());

        public ActionResult Index()
        {
            return View(teams.Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        public ActionResult Details(int id)
        {
            return View(Factory.Create(teams.Get(id)));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                teams.Insert(team);
                return RedirectToAction("Index");
            }
            return View(team);
        }

        public ActionResult Edit(int id)
        {
            return View(teams.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                teams.Update(team, team.Id);
                return RedirectToAction("Index");
            }
            return View(team);
        }

        public ActionResult Delete(int id)
        {
            return View(teams.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teams.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult ProjectSkills(int id)
        {
            ProjectSkills model = new ProjectSkills();
            model.Team = new Repository<Team>(Context).Get(id);
            model.Skills = new ProjectSkillUnit(Context)
                           .Get().Where(x => x.Team.Id == id).ToList()
                           .Select(x => Factory.Create(x)).ToList();
            return View(model);
        }


        public ActionResult SkillCreate(int id)   // id = Team.Id
        {
            FillBag();
            Team team = new Repository<Team>(Context).Get(id);
            return View(new ProjectSkillModel()
            {
                Project = team.Id,
                ProjectName = team.Description,
                TeamName = team.Name
            });
        }

        public ActionResult SkillEdit(int id)     // id = ProjectSkill.Id
        {
            FillBag();
            return View(Factory.Create(new ProjectSkillUnit(Context).Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SkillCreate(ProjectSkillModel model)
        {
            if (ModelState.IsValid)
            {
                ProjectSkill projSkill = Parser.Create(model);
                new ProjectSkillUnit(Context).Insert(projSkill);
                return RedirectToAction("ProjectSkills/" + model.Project);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SkillEdit(ProjectSkillModel model)
        {
            if (ModelState.IsValid)
            {
                ProjectSkill projSkill = Parser.Create(model);
                new ProjectSkillUnit(Context).Update(projSkill, projSkill.Id);
                return RedirectToAction("ProjectSkills/" + model.Project);
            }
            return View(model);
        }

        // GET: People/SkillDelete/5
        public ActionResult SkillDelete(int id)
        {
            return View(Factory.Create(new ProjectSkillUnit(Context).Get(id)));
        }

        // POST: People/SkillDelete/5
        [HttpPost, ActionName("SkillDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult SkillDeleteConfirmed(int id)
        {
            ProjectSkillUnit projSkills = new ProjectSkillUnit(Context);
            int project = projSkills.Get(id).Team.Id;
            projSkills.Delete(id);
            return RedirectToAction("ProjectSkills/" + project);
        }



        void FillBag()
        {
            ViewBag.ToolsList = new SelectList(new Repository<Tool>(Context).Get().ToList(), "Id", "Name");
        }
    }
}

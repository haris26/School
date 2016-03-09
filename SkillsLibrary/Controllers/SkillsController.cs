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
    public class SkillsController : BaseController
    {

        private SchoolContext db = new SchoolContext();

        // GET: Skills
        public ActionResult Index()
        {
            return View(new Repository<SkillCategory>(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        // GET: Skills/AddCategory
        public ActionResult AddCategory()
        {
            return View();
        }

        // POST: Skills/AddCategory
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(SkillCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                new Repository<SkillCategory>(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Skills/AddSkill
        public ActionResult AddSkill()
        {
            FillBag();
            return View();
        }

        // POST: Skills/AddSkill
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSkill(ToolModel model)
        {
            if (ModelState.IsValid)
            {
                new ToolUnit(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Skills/EditCategory/5
        public ActionResult EditCategory(int id)   //category id
        {
            return View(Factory.Create(new Repository<SkillCategory>(Context).Get(id)));
        }

        // POST: Skills/EditCategory/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(SkillCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                new Repository<SkillCategory>(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Skills/EditSkill/5
        public ActionResult EditSkill(int id)
        {
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // POST: Skills/EditSkill/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSkill(Tool tool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tool);
        }

        // GET: Skills/DeleteCategory/5
        public ActionResult DeleteCategory(int id)
        {
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // POST: Skills/DeleteCategory/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategoryConfirmed(int id)
        {
            Tool tool = db.Tools.Find(id);
            db.Tools.Remove(tool);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Skills/DeleteSkill/5
        public ActionResult DeleteSkill(int id)
        {
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // POST: Skills/DeleteSkill/5
        [HttpPost, ActionName("DeleteSkill")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSkillConfirmed(int id)
        {
            Tool tool = db.Tools.Find(id);
            db.Tools.Remove(tool);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.CategoriesList = new SelectList(new Repository<SkillCategory>(Context).Get().ToList(), "Id", "Name");
        }
    }
}

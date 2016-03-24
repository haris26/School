﻿using System;
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
                if (new Repository<SkillCategory>(Context).Get().ToList().Select(x => x.Name).ToList().Contains(model.Name))
                {
                    ViewBag.SameNameError = "A category with the entered name already exists.";
                    return View(model);
                }
                else
                {
                    new Repository<SkillCategory>(Context).Insert(Parser.Create(model));
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        // GET: Skills/AddSkill/3
        public ActionResult AddSkill(int? id)
        {
            if(id != null)
            {
                FillBag(id.Value);
            }
            else
            {
                FillBag();
            }
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
                if (new Repository<Tool>(Context).Get().ToList().Select(x => x.Name).ToList().Contains(model.Name))
                {
                    ViewBag.SameNameError = "A skill with the entered name already exists.";
                    FillBag();
                    return View(model);
                }
                else
                {
                    new ToolUnit(Context).Insert(Parser.Create(model));
                    return RedirectToAction("Index");
                }
            }

            FillBag();
            return View(model);
        }

        // GET: Skills/EditCategory/5
        public ActionResult EditCategory(int id, int? errorFlag)   //category id
        {
            if (errorFlag != null)
            {
                if (errorFlag.Value == 1)
                    ViewBag.CannotDeleteError = "The selected category cannot be deleted.";
                else
                    ViewBag.CannotDeleteError = "The selected skill cannot be deleted.";
            }

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
        public ActionResult EditSkill(int id)    //skill id
        {
            FillBag();
            return View(Factory.Create(new Repository<Tool>(Context).Get(id)));
        }

        // POST: Skills/EditSkill/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSkill(ToolModel model)
        {
            if (ModelState.IsValid)
            {
                new ToolUnit(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("EditCategory/"+model.Category);
            }
            return View(model);
        }

        // GET: Skills/DeleteCategory/5
        public ActionResult DeleteCategory(int id)
        {
            SkillCategory selectedCategory = new Repository<SkillCategory>(Context).Get(id);
            if (selectedCategory.Tools.Count() == 0)
            {
                return View(Factory.Create(selectedCategory));
            }
            else
            {
                return RedirectToAction("EditCategory/" + id + "/1");
            }
        }

        // POST: Skills/DeleteCategory/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategoryConfirmed(int id)
        {
            new Repository<SkillCategory>(Context).Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Skills/DeleteSkill/5
        public ActionResult DeleteSkill(int id)
        {
            Tool selectedTool = new Repository<Tool>(Context).Get(id);
            if (selectedTool.EmployeeSkills.Count() == 0)
            {
                return View(Factory.Create(selectedTool));
            }
            else
            {
                return RedirectToAction("EditCategory/" + selectedTool.Category.Id + "/2");
            }
        }

        // POST: Skills/DeleteSkill/5
        [HttpPost, ActionName("DeleteSkill")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSkillConfirmed(int id)
        {
            ToolUnit tools = new ToolUnit(Context);
            int category = tools.Get(id).Category.Id;
            tools.Delete(id);
            return RedirectToAction("EditCategory/"+category);
        }

        void FillBag()
        {
            ViewBag.CategoriesList = new SelectList(new Repository<SkillCategory>(Context).Get().ToList(), "Id", "Name");
        }

        void FillBag(int selected)
        {
            ViewBag.CategoriesList = new SelectList(new Repository<SkillCategory>(Context).Get().ToList(), "Id", "Name", selected);
        }
    }
}
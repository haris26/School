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
    public class ToolsController : BaseController
    {
        // GET: Tools
        public ActionResult Index()
        {
            return View(new ToolUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        // GET: Tools/Details/5
        public ActionResult Details(int id)
        {
            return View(Factory.Create(new ToolUnit(Context).Get(id)));
        }

        // GET: Tools/Create
        public ActionResult Create()
        {
            FillBag();
            return View();
        }

        // POST: Tools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToolModel model)
        {
            if (ModelState.IsValid)
            {
                new ToolUnit(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Tools/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(Factory.Create(new ToolUnit(Context).Get(id)));
        }

        // POST: Tools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ToolModel model)
        {
            if (ModelState.IsValid)
            {
                new ToolUnit(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Tools/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Factory.Create(new ToolUnit(Context).Get(id)));
        }

        // POST: Tools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new ToolUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.CategoriesList = new SelectList(new Repository<SkillCategory>(Context).Get().ToList(), "Id", "Name");
        }
    }
}

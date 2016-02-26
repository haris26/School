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
    public class ToolsController : Controller
    {
        static SchoolContext context = new SchoolContext();
        ToolUnit tools = new ToolUnit(context);
        Repository<SkillCategory> categories = new Repository<SkillCategory>(context);
        private ModelFactory factory = new ModelFactory();
        private EntityParser parser = new EntityParser();

        // GET: Tools
        public ActionResult Index()
        {
            return View(tools.Get().ToList().Select(x => factory.Create(x)).ToList());
        }

        // GET: Tools/Details/5
        public ActionResult Details(int id)
        {
            return View(factory.Create(tools.Get(id)));
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
                tools.Insert(parser.Create(model, context));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Tools/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(factory.Create(tools.Get(id)));
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
                tools.Update(parser.Create(model, context), model.Id);
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Tools/Delete/5
        public ActionResult Delete(int id)
        {
            return View(factory.Create(tools.Get(id)));
        }

        // POST: Tools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tools.Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.CategoriesList = new SelectList(categories.Get().ToList(), "Id", "Name");
        }
    }
}

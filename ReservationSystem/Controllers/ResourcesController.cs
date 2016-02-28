using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;
using ReservationSystem.Models;

namespace ReservationSystem.Controllers
{
    public class ResourcesController : Controller
    {
        static SchoolContext context = new SchoolContext();
        ResourceUnit resources = new ResourceUnit(context);
        private Repository<ResourceCategory> resourceCat = new Repository<ResourceCategory>(context);
        private ModelFactory factory = new ModelFactory(context);
        private EntityParser parser = new EntityParser(context);

        // GET: Resources
        public ActionResult Index()
        {
            return View(resources.Get().ToList().Select(x => factory.Create(x)).ToList());
        }

        // GET: Resources/Details/5
        public ActionResult Details(int id)
        {
            return View(factory.Create(resources.Get(id)));
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            FillBag();
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResourceModel model)
        {
            if (ModelState.IsValid)
            {
                resources.Insert(parser.Create(model, context));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(factory.Create(resources.Get(id)));
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ResourceModel model)
        {
            if (ModelState.IsValid)
            {
                resources.Update(parser.Create(model, context), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int id)
        {
            Resource resource = resources.Get(id);
            return View(factory.Create(resource));
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resources.Delete(id);
            return RedirectToAction("Index");
        }
        void FillBag()
        {
            ViewBag.ResourceCatList = new SelectList(resourceCat.Get().ToList(), "Id", "CategoryName");
        }
    }
}

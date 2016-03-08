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
    public class ResourceCategoriesController : BaseController
    {
        static SchoolContext context = new SchoolContext();
        private Repository<ResourceCategory> resourceCat = new Repository<ResourceCategory>(context);
        private ModelFactory factory = new ModelFactory(context);
        private EntityParser parser = new EntityParser(context);

        // GET: ResourceCategories
        public ActionResult Index()
        {
            return View(resourceCat.Get().ToList().Select(x => factory.Create(x)).ToList());
        }

        // GET: ResourceCategories/Details/5
        public ActionResult Details(int id)
        {
            return View(factory.Create(resourceCat.Get(id)));
        }

        // GET: ResourceCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResourceCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResourceCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                resourceCat.Insert(parser.Create(model));
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: ResourceCategories/Edit/5
        public ActionResult Edit(int id)
        {
           return View(factory.Create(resourceCat.Get(id)));
        }

        // POST: ResourceCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ResourceCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                resourceCat.Update(parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: ResourceCategories/Delete/5
        public ActionResult Delete(int id)
        {
            ResourceCategory resCat = new Repository<ResourceCategory>(context).Get(id);
            return View(factory.Create(resCat));
        }

        // POST: ResourceCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resourceCat.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

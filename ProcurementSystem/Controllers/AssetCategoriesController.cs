using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;

namespace ProcurementSystem.Controllers
{
    public class AssetCategoriesController : BaseController
    {
        private Repository<AssetCategory> assetCategories = new Repository<AssetCategory>(new SchoolContext());
       

        // GET: AssetCategories
        public ActionResult Index()
        {
            return View(assetCategories.Get().ToList());
        }

        // GET: AssetCategories/Details/5
        public ActionResult Details(int id)
        {
            
            AssetCategory assetCategory = assetCategories.Get(id);
            if (assetCategory == null)
            {
                return HttpNotFound();
            }
            return View(assetCategory);
        }

        // GET: AssetCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName")] AssetCategory assetCategory)
        {
            if (ModelState.IsValid)
            {
                assetCategories.Insert(assetCategory);
                
                return RedirectToAction("Index");
            }

            return View(assetCategory);
        }

        // GET: AssetCategories/Edit/5
        public ActionResult Edit(int id)
        {
            AssetCategory assetCategory = assetCategories.Get(id);
            if (assetCategory == null)
            {
                return HttpNotFound();
            }
            return View(assetCategory);
        }

        // POST: AssetCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName")] AssetCategory assetCategory)
        {
            if (ModelState.IsValid)
            {
                assetCategories.Update(assetCategory, assetCategory.Id);
                return RedirectToAction("Index");
            }
            return View(assetCategory);
        }

        // GET: AssetCategories/Delete/5
        public ActionResult Delete(int id)
        {
            AssetCategory assetCategory = assetCategories.Get(id);
            if (assetCategory == null)
            {
                return HttpNotFound();
            }
            return View(assetCategory);
        }

        // POST: AssetCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            assetCategories.Delete(id);
            
            return RedirectToAction("Index");
        }

        
    }
}

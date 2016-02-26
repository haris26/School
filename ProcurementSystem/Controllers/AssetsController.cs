using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;
using ProcurementSystem.Models;

namespace ProcurementSystem.Models
{
    public class AssetsController : Controller
    {
        static SchoolContext context = new SchoolContext();
        AssetsUnit assets = new AssetsUnit(context);
        private Repository<AssetCategory> assetCategories = new Repository<AssetCategory>(context);
        private Repository<Person> people = new Repository<Person>(context);
        private ModelFactory factory = new ModelFactory();
        private EntityParser parser = new EntityParser();

        // GET: Assets
        public ActionResult Index()
        {
            return View(assets.Get().ToList().Select(x => factory.Create(x)).ToList());

            
        }

        // GET: Assets/Details/5
        public ActionResult Details(int id)
        {

            return View(factory.Create(assets.Get(id)));
        }

        // GET: Assets/Create
        public ActionResult Create( )
        {
            FillBag();
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetsModel model)
        {
            if (ModelState.IsValid)
            {
                assets.Insert(parser.Create(model, context));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Assets/Edit/5
        public ActionResult Edit(int id)
        {
            //var assetCol = assetCategories.Get().ToList();
            Asset asset = assets.Get(id);
            AssetsModel model = new AssetsModel()
            {
                Id = asset.Id,
                Name = asset.Name,
                Model = asset.Model,
                User = asset.User.Id,
                UserName = asset.User.FirstName,
                Vendor = asset.Vendor,
                Category = asset.AssetCategory.Id,
                DateOfTrade = asset.DateOfTrade,
                SerialNumber = asset.SerialNumber,
                Status = asset.Status,
                Price = asset.Price
            };
            FillBag();
            return View(model);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AssetsModel model)
        {
            if (ModelState.IsValid)
            {
                assets.Update(parser.Create(model, context), model.Id);
                
                return RedirectToAction("Index"); 
            }
            FillBag();
            return View(model);
        }

        // GET: Assets/Delete/5
        public ActionResult Delete(int id)
        {
            Asset asset = assets.Get(id);
            return View(factory.Create(asset));
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            assets.Delete(id);
           
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(people.Get().ToList(), "Id", "FirstName");
            ViewBag.CategoryList = new SelectList(assetCategories.Get().ToList(), "Id", "CategoryName");
            
        }
    }
}

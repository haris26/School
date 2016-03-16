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

namespace ProcurementSystem.Controllers
{
    public class AssetsController : BaseController
    {
        //komentar opalio 
     

       
        // GET: Assets
        public ActionResult Index()
        {
            return View(new AssetsUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());

            
        }

        // GET: Assets/Details/5
        public ActionResult Details(int id)
        {

            return View(Factory.Create(new AssetsUnit(Context).Get(id)));
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
                new AssetsUnit(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Assets/Edit/5
        public ActionResult Edit(int id)
        {
            //var assetCol = assetCategories.Get().ToList();
            Asset asset = new AssetsUnit(Context).Get(id);
            AssetsModel model = new AssetsModel()
            {
                Id = asset.Id,
                Name = asset.Name,
                Model = asset.Model,
                User = asset.User.Id,
                UserName = asset.User.FirstName,
                Vendor = asset.Vendor,

                Status = asset.Status.ToString(),
                Category = asset.AssetCategory.Id,
                CategoryName = asset.AssetCategory.CategoryName,
                DateOfTrade = asset.DateOfTrade,
                SerialNumber = asset.SerialNumber,
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
                new AssetsUnit(Context).Update(Parser.Create(model), model.Id);
                
                return RedirectToAction("Index"); 
            }
            FillBag();
            return View(model);
        }

        // GET: Assets/Delete/5
        public ActionResult Delete(int id)
        {
            Asset asset = new AssetsUnit(Context).Get(id);
            return View(Factory.Create(asset));
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            new AssetsUnit(Context).Delete(id);
           
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
            ViewBag.CategoryList = new SelectList(new Repository<AssetCategory>(Context).Get().ToList(), "Id", "CategoryName");
            
        }

    }
}

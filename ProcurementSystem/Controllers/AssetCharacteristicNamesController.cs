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
    public class AssetCharacteristicNamesController : BaseController
    {
        static SchoolContext context = new SchoolContext();
        AssetCharNamesUnit characteristicNames = new AssetCharNamesUnit(context);
        Repository<AssetCategory> assetCategory = new Repository<AssetCategory>(context);
      



        public ActionResult Index()
        {
            return View(characteristicNames.Get().ToList().Select(x => Factory.Create(x)));
        }


        public ActionResult Details(int id)
        {

            return View(Factory.Create(characteristicNames.Get(id)));
        }


        public ActionResult Create()
        {
            FillBag();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacteristicNameModel model)
        {
            if (ModelState.IsValid)
            {
                characteristicNames.Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            FillBag();
            return View(Factory.Create(characteristicNames.Get(id)));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CharacteristicNameModel model)
        {
            if (ModelState.IsValid)
            {
                characteristicNames.Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public ActionResult Delete(int id)
        {
           AssetCharacteristicNames characteristicName = characteristicNames.Get(id);
            return View(Factory.Create(characteristicName));
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            characteristicNames.Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.AssetCategoryList = new SelectList(assetCategory.Get().ToList(), "Id", "CategoryName");

        }
    }
}

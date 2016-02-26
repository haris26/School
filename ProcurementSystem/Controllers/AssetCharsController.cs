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
    public class AssetCharsController : Controller
    {
        private Repository<Characteristic> characteristics = new Repository<Characteristic>(new SchoolContext());

        public ActionResult Index()
        {
            return View(characteristics.Get().ToList());
        }


        public ActionResult Details(int id)
        {

            Characteristic charact = characteristics.Get(id);
            if (charact == null)
            {
                return HttpNotFound();
            }
            return View(charact);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Value")] Characteristic characteristic)
        {
            if (ModelState.IsValid)
            {
                characteristics.Insert(characteristic);

                return RedirectToAction("Index");
            }

            return View(characteristic);
        }


        public ActionResult Edit(int id)
        {
            Characteristic charact = characteristics.Get(id);
            if (charact == null)
            {
                return HttpNotFound();
            }
            return View(charact);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Value")] Characteristic characteristic)
        {
            if (ModelState.IsValid)
            {
                characteristics.Update(characteristic, characteristic.Id);
                return RedirectToAction("Index");
            }
            return View(characteristic);
        }

        public ActionResult Delete(int id)
        {

            var charact = characteristics.Get(id);
            if (charact == null)
            {
                return HttpNotFound();
            }
            return View(charact);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            characteristics.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

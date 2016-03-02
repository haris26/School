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
    public class ResourcesController : BaseController
    {
        // GET: Resources
        public ActionResult Index()
        {
            return View(new ResourceUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        // GET: Resources/Details/5
        public ActionResult Details(int id)
        {
            return View(Factory.Create(new ResourceUnit(Context).Get(id)));
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
                new ResourceUnit(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(Factory.Create(new ResourceUnit(Context).Get(id)));
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
                new ResourceUnit(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Factory.Create(new ResourceUnit(Context).Get(id)));
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new ResourceUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Characterstics(int id)
        {
            ResourceCharactersticModel model = new ResourceCharactersticModel();
            model.Resource = new ResourceUnit(Context).Get(id);
            model.Characteristics = new Repository<Characteristic>(Context).Get().Where(x => x.Resource.Id == id).ToList()
                .Select(x => Factory.Create(x)).ToList();
            return View(model);
        }
        public ActionResult CharEdit(int id)
        {
            return View(Factory.Create(new Repository<Characteristic>(Context).Get(id)));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CharEdit(CharacteristicModel model)
        {
            if (ModelState.IsValid)
            {
                Characteristic charac = Parser.Create(model);
                new Repository<Characteristic>(Context).Update(charac, charac.Id);
                return RedirectToAction("Characterstics/" + model.Resource);
            }
            return View(model);
        }
        void FillBag()
        {
            ViewBag.ResourceCatList = new SelectList(new Repository<ResourceCategory>(Context).Get().ToList(), "Id", "CategoryName");
        }
    }
}

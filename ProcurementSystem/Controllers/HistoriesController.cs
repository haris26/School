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
    public class HistoriesController : BaseController
    {
       

        static SchoolContext context = new SchoolContext();
        HistoryUnit histories = new HistoryUnit(context);
        Repository<Asset> assets = new Repository<Asset>(context);
        Repository<Person> people = new Repository<Person>(context);


        public ActionResult Index()
        {
            return View(histories.Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        // GET: Histories1/Details/5
        public ActionResult Details(int id)
        {
            return View(Factory.Create(histories.Get(id)));
        }

        public ActionResult Create()
        {
            FillBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HistoryModel historymodel)
        {
            if (ModelState.IsValid)
            {

                histories.Insert(Parser.Create(historymodel));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(historymodel);
        }

        public ActionResult Edit(int id)
        {
            History history = histories.Get(id);
           HistoryModel historymodel = new HistoryModel()
            {
                Id = history.Id,
                EventBegin = history.EventBegin,
                EventEnd=history.EventBegin,
                Description=history.Description,
                Person = history.Person.Id,
            
               Asset= history.Asset.Id
            };
            FillBag();
            return View(historymodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HistoryModel historymodel)
        {
            if (ModelState.IsValid)
            {

                histories.Update(Parser.Create(historymodel), historymodel.Id);
                return RedirectToAction("Index");
            }
            return View(historymodel);
        }

        public ActionResult Delete(int id)
        {
            History history = histories.Get(id);
            return View(Factory.Create(history));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            histories.Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(people.Get().ToList(), "Id", "FirstName");
            ViewBag.RolesList = new SelectList(assets.Get().ToList(), "Id", "Name");
           
        }
    }
}
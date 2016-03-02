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
    public class RequestsController : BaseController
    {

        static SchoolContext context = new SchoolContext();
        RequestUnit requests = new RequestUnit(context);
        Repository<Person> people = new Repository<Person>(context);
        Repository<Asset> assets = new Repository<Asset>(context);
       


        // GET: Requests
        public ActionResult Index()
        {
           
           
            return View(requests.Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

      //  GET: Requests/Details/5
        public ActionResult Details(int id)
        {
           
           
            return View(Factory.Create(requests.Get(id)));
        }

      //  GET: Requests/Create
        public ActionResult Create()
        {
            FillBag();
            return View();
        }

        //  POST: Requests/Create
        //  To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //   more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequestModel model)
        {
            if (ModelState.IsValid)
            {
                requests.Insert(Parser.Create(model));
               
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

   //     GET: Requests/Edit/5
        public ActionResult Edit(int id)
        {
            
            Request request = requests.Get(id);
            RequestModel model = new RequestModel()
            {
                Id = request.Id,
                requestType = request.requestType,
                RequestDescription = request.RequestDescription,
                RequestMessage = request.RequestMessage,
                RequestDate = request.RequestDate,
                Asset = request.Asset.Id,  
                Person = request.User.Id,
              
            };
            FillBag();
            return View(model);
        }

      //  POST: Requests/Edit/5
      //   To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      //   more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( RequestModel model)
        {
            if (ModelState.IsValid)
            {
                requests.Update(Parser.Create(model), model.Id);
                
                return RedirectToAction("Index");
            }
            return View(model);
        }


    //    GET: Requests/Delete/5
        public ActionResult Delete(int id)
        {
           
            Request request = requests.Get(id);
            return View(Factory.Create(request));
        }



    //    POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            requests.Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(people.Get().ToList(), "Id", "FirstName");
            ViewBag.AssetsList = new SelectList(assets.Get().ToList(), "Id", "Model");
        }
    }
}

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
    public class RequestsController : Controller
    {
        private Repository<Request> requests = new Repository<Request>(new SchoolContext());

        // GET: Requests
        public ActionResult Index()
        {
            IList<RequestModel> requestList = new List<RequestModel>();
            var requestCol = requests.Get().ToList();
            foreach(var request in requestCol)
            {
                RequestModel requestModel = new RequestModel()
                {
                    Id = request.Id,
                    requestType = request.requestType,
                    RequestDescription = request.RequestDescription,
                    RequestMessage = request.RequestMessage,
                    RequestDate = request.RequestDate,
                    Asset = request.Asset,
                    User = request.User
                };
            }
            return View(requestCol);
        }

      //  GET: Requests/Details/5
        public ActionResult Details(int id)
        {
          
            Request request = requests.Get(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

      //  GET: Requests/Create
        public ActionResult Create()
        {
            return View();
        }

      //  POST: Requests/Create
      //  To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      //   more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,requestType,RequestMessage,RequestDescription,RequestDate,Status")] Request request)
        {
            if (ModelState.IsValid)
            {
                requests.Insert(request);
               
                return RedirectToAction("Index");
            }

            return View(request);
        }

   //     GET: Requests/Edit/5
        public ActionResult Edit(int id)
        {
            
            Request request = requests.Get(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

      //  POST: Requests/Edit/5
      //   To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      //   more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,requestType,RequestMessage,RequestDescription,RequestDate,Status")] Request request)
        {
            if (ModelState.IsValid)
            {
                requests.Update(request, request.Id);
                
                return RedirectToAction("Index");
            }
            return View(request);
        }

    //    GET: Requests/Delete/5
        public ActionResult Delete(int id)
        {
           
            Request request = requests.Get(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

    //    POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            requests.Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

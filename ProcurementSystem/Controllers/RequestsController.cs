﻿using System;
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
        IEnumerable<AssetCategory> CategoryDevice = new List<AssetCategory>();
        // GET: Requests
        public ActionResult Index()
        { 
           
            return View(new RequestUnit(Context).Get().ToList().Select(x => Factory.Create(x)).OrderByDescending(x => x.Id).ToList());

            // return View(new RequestUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }


        //  GET: Requests/Details/5
        public ActionResult Details(int id)
        {
           
           
            return View(Factory.Create(new RequestUnit(Context).Get(id)));
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
                new RequestUnit(Context).Insert(Parser.Create(model));
               
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }


        //  GET: Requests/Create
        public ActionResult Basic()
        {
            FillBag();
            return View();
        }

        //  POST: Requests/Create
        //  To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //   more details see http://go.microsoft.com/fwlink/?LinkId=317598.



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Basic(RequestModel model)
        {
            if (ModelState.IsValid)
            {
                new RequestUnit(Context).Insert(Parser.Create(model));

                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }



        //  POST: Requests/Create
        //  To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //   more details see http://go.microsoft.com/fwlink/?LinkId=317598.




        //     GET: Requests/Edit/5
        public ActionResult Edit(int id)
        {
            
            Request request = new RequestUnit(Context).Get(id);
            RequestModel model = new RequestModel()
            {
                Id = request.Id,
                requestType = request.requestType,
                RequestDescription = request.RequestDescription,
                RequestMessage = request.RequestMessage,
                RequestDate = request.RequestDate,
                Asset = request.Asset.Id,  
                Person = request.User.Id,
                Category = request.AssetCategory.Id,
                Quantity = request.Quantity,
                Status = request.Status,
                AssetType = request.AssetType,
              
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
                new RequestUnit(Context).Update(Parser.Create(model), model.Id);
                
                return RedirectToAction("Index");
            }
            return View(model);
        }



    //    GET: Requests/Delete/5
        public ActionResult Delete(int id)
        {
           
            Request request = new RequestUnit(Context).Get(id);
            return View(Factory.Create(request));
        }



    //    POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new RequestUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SomeAction()
        {
            var viewModel = new RequestModel
            {
                RequestDate = System.DateTime.Now
            };

            return View(viewModel);
        }

        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
            ViewBag.AssetsList = new SelectList(new Repository<Asset>(Context).Get().ToList(), "Id", "Model");
            ViewBag.CategoryList = new SelectList(new Repository<AssetCategory>(Context).Get().ToList(), "Id", "CategoryName");
           
            ViewBag.CategoryDevice=new SelectList(new Repository<AssetCategory>(Context).Get().ToList().Where(x => (x.assetType == (AssetType)1)), "Id", "CategoryName");
            ViewBag.CategoryNew = new SelectList(new Repository<AssetCategory>(Context).Get().ToList().Where(x => (x.assetType == (AssetType)2)), "Id", "CategoryName");






        }


    }
}

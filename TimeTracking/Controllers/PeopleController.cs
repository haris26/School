using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;
using TimeTracking.Models;

namespace TimeTracking.Controllers
{
    public class PeopleController : BaseController
    {
        public ActionResult Index()
        {
            return View(new Repository<Person>(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        public ActionResult Details(int id)
        {
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                new Repository<Person>(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
         
            return View(model);
        }

        
        public ActionResult Edit(int id)
        {
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonModel model)
        {

            if (ModelState.IsValid)
            {
                new Repository<Person>(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new Repository<Person>(Context).Delete(id);
            return RedirectToAction("Index");
        }


        public ActionResult Days (int id)

        {
            PersonDays model = new PersonDays();
            model.Person = new Repository<Person>(Context).Get(id);
            model.Days = new DayUnit(Context)
                               .Get().Where(x => x.Person.Id == id).ToList()
                               .Select(x => Factory.Create(x)).ToList();
            return View(model);
        }

        public ActionResult DayCreate(int id)   // id = Person.Id
        {

            Person person = new Repository<Person>(Context).Get(id);
            return View(new DayModel()
            { Id = 0, Person = person.Id, PersonName = person.FirstName + " " + person.LastName });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DayCreate(DayModel model)
        {
            if (ModelState.IsValid)
            {
                new DayUnit(Context).Insert(Parser.Create(model));
                return RedirectToAction("Days/"+model.Person);
            }

            return View(model);
        }

        public ActionResult DayEdit(int id)     // id = Day.id
        {
            return View(Factory.Create(new DayUnit(Context).Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DayEdit(DayModel model)
        {
            if (ModelState.IsValid)
            {
                new DayUnit(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Days/" + model.Person);
            }
            return View(model);
        }


        public ActionResult DayDelete(int id)
        {
            return View(Factory.Create(new DayUnit(Context).Get(id)));
        }


        [HttpPost, ActionName("DayDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DayDeleteConfirmed(int id)
        {
            DayUnit dayUnit = new DayUnit(Context);
            int person = dayUnit.Get(id).Person.Id;
            dayUnit.Delete(id);
            return RedirectToAction("Days/" + person);
        }


        public ActionResult Detail(int id)      //day.id
        {
            DayDetail model = new DayDetail();
            model.Day = new Repository<Day>(Context).Get(id);
            model.Detail = new DetailUnit(Context).Get().Where(x => x.Day.Id == id).ToList()
                            .Select(x => Factory.Create(x)).ToList();
            return View(model);
        }

        public ActionResult DetCreate(int id)   // id = Day.Id
        {
            FillBag();

            Day day = new Repository<Day>(Context).Get(id);
            return View(new DetailModel()
            { Id = 0, Day = day.Id, Date = day.Date });

        }

        public ActionResult DetEdit(int id)     // id = Detail.Id
        {
            FillBag();
            return View(Factory.Create(new DetailUnit(Context).Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetCreate(DetailModel model)
        {
            if (ModelState.IsValid)
            {
                Detail detail = Parser.Create(model);
                new DetailUnit(Context).Insert(detail);
                return RedirectToAction("Detail/" + model.Day);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetEdit(DetailModel model)
        {
            if (ModelState.IsValid)
            {
                Detail detail = Parser.Create(model);
                new DetailUnit(Context).Update(detail, detail.Id);
                return RedirectToAction("Detail/" + model.Day);
            }
            return View(model);
        }

        public ActionResult DetDelete(int id)
        {
            return View(Factory.Create(new DetailUnit(Context).Get(id)));
        }


        [HttpPost, ActionName("DetDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DetDeleteConfirmed(int id)
        {
            DetailUnit detailUnit = new DetailUnit(Context);
            int day = detailUnit.Get(id).Day.Id;
            detailUnit.Delete(id);
            return RedirectToAction("Detail/" + day);
        }

        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
            ViewBag.TeamsList = new SelectList(new Repository<Team>(Context).Get().ToList(), "Id", "Name");
        }
    }
}
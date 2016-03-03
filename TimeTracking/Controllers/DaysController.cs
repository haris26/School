using System.Data;
using System.Linq;
using System.Web.Mvc;
using Database;
using TimeTracking.Models;
using Microsoft.Ajax.Utilities;


namespace TimeTracking.Controllers
{
    public class DaysController : BaseController
    {
        
        public ActionResult Index()
        {
            return View(new DayUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }


        public ActionResult Details(int id)
        {
            return View(Factory.Create(new DayUnit(Context).Get(id)));
        }


        public ActionResult Create()
        {
            FillBag();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DayModel model)
        {
            if (ModelState.IsValid)
            {
                new DayUnit(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        // GET: Days/Edit/5
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(Factory.Create(new DayUnit(Context).Get(id)));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DayModel model)
        {

            if (ModelState.IsValid)
            {
                new DayUnit(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Days/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Factory.Create(new DayUnit(Context).Get(id)));
        }

        // POST: Days/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new DayUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }

       
        public ActionResult Detail(int id) {
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

        public ActionResult DayCreate(int id)   // id = Person.Id
        {
            FillBag();
            Person person = new Repository<Person>(Context).Get(id);
            return View(new DayModel()
            { Id = 0, Person = person.Id, PersonName = person.FirstName + " " + person.LastName });
        }

        public ActionResult DayEdit(int id)     // id = Egagement.Id
        {
            FillBag();
            return View(Factory.Create(new Repository<Person>(Context).Get(id)));
        }


        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
        }
    }
}






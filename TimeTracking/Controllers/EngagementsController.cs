using Database;
using System.Linq;
using System.Web.Mvc;
using TimeTracking.Models;

namespace TimeTracking.Controllers
{
    public class EngagementsController : BaseController
    {
        public ActionResult Index()
        {
            return View(new EngagementUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        public ActionResult Details(int id)
        {
            return View(Factory.Create(new EngagementUnit(Context).Get(id)));
        }

        public ActionResult Create()
        {
            FillBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EngagementModel model)
        {
            if (ModelState.IsValid)
            {
                new EngagementUnit(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            FillBag();
            return View(Factory.Create(new EngagementUnit(Context).Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EngagementModel model)
        {
            if (ModelState.IsValid)
            {
                new EngagementUnit(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            return View(Factory.Create(new EngagementUnit(Context).Get(id)));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new EngagementUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
            ViewBag.RolesList = new SelectList(new Repository<Role>(Context).Get().ToList(), "Id", "Name");
            ViewBag.TeamsList = new SelectList(new Repository<Team>(Context).Get().ToList(), "Id", "Name");
        }
    }
}
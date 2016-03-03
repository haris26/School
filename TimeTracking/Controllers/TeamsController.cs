//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Database;
//using TimeTracking.Models;


//namespace TimeTracking.Controllers
//{
//    public class TeamsController : BaseController
//    {

//        public ActionResult Index()
//        {
//            return View(new Repository<Team>(Context).Get().ToList().Select(x => Factory.Create(x)).ToList());
//        }


//        public ActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(TeamModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                new Repository<Team>(Context).Insert(Parser.Create(model));
//                return RedirectToAction("Index");
//            }
//            FillBag();
//            return View(model);
//        }

//        public ActionResult Edit(int id)
//        {
//            return View(teams.Get(id));
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Team team)
//        {
//            if (ModelState.IsValid)
//            {
//                teams.Update(team, team.Id);
//                return RedirectToAction("Index");
//            }
//            return View(team);
//        }

//        public ActionResult Delete(int id)
//        {
//            return View(teams.Get(id));
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            teams.Delete(id);
//            return RedirectToAction("Index");
//        }
//    }
//}
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
    public class TeamsController : BaseController
    {
        private Repository<Team> teams = new Repository<Team>(new SchoolContext());

        public ActionResult Index()
        {
            return View(teams.Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        public ActionResult Details(int id)
        {
            return View(Factory.Create(teams.Get(id)));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                teams.Insert(team);
                return RedirectToAction("Index");
            }
            return View(team);
        }

        public ActionResult Edit(int id)
        {
            return View(teams.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                teams.Update(team, team.Id);
                return RedirectToAction("Index");
            }
            return View(team);
        }

        public ActionResult Delete(int id)
        {
            return View(teams.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teams.Delete(id);
            return RedirectToAction("Index");
        }


        void FillBag()
        {
            ViewBag.ToolsList = new SelectList(new Repository<Tool>(Context).Get().ToList(), "Id", "Name");
        }
    }
}

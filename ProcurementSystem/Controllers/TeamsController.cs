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
    public class TeamsController : Controller
    {
        private Repository<Team> teams = new Repository<Team>(new SchoolContext());

        private EntityParser parser = new EntityParser();
        private ModelFactory factory = new ModelFactory();

        public ActionResult Index()
        //    {            List<TeamModel> teamList = new List<TeamModel>();
        //    var teamsCol = teams.Get().ToList();
        //    foreach(var tean in teamsCol)
        //    {
        //        TeamModel model = factory.Create(team);
        //        teamList.Add(model);
        //    }

        {


            //List<TeamModel> teamList = new List<TeamModel>();
            //var teamsCol = teams.Get().ToList();
            //foreach(var team in teamsCol)
            //{
            //    TeamModel model = factory.Create(team);
            //    teamList.Add(model);
            //}

            //return View(teamList);

            return View(teams.Get().ToList().Select(x => factory.Create(x)).ToList());
        }

        public ActionResult Details(int id)
        {
            return View(factory.Create(teams.Get(id)));
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
    }
}
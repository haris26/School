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
    public class TeamsController : Controller
    {
        private Repository<Team> teams = new Repository<Team>(new SchoolContext());

        // GET: Teams
        public ActionResult Index()
        {
            IList<TeamModel> teamList = new List<TeamModel>();
           var teamCol = teams.Get().ToList();
            foreach (var team in teamCol) {
                TeamModel teamModel = new TeamModel()
                {
                    Id = team.Id,
                    Name = team.Name
                };
                foreach (var person in team.Roles) {
                    teamModel.Members.Add(person.Person.FirstName + " "+ person.Person.LastName);
                }
                teamList.Add(teamModel);
            }
            return View(teamList); 
        }

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {
            Team team = teams.Get(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Type")] Team team)
        {
            if (ModelState.IsValid)
            {
                teams.Insert(team);
                return RedirectToAction("Index");
            }

            return View(team);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int id)
        {
            
            Team team = teams.Get(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Type")] Team team)
        {
            if (ModelState.IsValid)
            {
                teams.Update(team, team.Id);
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int id)
        {

            Team team = teams.Get(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teams.Delete(id);
            return RedirectToAction("Index");
        }

     
    }
}

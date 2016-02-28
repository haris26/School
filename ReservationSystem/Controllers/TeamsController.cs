using System.Data;
using System.Linq;
using System.Web.Mvc;
using Database;
using ReservationSystem.Models;

namespace ReservationSystem.Controllers
{
    public class TeamsController : BaseController
    {
        private Repository<Team> teams = new Repository<Team>(new SchoolContext());
        private ModelFactory factory = new ModelFactory(new SchoolContext());


        // GET: Teams
        public ActionResult Index()
        {
          
            return View(teams.Get().ToList().Select(x => factory.Create(x)).ToList());
        }

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {

            return View(factory.Create(teams.Get(id)));

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


            return View(teams.Get(id));

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

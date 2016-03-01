using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Database;
using TimeTracking.Models;
using System.Collections.Generic;

namespace TimeTracking.Controllers
{
    public class RolesController : Controller
    {
        private Repository<Role> roles = new Repository<Role>(new SchoolContext());

        // GET: Roles
        public ActionResult Index() {
            IList<RoleModel> roleList = new List<RoleModel>();
            var roleCol = roles.Get().ToList();
            foreach (var role in roleCol)
            {
                RoleModel roleModel = new RoleModel()
                {
                    Id = role.Id,
                    Name = role.Name
                };
                foreach (var person in role.Roles)
                {
                    roleModel.Members.Add(person.Person.FirstName + " " + person.Person.LastName);
                }
                roleList.Add(roleModel);
            }
            return View(roleList);
        }
        //{
        //    return View(roles.Get().ToList());
        //}
        


// GET: Roles/Details/5
public ActionResult Details(int id)
        {
            
            Role role = roles.Get(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Team,System")] Role role)
        {
            if (ModelState.IsValid)
            {
                roles.Insert(role);
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            Role role = roles.Get(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Team,System")] Role role)
        {
            if (ModelState.IsValid)
            {
                roles.Update(role, role.Id);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            Role role = roles.Get(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            roles.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}

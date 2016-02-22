using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TimeTracking.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string Index()
        {
            return "THIS IS JUST FOR THE TEST";
        }

        public string Show() {
            return "This is another string from the same controller";
        }

        public string Look(string id) {
            return "You just sent a " + id + " to me";
        }

        public ActionResult Get(string id ="X") {
            if (id == "X")
            {
                ViewBag.Title = "TimeTracking";
                return View();
            }
            else { return Content("Proslijedi mi " + id); }

        }

        public ActionResult Person(int id) {
            Repository<Person> people = new Repository<Person>(new SchoolContext());
            Person person = people.Get(id);
            //ViewBag.Person = person;
            //ViewData["Person"] = person;
            return View(person);
        }

        public ActionResult People()
        {
            Repository<Person> people = new Repository<Person>(new SchoolContext());
 
            return View(people.Get().ToList());
        }

    }
}
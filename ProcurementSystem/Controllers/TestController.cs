using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcurementSystem.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string Index()
        {
            return "This is just for the test";
        }

        public string Show()
        {
            return "This is another string from the same controller";
        }

        public string Look(string id)
        {
            return "You just sent a " + id + " to me!";
        }


        public ActionResult Get(string id = "X")
        {
            if (id == "X")
            {
                ViewBag.Title = "Procurement System";
                return View();
            }
            else
            {
                return Content("Proslijedise mi " + id);
            }
        }

        public ActionResult Person(int id)
        {
            Repository<Person> people = new Repository<Person>(new SchoolContext());
            Person person = people.Get(id);
            // ViewBag.Person = person;
           // ViewData["Person"] = person;
            return View(person);
        }

        public ActionResult People()
        {
            Repository<Person> people = new Repository<Person>(new SchoolContext());
           
            return View(people.Get().ToList());
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database;
namespace ReservationSystem.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string Index()
        {
            return "Gdje ste rajaaaa";
        }
        public string Show()
        {
            return "Another string from the same controleer";
        }
        public string Look(string id)
        {
            return "You just sent: " + id;
        }
        public ActionResult Get(string id = "X")
        {
            if (id == "X")
            {
                ViewBag.Title = "ReservationSystem";
                return View();
            }
            else
            {
                return Content("Proslijedise mi: " + id);
            }
        }
        public ActionResult People()
        {
            Repository<Person> people = new Repository<Person>(new SchoolContext());
            return View(people.Get().ToList());
        }
        public ActionResult Person(int id)
        {
            Repository<Person> people = new Repository<Person>(new SchoolContext());
            Person person = people.Get(id);
            //ViewBag.Person = person;
            //ViewData["Person"] = person;
            return View(person);
        }
    }
}
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

<<<<<<< HEAD
=======

>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
namespace TimeTracking.Controllers
{
    public class TestController : Controller
    {
<<<<<<< HEAD
=======
        // GET: Test
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
        public string Index()
        {
            return "THIS IS JUST FOR THE TEST";
        }

<<<<<<< HEAD
        public string Show()
        {
            return "THIS IS ANOTHER STRING FROM THE SAME CONTROLLER";
        }

        public string Look(string id)
        {
            return "YOU JUST SENT A " + id + " TO ME";
        }

        public ActionResult Get(string id = "X")
        {
=======
        public string Show() {
            return "This is another string from the same controller";
        }

        public string Look(string id) {
            return "You just sent a " + id + " to me";
        }

        public ActionResult Get(string id ="X") {
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
            if (id == "X")
            {
                ViewBag.Title = "TimeTracking";
                return View();
            }
<<<<<<< HEAD
            else
            {
                return Content("Proslijedise mi " + id);
            }
        }

        public ActionResult People()
        {
            Repository<Person> people = new Repository<Person>(new SchoolContext());
            return View(people.Get().ToList());
        }

        public ActionResult Person(int id)
        {
=======
            else { return Content("Proslijedi mi " + id); }

        }

        public ActionResult Person(int id) {
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
            Repository<Person> people = new Repository<Person>(new SchoolContext());
            Person person = people.Get(id);
            //ViewBag.Person = person;
            //ViewData["Person"] = person;
            return View(person);
        }

<<<<<<< HEAD
=======
        public ActionResult People()
        {
            Repository<Person> people = new Repository<Person>(new SchoolContext());
 
            return View(people.Get().ToList());
        }

>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
    }
}
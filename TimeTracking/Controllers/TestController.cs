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

        public string Index()
        {
            return "THIS IS JUST FOR THE TEST";
        }


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

            if (id == "X")
            {
                ViewBag.Title = "TimeTracking";
                return View();
            }
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
            Repository<Person> people = new Repository<Person>(new SchoolContext());
            Person person = people.Get(id);
            //ViewBag.Person = person;
            //ViewData["Person"] = person;
            return View(person);
        }
    }
}
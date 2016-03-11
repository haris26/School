using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database;
using ReservationSystem.Models;
using Microsoft.Ajax.Utilities;

namespace ReservationSystem.Controllers
{
    public class ReservationsController : BaseController
    {
        // GET: Reservations
        public ActionResult Index()
        {
            //ReservationModel model = new ReservationModel();
            //model.Events = new EventUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList();
            //model.Resources = new ResourceUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList();
            //model.ResourceCharacteristics = new Repository<Characteristic>(Context).Get().ToList();
            return View();
        }

        public ActionResult Rooms()
        {
            IList<ReservationModel> models = new List<ReservationModel>();
            var resources = new ResourceUnit(Context).Get().ToList().Where(x => (x.ResourceCategory.CategoryName == "Room" && x.Status == ReservationStatus.Available));
            var events = new EventUnit(Context).Get().ToList().Where(x => x.Resource.ResourceCategory.CategoryName == "Room");
            foreach (var res in resources)
            {
                ReservationModel model = new ReservationModel()
                {
                    Id = res.Id,
                    Name = res.Name
                };

                foreach (var ch in res.Characteristics)
                {
                    model.Characteristics.Add(new Characteristic() { Name = ch.Name, Value = ch.Value });
                }
                foreach (var ev in events)
                {
                    model.Events.Add(new Event() { EventTitle = ev.EventTitle, EventStart = ev.EventStart, EventEnd = ev.EventEnd });
                }
                models.Add(model);

            }
            return View(models); 
        }

        public ActionResult CreateRoomRes(int id)   // id = resource (room) id
        {
            Resource room = new ResourceUnit(Context).Get(id);
            FillRooms();
            return View(new EventModel()
            {
                Resource = room.Id,
                ResourceName = room.Name
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRoomRes(EventModel model)
        {
            string[] timePars = model.Time.Split(':');
            int hh = Convert.ToInt32(timePars[0]);
            int mm = Convert.ToInt32(timePars[1]);
            model.StartDate = model.StartDate.AddHours(hh);
            model.StartDate = model.StartDate.AddMinutes(mm);
            model.EndDate = model.EndDate.AddHours(hh);
            model.EndDate = model.EndDate.AddMinutes(mm + 15);

            if (ModelState.IsValid)
            {
                Event e = Parser.Create(model);
                new EventUnit(Context).Insert(e);
                return RedirectToAction("Rooms");
            }
            return View(model);
        }

        public void FillRooms()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
            ViewBag.ResourceList = new SelectList(new Repository<Resource>(Context).Get().ToList().Where(x => (x.ResourceCategory.CategoryName == "Room" && x.Status == ReservationStatus.Available)), "Id", "Name");
            List<string> times = new List<string>(new string[]
            {
                "9:00", "9:15", "9:30", "9:45",
                "10:00", "10:15", "10:30", "10:45",
                "11:00", "11:15", "11:30", "11:45",
                "12:00", "12:15", "12:30", "12:45",
                "13:00", "13:15", "13:30", "13:45",
                "14:00", "14:15", "14:30", "14:45",
                "15:00", "15:15", "15:30", "15:45",
                "16:00", "16:15", "16:30", "16:45",
            });
            ViewBag.TimeList = new SelectList(times);
        }

        public ActionResult Devices()
        {

        	IList<ReservationModel> models = new List<ReservationModel>();
            var resources = new ResourceUnit(Context).Get().ToList().Where(x => (x.ResourceCategory.CategoryName == "Device" && x.Status == ReservationStatus.Available));
            var events = new EventUnit(Context).Get().ToList().Where(x => x.Resource.ResourceCategory.CategoryName == "Device");
            foreach (var res in resources)
            {
                ReservationModel model = new ReservationModel()
                {
                    Id = res.Id,
                    Name = res.Name
                };

                foreach (var ch in res.Characteristics)
                {
                    model.Characteristics.Add(new Characteristic() { Name = ch.Name, Value = ch.Value });
                }
                foreach (var ev in events)
                {
                    model.Events.Add(new Event() { EventTitle = ev.EventTitle, EventStart = ev.EventStart, EventEnd = ev.EventEnd });
                }
                models.Add(model);

            }
            return View(models);
        }
        public ActionResult CreateDeviceRes(int id)
        {
            Resource device = new ResourceUnit(Context).Get(id);
            FillDevices();
            return View(new EventModel()
            {
                Resource = device.Id,
                ResourceName = device.Name
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDeviceRes (EventModel model)
        {
            string[] timePars = model.Time.Split(':');
            int hh = Convert.ToInt32(timePars[0]);
            int mm = Convert.ToInt32(timePars[1]);
            model.StartDate = model.StartDate.AddHours(hh);
            model.StartDate = model.StartDate.AddMinutes(mm);
            model.EndDate = model.EndDate.AddHours(hh);
            model.EndDate = model.EndDate.AddMinutes(mm + 15);
            if (ModelState.IsValid)
            {
                Event e = Parser.Create(model);
                new EventUnit(Context).Insert(e);
                return RedirectToAction("Devices");
            }
            return View(model);
        }
        public void FillDevices()
        {
            ViewBag.AvailableDev = new SelectList(new ResourceUnit(Context).Get().ToList().Where(x => x.Status == ReservationStatus.Available && x.ResourceCategory.CategoryName == "Device"), "Id", "Name");
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
            List<string> times = new List<string>(new string[]
            {
                "9:00", "9:15", "9:30", "9:45",
                "10:00", "10:15", "10:30", "10:45",
                "11:00", "11:15", "11:30", "11:45",
                "12:00", "12:15", "12:30", "12:45",
                "13:00", "13:15", "13:30", "13:45",
                "14:00", "14:15", "14:30", "14:45",
                "15:00", "15:15", "15:30", "15:45",
                "16:00", "16:15", "16:30", "16:45",
            });
            ViewBag.TimeList = new SelectList(times);
        }
    }
}
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

        public void FillRooms()
        {
            ViewBag.PeopleList = new SelectList(new Repository<Person>(Context).Get().ToList(), "Id", "FirstName");
            ViewBag.ResourceList = new SelectList(new Repository<Resource>(Context).Get().ToList().Where(x => (x.ResourceCategory.CategoryName == "Room" && x.Status == ReservationStatus.Available)), "Id", "Name");
        }

        public ActionResult Devices()
        {
            //ReservationModel model = new ReservationModel();
            //model.Events = new EventUnit(Context).Get().ToList().Where(x => x.Resource.ResourceCategory.CategoryName == "Device").Select(x => Factory.Create(x)).ToList();

            //model.Resources = new ResourceUnit(Context).Get().Where(x => x.ResourceCategory.CategoryName == "Device").ToList()
            //    .Select(x => Factory.Create(x)).ToList();
            //model.ResourceCharacteristics = new Repository<Characteristic>(Context).Get().ToList().Where(x => x.Resource.ResourceCategory.CategoryName == "Device").ToList();

            //ViewBag.ResourceList = new SelectList(new ResourceUnit(Context).Get().ToList().Where(x => x.ResourceCategory.CategoryName == "Device" ), "Id", "Name");
            ViewBag.DeviceTypeList = new SelectList(new Repository<Characteristic>(Context).Get().ToList().Where(x => x.Name == "OsType"),"Id", "Value").DistinctBy(x => x.Text);
            return View(model);

        }
    }
}
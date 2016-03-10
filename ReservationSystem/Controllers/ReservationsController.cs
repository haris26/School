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
            ReservationModel model = new ReservationModel();
            model.Events = new EventUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList();
            model.Resources = new ResourceUnit(Context).Get().ToList().Select(x => Factory.Create(x)).ToList();
            model.ResourceCharacteristics = new Repository<Characteristic>(Context).Get().ToList();
            return View();
        }

        public ActionResult Rooms()
        {
            ReservationModel model = new ReservationModel();
            model.Events = new EventUnit(Context).Get().ToList().Where(x => x.Resource.ResourceCategory.CategoryName == "Room").Select(x => Factory.Create(x)).ToList();
            model.Resources = new ResourceUnit(Context).Get().ToList().Where(x => x.ResourceCategory.CategoryName == "Room").Select(x => Factory.Create(x)).ToList();
            model.ResourceCharacteristics = new Repository<Characteristic>(Context).Get().Where(x => x.Resource.ResourceCategory.CategoryName == "Room").ToList();
            return View(model);
        }

        public ActionResult Devices()
        {
            ReservationModel model = new ReservationModel();
            model.Events = new EventUnit(Context).Get().ToList().Where(x => x.Resource.ResourceCategory.CategoryName == "Device").Select(x => Factory.Create(x)).ToList();
           
            model.Resources = new ResourceUnit(Context).Get().Where(x => x.ResourceCategory.CategoryName == "Device").ToList()
                .Select(x => Factory.Create(x)).ToList();
            model.ResourceCharacteristics = new Repository<Characteristic>(Context).Get().ToList().Where(x => x.Resource.ResourceCategory.CategoryName == "Device").ToList();

            //ViewBag.ResourceList = new SelectList(new ResourceUnit(Context).Get().ToList().Where(x => x.ResourceCategory.CategoryName == "Device" ), "Id", "Name");
            ViewBag.DeviceTypeList = new SelectList(new Repository<Characteristic>(Context).Get().ToList().Where(x => x.Name == "OsType"),"Id", "Value").DistinctBy(x => x.Text);
            return View(model);
        }
    }
}
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ReservationsController : BaseController<Resource>
    {
        public ReservationsController(Repository<Resource> depo) : base(depo) { }

        public List<ReservationModel> Get(string id)
        {
            IList<ReservationModel> models = new List<ReservationModel>();
            if (id == "Rooms")
            {
                //IList<ReservationModel> models = new List<ReservationModel>();
                var resources = Repository.Get().ToList().Where(x => (x.ResourceCategory.CategoryName == "Room" && x.Status == ReservationStatus.Available));
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
                    models.Add(model);
                }
            }
                return models.ToList();
            
        }
    }
}

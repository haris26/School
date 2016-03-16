using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Controllers.WebAPI.Controllers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DetailsController : BaseController<Detail>
    {

        public DetailsController(Repository<Detail> depo) : base(depo)
        { }

        public IList<DetailModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }


        public DetailModel Get(int id)
        {
            return Factory.Create(Repository.Get(id));
        }
        public void Post(Detail detail)
        {
            Repository.Insert(detail);
        }
        public void Put(int id, Detail detail)
        {
            Repository.Update(detail, id);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);

        }
    }
}

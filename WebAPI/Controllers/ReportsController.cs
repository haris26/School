using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    

    public class ReportsController : BaseController<Request>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public ReportsController(Repository<Request> depo) : base(depo) { }

        //public IList<RequestModel> Get(int id = 0, int t = 0, int s = 0)
        //{
        //    int user = id;
        //    int type = t;
        //    int status = s;

        //    if(type == 0 && status == 0) {
        //        var query = Repository.Get().Where(x => x.User.Id == user).ToList();
        //        IList<RequestModel> list = query.Select(x => Factory.Create(x)).ToList();

        //        return list;
        //    }else if(user == 0 && status == 0)
        //    {
        //        var query = Repository.Get().Where(x => x.requestType ==  RequestType.New).ToList();
        //        IList<RequestModel> list = query.Select(x => Factory.Create(x)).ToList();

        //        return list;
        //    }

            
        //}
       
      
    }
}

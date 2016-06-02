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


        public IList<RequestModel> Get(int id = 0, string y = "", string t = "" )
        {
            int user = id;
            RequestType type = (RequestType)Enum.Parse(typeof(RequestType), t);
            RequestStatus status = (RequestStatus)Enum.Parse(typeof(RequestStatus), y);

            if (type == 0 && status == 0 && user != 0)
            {
                var query1 = Repository.Get().Where(x => x.User.Id == user).ToList();
                IList<RequestModel> list1 = query1.Select(x => Factory.Create(x)).ToList();

                return list1;
            }
            else if (user == 0 && status == 0 && type != 0)
            {
                var query2 = Repository.Get().Where(x => x.requestType == type).ToList();
                IList<RequestModel> list2 = query2.Select(x => Factory.Create(x)).ToList();

                return list2;
            }
            else if (user == 0 && type == 0 && status != 0)
            {
                var query3 = Repository.Get().Where(x => x.Status == status).ToList();
                IList<RequestModel> list3 = query3.Select(x => Factory.Create(x)).ToList();
                return list3;
            }
            else if (user != 0 && status != 0 && type == 0)
            {
                var query4 = Repository.Get().Where(x => x.User.Id == user && x.Status == status).ToList();
                IList<RequestModel> list4 = query4.Select(x => Factory.Create(x)).ToList();
                return list4;
            }
            else if (user != 0 && status == 0 && type != 0)
            {
                var query5 = Repository.Get().Where(x => x.User.Id == user && x.requestType == type).ToList();
                IList<RequestModel> list5 = query5.Select(x => Factory.Create(x)).ToList();
                return list5;
            }
            else if (user == 0 && status != 0 && type != 0)
            {
                var query6 = Repository.Get().Where(x => x.Status ==  status && x.requestType ==  type).ToList();
                IList<RequestModel> list6 = query6.Select(x => Factory.Create(x)).ToList();
                return list6;
            }

            var query = Repository.Get().Where(x => x.User.Id == user && x.Status == status && x.requestType == type).ToList();
            IList<RequestModel> list = query.Select(x => Factory.Create(x)).ToList();
            return list;

        }

    }
}

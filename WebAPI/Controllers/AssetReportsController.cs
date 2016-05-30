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


    public class AssetReportsController : BaseController<Asset>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public AssetReportsController(Repository<Asset> depo) : base(depo) { }

        public IList<AssetsModel> Get(int id = 0, int y = 0)
        {
            int month = id;
            int year = y;
            var query = Repository.Get().Where(x => x.DateOfTrade.Year == year && x.DateOfTrade.Month == month).ToList();
            IList<AssetsModel> list = query.Select(x => Factory.Create(x)).ToList();

            return list;
        }
    
      
    }
}


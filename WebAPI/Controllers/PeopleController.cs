using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;
using System.Web;

namespace WebAPI.Controllers
{
    public class PeopleController : BaseController<Person>
    {
        public PeopleController(Repository<Person> depo):base(depo)
        { }

        public IList<PersonModel> Get(int page, int PageSize)
        {
            var query = Repository.Get().OrderBy(x => x.FirstName)
                                        .ThenBy(x => x.LastName).ToList();
            int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);
            IList<PersonModel> people = query.Skip(PageSize * page)
                                             .Take(PageSize).ToList()
                                             .Select(x => Factory.Create(x))
                                             .ToList();

            var pageHeader = new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages
            };

            HttpContext.Current.Response.Headers.Add("Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(pageHeader));
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
            return people;
        }

        public IList<PersonModel> Get (string searchedString, int page, int PageSize)
        {
            var query = Repository.Get()
                            .Where(x => x.FirstName.Contains(searchedString) || x.LastName.Contains(searchedString))
                            .OrderBy(x => x.FirstName)
                            .ThenBy(x => x.LastName).ToList();
            int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);
            IList<PersonModel> people = query.Skip(PageSize * page)
                                             .Take(PageSize).ToList()
                                             .Select(x => Factory.Create(x))
                                             .ToList();

            var pageHeader = new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages
            };

            HttpContext.Current.Response.Headers.Add("Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(pageHeader));
            HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
            return people;
        }
    }
}

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
    public class PeopleController : BaseController<Person>
    {
        public PeopleController(Repository<Person> depo) : base(depo) { }

        //public IList<PersonModel> Get(int page = 0)
        //{
        //    int PageSize = 5;
        //    IList<PersonModel> people = Repository.Get().OrderBy(x => x.LastName)
        //                                .ThenBy(x => x.FirstName).Skip(PageSize * page).Take(PageSize)
        //                                .ToList().Select(x => Factory.Create(x)).ToList();
        //    return people;
        //}
        public Object GetAll(int page = 0)
        {
            int PageSize = 5;

            var query =
                Repository.Get()
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToList();

            int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);

            IList<PersonModel> people =
                query.Skip(PageSize * page).Take(PageSize).ToList().Select(x => Factory.Create(x)).ToList();

            return new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages,
                people = people
            };
        }
    }
}

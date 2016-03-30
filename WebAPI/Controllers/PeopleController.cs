using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Controllers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PeopleController : BaseController<Person>
    {
        public PeopleController(Repository<Person> depo) : base(depo) { }


        //public Object GetAll(int page = 0)
        //{
        //    int PageSize = 5;
        //    var query =
        //       Repository.Get()
        //           .OrderBy(x => x.FirstName)
        //           .ThenBy(x => x.LastName)
        //           .ToList();

        //    int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);

        //    IList<PeopleModel> people =
        //        query.Skip(PageSize * page).Take(PageSize).ToList().Select(x => Factory.Create(x)).ToList();

        //    return new
        //    {
        //        pageSize = PageSize,
        //        currentPage = page,
        //        pageCount = TotalPages,
        //        allPeople = people
        //    };
        //}

        public IList<PeopleModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Person person = Repository.Get(id);
                if (person == null)
                {
                    return NotFound();

                }
                else

                    return Ok(Factory.Create(person));

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(PeopleModel model)
        {
            try
            {
                Repository.Insert(Parser.Create(model, Repository.BaseContext()));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int id, PeopleModel model)
        {
            try
            {
                Repository.Update(Parser.Create(model, Repository.BaseContext()), model.Id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}

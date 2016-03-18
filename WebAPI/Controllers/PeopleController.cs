using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Controllers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PeopleController : BaseController<Person>
    {

        public PeopleController(Repository<Person> depo) : base(depo)
        { }

        public IList<PersonModel> GetAll(int page = 0)
        {
            int PageSize = 5;
            var query = Repository.Get().OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
            int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);
            IList<PersonModel> people = query.Skip(PageSize * page)
                                              .Take(PageSize).ToList()
                                              .Select(x => Factory.Create(x))
                                              .ToList();           

                var PageHeader = new
                {
                    pageSize = PageSize,
                    currentPage = page,
                    pageCount = TotalPages
                };

                HttpContext.Current.Response.Headers.Add
                ("Pagination", Newtonsoft.Json.JsonConvert.SerializeObject
                (PageHeader));

                return people;
           
           
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Person person = Repository.Get(id);
                if (person == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(person));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Post(PersonModel model)
        {
            var sch = Repository.BaseContext();

            try
            {
                if (model == null) return NotFound();
                else {
                    Repository.Insert(Parser.Create(model, sch));
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Put(int id, PersonModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                Person person = Repository.Get(id);
                if (person == null || model == null) return NotFound();
                else {
                    Repository.Update(Parser.Create(model, sch), id);
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Person person = Repository.Get(id);
                if (person == null)
                    return NotFound();
                else
                    Repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}


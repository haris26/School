using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using WebAPI.Models;
using Database;
using System.Web;
using System.Web.Http;
using System.Configuration;

namespace WebAPI.Controllers
{
    public class PeopleController : BaseController<Person>
    {
        public PeopleController(Repository<Person> depo) : base(depo)
        { }
        public IList<PersonModel> Get()
        {
            var people = Repository.Get().OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList().Select(x => Factory.Create(x)).ToList();
            return people;
        }
        public IList<PersonModel> GetAll(int page)
        {
            int PageSize = 15;
            var query = Repository.Get().OrderBy(x => x.LastName)
                                        .ThenBy(x => x.FirstName);
            int TotalPages = (int)Math.Ceiling
                            ((double)query.Count() / PageSize);
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

        //HttpContext.Current.Response.Headers.Add("Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PageHeader));
            return people;
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Person person = Repository.Get(id);
                if (person == null) return NotFound();
                else
                    return Ok(Factory.Create(Repository.Get(id)));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(Person person)
        {
            try
            {
                if (person == null) return NotFound();
                else {
                    Repository.Insert(person);
                    return Ok(Factory.Create(person));
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Put(int id, Person person)
        {
            try
            {
                Person person1 = Repository.Get(id);
                if (person1 == null || person == null) return NotFound();
                else {
                    Repository.Update(person, id);
                    return Ok(Factory.Create(person));
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
                if (person == null) return NotFound();
                else {
                    Repository.Delete(id);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}

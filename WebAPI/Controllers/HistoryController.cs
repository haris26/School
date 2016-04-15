using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Controllers;
using WebAPI.Filters;
using WebAPI.Models;


namespace WebAPI.Controllers
{
  
    public class HistoryController : BaseController<History>
    {
        
        public HistoryController(Repository<History> depo) : base(depo) { }



        public Object GetAll(int page = 0)
        {
            int PageSize = 5;
            var query =
               Repository.Get()
                   .OrderBy(x => x.Person.FirstName)
                   .ThenBy(x => x.EventBegin)
                   .ToList();

            int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);

            IList<HistoryModel> history =
                query.Skip(PageSize * page).Take(PageSize).ToList().Select(x => Factory.Create(x)).ToList();

            return new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages,
                allhistory = history
            };
        }

        public IHttpActionResult Get(int id)
        {
            try {
                History history = Repository.Get(id);
                if(history == null)
                {
                    return NotFound();

                }
                else
                
                    return Ok(Factory.Create(history));
               
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(HistoryModel model)
        {
            try {
                Repository.Insert(Parser.Create(model, Repository.BaseContext()));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int id, HistoryModel model)
        {
            try {
                Repository.Update(Parser.Create(model, Repository.BaseContext()), model.Id);
                return Ok(model);
            }
            catch(Exception ex)
            {
             return   NotFound();
            }
          }

        public IHttpActionResult Delete(int id)
        {
            try {
                Repository.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
    }
}

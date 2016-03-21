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
    public class RequestsController : BaseController<Request>
    {
        
        public RequestsController(Repository<Request> depo) : base(depo) { }

        public Object GetAll(int page = 0)
        {
            int PageSize = 5;
            var query =
               Repository.Get()
                   .OrderByDescending(x => x.Status)
                   .ThenBy(x => x.RequestDate)
                   .ToList();

            int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);
            IList<RequestModel> requests =
               query.Skip(PageSize * page).Take(PageSize).ToList().Select(x => Factory.Create(x)).ToList();

            return new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages,
                allRequests = requests
            };
        }


         public IHttpActionResult Get(int id)
        {
            try {
                Request request = Repository.Get(id);
                if(request == null)
                {
                    return NotFound();

                }
                else
                
                    return Ok(Factory.Create(request));
               
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(RequestModel model)
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

        public IHttpActionResult Put(int id, RequestModel model)
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

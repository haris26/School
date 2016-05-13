using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DaysController : BaseController<Day>
    {
        public DaysController(Repository<Day> depo) : base(depo)
        { }
        public IList<DayModel> GetAll(int page = 0)
        {
            int PageSize = 5;
            var query = Repository.Get().OrderBy(x => x.Person.LastName).ThenBy(x => x.Person.FirstName).ThenBy(x => x.Date);
            int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);

            IList<DayModel> days = query.Skip(PageSize * page)
                    .Take(PageSize).ToList()
                    .Select(x => Factory.Create(x))
                    .ToList();
            var PageHeader = new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages,
            };

            HttpContext.Current.Response.Headers.Add("Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PageHeader));
            return days;
        }


        //public IHttpActionResult Get(int id)
        //{
        //    try {
        //        Day day = Repository.Get(id);
        //        if (day == null) return NotFound();
        //        else
        //            return Ok(Factory.Create(Repository.Get(id)));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}
        public IList<DayModel> Get(int id)
        {


            var day = Repository.Get().Where(x => x.Person.Id == id).ToList();


            List<DayModel> DayModel = new List<DayModel>();

            foreach (Day d in day)
            {
                DayModel.Add(Factory.Create(d));
            }
            return DayModel;
        }


        public IList<DayModel> Get(int id, int m, int y, int dd)
        {

            
            var day = Repository.Get().Where(x => x.Person.Id == id && x.Date.Month == m && x.Date.Year == y && x.Date.Day == dd).ToList();
          
           
            List<DayModel> DayModel = new List<DayModel>();
               
            foreach (Day d in day)
            { 
                DayModel.Add(Factory.Create(d));               
            }
                return DayModel;        
            }
        public IList<DayModel> Get(int id, int m, int y)
        {

            var day = Repository.Get().Where(x => x.Person.Id == id && x.Date.Month == m && x.Date.Year == y).ToList();

            List<DayModel> DayModel = new List<DayModel>();

            foreach (Day d in day)
            {
                DayModel.Add(Factory.Create(d));
            }
            return DayModel;
        }


        public IHttpActionResult Post(DayModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                if (model == null) return NotFound();
                else {
                    Repository.Insert(Parser.Create(model,sch));
                    return Ok(model);
                }
            }
            catch (Exception ex) {
                return BadRequest();
            }
            
        }
        public IHttpActionResult Put(int id, DayModel model)
        {
            var sch = Repository.BaseContext();
            try {
                Day day = Repository.Get(id);
                if (day==null || model == null) return NotFound();
                else {
                    Repository.Update(Parser.Create(model,sch), id);
                    return Ok(model);
                }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Delete(int id)
        {

            try
            {
                Day day = Repository.Get(id);
                if (day == null) return NotFound();
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

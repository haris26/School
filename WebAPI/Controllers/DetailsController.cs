﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using System.Web;

namespace WebAPI.Controllers
{
    public class DetailsController : BaseController<Detail>
    {
        public DetailsController(Repository<Detail> depo) : base(depo)
        { }

        public IList<DetailModel> GetAll(int page = 0)
        {
            int PageSize = 100;
            var query = Repository.Get().OrderBy(x => x.Day.Date)
                                        .ThenBy(x => x.Day.Person.LastName);

            int TotalPages = (int)Math.Ceiling
                            ((double)query.Count() / PageSize);
            IList<DetailModel> details = query.Skip(PageSize * page)
                                              .Take(PageSize).ToList()
                                              .Select(x => Factory.Create(x))
                                              .ToList();
            var PageHeader = new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages
            };

            HttpContext.Current.Response.Headers.Add("Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PageHeader));
            return details;
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Detail detail = Repository.Get(id);
                if (detail == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(detail));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Post(DetailModel model)
        {
            var sch = Repository.BaseContext();

            //try
            //{
            //    if (model == null) return NotFound();
            //    else {
            //        Repository.Insert(Parser.Create(model, sch));
            //        return Ok(model);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest();
            //}{

            Repository<Day> days = new Repository<Day>(sch);
            var day = days.Get().Where(x => x.Person.Id == model.Person && x.Date == model.Date).FirstOrDefault();
            if (day == null)
            {
                days.Insert(Parser.Create(new DayModel()
                {
                    Person = model.Person,
                    Date = model.Date
                },sch));
                model.Day = day.Id;
                Repository.Insert(Parser.Create(model, sch));
            }
            else
            {
               // day = days.Get().Where(x => x.Person.Id == model.Person && x.Date == model.Date).FirstOrDefault();
                model.Day = day.Id;
                Repository.Insert(Parser.Create(model, sch));
            }
            return Ok(model);
        }

        public IHttpActionResult Put(int id, DetailModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                Detail detail = Repository.Get(id);
                if (detail == null || model == null) return NotFound();
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
                Detail detail = Repository.Get(id);
                if (detail == null)
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
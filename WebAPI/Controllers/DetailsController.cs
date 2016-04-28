using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;
using System.Web;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    public class DetailsController : BaseController<Detail>
    {
        public DetailsController(Repository<Detail> depo) : base(depo)
        { }

        public IList<DetailModel> GetAll(int page = 0)
        {
            int PageSize = 200;
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
                List<Detail> detail = Repository.Get().Where(x => x.Day.Person.Id == id).ToList();
                if (detail == null)
                    return NotFound();
                else
                {
                    List<DetailModel> DetailModel = new List<DetailModel>();
                    foreach (Detail d in detail)
                    {
                        DetailModel.Add(Factory.Create(d));

                    }
                    return Ok(DetailModel);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(DetailModel model)
        {
            var sch = Repository.BaseContext();
            int deadline = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["deadline"]);

            try
            {
                if (model == null) return NotFound();
                else
                {
                    DateTime DetailDate = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day);
                    Repository<Day> days = new Repository<Day>(sch);
                    var day = days.Get().Where(x => x.Person.Id == model.Person && x.Date == DetailDate).FirstOrDefault();
                    if (day == null)
                    {
                        days.Insert(Parser.Create(new DayModel()
                        {
                            Person = model.Person,
                            Date = DetailDate

                        }, sch));
                        day = days.Get().Where(x => x.Person.Id == model.Person && x.Date == DetailDate).FirstOrDefault();
                        model.Day = day.Id;
                        Repository.Insert(Parser.Create(model, sch));
                        if (model.Team == 4 || model.TeamName == "Day Off")
                        {
                            Mail.SendMail("dzanang@gmail.com", "An employee has taken a Day Off", "Dear Azra! One of your employees" + model.PersonName + "has taken a Day Off");
                        }

                        
                        if (DateTime.Now.Day < deadline && DateTime.Now.Day > 1)
                        {
                            Mail.SendMail("dzanang@gmail.com", "Deadline is soon", "Please fill in your time for last month!");
                        }
                    }
                    else
                    {
                        model.Day = day.Id;
                        Repository.Insert(Parser.Create(model, sch));
                        if (model.Team == 4 || model.TeamName == "Day Off")
                        {
                            Mail.SendMail("dzanang@gmail.com", "An employee has taken a Day Off", "Dear Azra! One of your employees " + model.PersonName + " has taken a Day Off");
                        }

                        if (DateTime.Now.Day < deadline && DateTime.Now.Day > 1)
                        {
                            Mail.SendMail("dzanang@gmail.com", "Deadline is soon", "Please fill in your time for last month!");
                        }
                    }
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int id, DetailModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                Detail detail = Repository.Get(id);
                if (detail == null || model == null) return NotFound();
                else
                {
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
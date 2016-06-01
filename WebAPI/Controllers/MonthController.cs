using Database;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Services;
using WebAPI.Helpers;
using WebAPI.Models;
using System;
using System.Configuration;

namespace WebAPI.Controllers
{

    public class MonthController : BaseController<Person>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public MonthController(Repository<Person> depo) : base(depo)
        { }


        public IList<MonthModel> GetByMonth(int id = 0)
        {
            int month = id;

            if (month == 0)
            {
                string deadline = System.Configuration.ConfigurationManager.AppSettings["deadline"];
                if (DateTime.Now.Day <= Convert.ToInt32(deadline))
                    month = DateTime.Now.Month;
                //else month = DateTime.Now.Month;
            }
            var people = Repository.Get().OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

            List<MonthModel> list = new List<MonthModel>();

            foreach (var p in people)
            {
                foreach (var day in p.Days.ToList())
                {
                    if (day.Date.Month != month)
                        p.Days.Remove(day);
                }
                list.Add(MonthList.Create(p, month));
            }
            return list;
        }

        //public IList<MonthModel> GetByMonth(int id = 0)
        //{
        //    int month = id;

        //    if (month == 0)
        //    {
        //        string deadline = System.Configuration.ConfigurationManager.AppSettings["deadline"];
        //        if (DateTime.Now.Day <= Convert.ToInt32(deadline))
        //            month = DateTime.Now.Month - 1;
        //        else month = DateTime.Now.Month;
        //    }
        //    var people = Repository.Get().OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

        //    List<MonthModel> list = new List<MonthModel>();

        //    foreach (var p in people)
        //    {
        //        foreach (var day in p.Days.ToList())
        //        {
        //            if (day.Date.Month != month)
        //                p.Days.Remove(day);
        //        }
        //        list.Add(MonthList.Create(p, month));
        //    }
        //    return list;
        //}


        public IList<MonthModel> GetByMonth( int PageSize, int page, int id = 0)
        {
            int month = id;

            if (month == 0)
            {
                string deadline = System.Configuration.ConfigurationManager.AppSettings["deadline"];
                if (DateTime.Now.Day <= Convert.ToInt32(deadline))
                    month = DateTime.Now.Month - 1;
                else month = DateTime.Now.Month;
            }
            var people = Repository.Get().OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            
            List<MonthModel> list = new List<MonthModel>();

            foreach (var p in people)
            {
                foreach (var day in p.Days.ToList())
                {
                    if (day.Date.Month != month)
                        p.Days.Remove(day);
                }
                list.Add(MonthList.Create(p, month));
            }
            int TotalPages = (int)Math.Ceiling((double)list.Count() / PageSize);
            IList<MonthModel> months = list.Skip(PageSize * page)
                                              .Take(PageSize).ToList();
                                             
            var PageHeader = new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages
            };
            return months;
            
        }
    }
}

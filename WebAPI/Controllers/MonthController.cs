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

        //public IList<MonthModel> Get()

        //{

        //    var people = Repository.Get().OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
        //                .ToList();


        //    List<MonthModel> list = new List<MonthModel>();
        //    foreach (var p in people)
        //    {
        //        list.Add(MonthList.Create(p));

        //    }
        //    return list;
        //}


        public IList<MonthModel> Get(int id=0)
        {
           int month = id;
            if (month ==0) {
                string deadline = System.Configuration.ConfigurationManager.AppSettings["deadline"];
                if (DateTime.Now.Day<= Convert.ToInt32(deadline))
                month = DateTime.Now.Month-1;
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
            return list;
        }
    }
}

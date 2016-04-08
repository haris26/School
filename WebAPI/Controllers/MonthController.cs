using Database;

using System.Collections.Generic;
using System.Linq;
using WebAPI.Services;
using WebAPI.Helpers;
using WebAPI.Models;
using System;

namespace WebAPI.Controllers
{

    public class MonthController : BaseController<Person>
    {
        SchoolIdentity ident = new SchoolIdentity();

        public MonthController(Repository<Person> depo) : base(depo)
        { }

        public IList<MonthModel> Get()
        {
            var people = Repository.Get().OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                        .ToList();

            List<MonthModel> list = new List<MonthModel>();
            foreach (var p in people)
            {               
                    foreach (var day in p.Days.ToList())
                    {
                        if (day.Date.Month != DateTime.Now.Month)
                            p.Days.Remove(day);
                    }
                    list.Add(MonthList.Create(p, DateTime.Now.Month));
                }
            return list;
        }

        public IList<MonthModel> GetByMonth(int month)
        {

            var people = Repository.Get().OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                        .ToList();

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

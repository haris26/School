//using Database;
//using System.Collections.Generic;
//using System.Linq;
//using WebAPI.Services;
//using WebAPI.Helpers;
//using WebAPI.Models;
//using System;
//using System.Configuration;
//using System.Web.Configuration;

//namespace WebAPI.Controllers
//{
//    public class PrsnController : BaseController<Person>
//    {
//        SchoolIdentity ident = new SchoolIdentity();

//        public PrsnController(Repository<Person> depo) : base(depo)
//        { }

//        public IList<PrsnModel> Get()
//        {
//            int month;
//            string deadline = System.Configuration.ConfigurationManager.AppSettings["deadline"];
//            if (DateTime.Now.Day <= Convert.ToInt32(deadline))
//                month = DateTime.Now.Month - 1;
//            else month = DateTime.Now.Month;
//            var teams = Repository.Get().OrderBy(x => x.FirstName)
//                        .ToList();

//            List<PrsnModel> list = new List<PrsnModel>();
//            foreach (var t in teams)
//            {
//                foreach (var day in t.Days.ToList())
//                {
//                    if (day.Date.Month != month) //making the default landing page api/listteam to refer to current month
//                    {
//                        t.Days.Remove(day);
//                    }
//                }
//                list.Add(PersonHelper.Create(t, month));
//            }
//            return list;
//        }

//        public IList<PrsnModel> GetByMonth(int month)
//        {
//            var teams = Repository.Get().OrderBy(x => x.FirstName).ToList();
//            Engagement eng = new Engagement();
//            List<PrsnModel> list = new List<PrsnModel>();
//            foreach (var t in teams)
//            {
//                foreach (var day in t.Days.ToList())  //making sure only details included into the month we have forwarded are included, and everthying
//                {                                        //else is hidden
//                    if (day.Date.Month != month)
//                    {
//                        t.Days.Remove(day);
//                    }
//                }
//                list.Add(PersonHelper.Create(t, month));
//            }
//            return list;
//        }
//    }
//}
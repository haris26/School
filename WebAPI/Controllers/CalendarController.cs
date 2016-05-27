using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Globalization;
using System.Web.Http;
using Database;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CalendarController : BaseController<Person>
    {
        public CalendarController(Repository<Person> depo) : base(depo)
        { }
    [Route("api/calendar/{person}/{year}/{month}")]
    public IHttpActionResult Get(int person, int year, int month)
        {
            MonthModel1 result1;
            using (SchoolContext context = new SchoolContext())
            {
                result1 = new MonthModel1()
                {
                    Team = context.People.Find(person).FirstName,
                    Year = year,
                    Month = month
                };
                var query = context.People.Where(x => x.Id == person)
                                           .GroupBy(x => x.Id).ToList();

                    foreach (var item in query)
                    {
                        MonthWork work = new MonthWork(year, month)
                        {
                            Id = person
                          
                        };
                        var days = context.Days.Where(x => x.Date.Month == month && x.Date.Year == year && x.Person.Id == person).ToList();


                        foreach (var d in days)
                        {
                            int index = d.Date.Day - 1;
                            work.Days[index].Hours = (int)d.WorkTime;
                            work.Days[index].Class = (d.WorkTime > 0) ? "WorkTime" : "Vacation";

                       // var details = context.Details.Where(x => x.Day.Id == d.Id).ToList();
                           
                        foreach (var detail in d.Details)
                        {
                           work.Days[index].Details.Add(new DetailModel() { WorkTime = detail.WorkTime, Description = detail.Description, TeamName = detail.Team.Name, Date = detail.Day.Date });
                        }
                    }

                   
                    result1.Lista.Add(work);
                    }
            }

            return Ok(result1);

        }

    }

    public class MonthModel1         // model izvjestaja za jedan mjesec 
    {
        public MonthModel1()
        {
            Lista = new List<MonthWork>();
        }
        public string Team { get; set; }                // oznaka projekta
        public int Year { get; set; }                   // godina za koju se radi izvjestaj
        public int Month { get; set; }                  // mjesec za koji se radi izvjestaj
        public List<MonthWork> Lista { get; set; }      // lista ostvarenih dana (sati) za pojedinog zaposlenika
    }
    public class Global
    {
        public static int Limit(int year, int month)
        {
            DateTime dt1 = new DateTime(year, month, 1);
            DateTime dt2 = dt1.AddMonths(1);
            TimeSpan ts = dt2 - dt1;
            return (int)ts.TotalDays;
        }
    };
    public class MonthWork          // model mjeseca za jednog zaposlenika
    {

        public MonthWork(int year, int month)               // konstruktor za mjesec
        {
            int Lim = Global.Limit(year, month);            // izracuna ukupan broj dana u mjesecu
            DateTime first = new DateTime(year, month, 1);  // prvi dan
            int Start = (int)first.DayOfWeek - 1;           // koji je to dan u sedmici (pon-ned)
            if (Start < 0) Start = 6;

            Skip = new MonthDetail[Start];
            for (int i = 0; i < Start; i++)                 // za dane koji prethode napravi prazan prostor
            {                                               // tako da imamo pocetak mjeseca npr u cetvrtak
                Skip[i] = new MonthDetail()
                {
                    Day = 0,
                    Class = "empty",
                    Hours = 0
                };
            }

            Days = new MonthDetail[Lim];
            for (int i = 0; i < Lim; i++)                               // citav mjesec popuni praznim danima tako da kroz program popunjava samo dane za koje postoji unos
            {
                DateTime curDat = new DateTime(year, month, i + 1);
                Days[i] = new MonthDetail()
                {
                    Day = i + 1,
                    Hours = 0
                };
                if (curDat.DayOfWeek == DayOfWeek.Saturday || curDat.DayOfWeek == DayOfWeek.Sunday) Days[i].Class = "weekend"; else Days[i].Class = "noentry";
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public MonthDetail[] Skip { get; set; }
        public MonthDetail[] Days { get; set; }
    }

    public class MonthDetail        // model jednog dana
    {
        public MonthDetail()
        {
            Details = new List<DetailModel>();
            Detail detail = new Detail();
        }
        public int Day { get; set; }            // redni broj dana
        public string Class { get; set; }       // klasa - tip (radni dan, vikend, day off ...)
        public int Hours { get; set; }          // broj radnih sati za taj dan
        public IList<DetailModel> Details { get; set; }
    }

}
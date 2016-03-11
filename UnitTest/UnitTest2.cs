using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
using System.Linq;

namespace UnitTest
{
    [TestClass]

    public class DaysTest
    {
        [TestMethod]
        public void DayTestAdd()
        {
            //Arrange
            SchoolContext context = new SchoolContext();
            DayUnit days = new DayUnit(context);

            Repository<Person> people = new Repository<Person>(context);
            int N = days.Get().Count();

            //Act

            //days.Insert(new Day()
            //{
            //    Date = Convert.ToDateTime("21/10/1985"),
            //    WorkTime = 8,
            //    PtoTime = 6,
            //    EntryStatus = EntryStatus.Locked,
                
            //});

            Day day = new Day();
            day.Date = Convert.ToDateTime("22/11/1986");
            day.WorkTime = 7;
            day.PtoTime = 5;
            day.EntryStatus = EntryStatus.Unlocked;
            day.Person = people.Get(11);

            days.Insert(day);

            DateTime Date = day.Date;
            double WorkTime = day.WorkTime;
            double PtoTime = day.PtoTime;


            day.Date = Convert.ToDateTime("23/12/1987");
            day.WorkTime = 2;
            day.PtoTime = 1;
            day.EntryStatus = EntryStatus.Unlocked;
            day.Person = people.Get(11);

            days.Update(day, day.Id);

            

            int id = days.Get().Max(x => x.Id);
            //days.Delete(id);
            int M = days.Get().Count();

            //Assert
            //Assert.AreEqual(M, N);
            Assert.AreNotEqual(WorkTime, day.WorkTime);
            Assert.AreNotEqual(PtoTime, day.PtoTime);

        }
    }
}

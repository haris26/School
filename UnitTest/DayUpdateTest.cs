using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
using TimeTracking;

namespace UnitTest
{
    [TestClass]
    public class DayUpdateTest
    {
        [TestMethod]
        public void TestUpdate()
        {
            //Arange
            SchoolContext context = new SchoolContext();
            DayUnit days = new DayUnit(context);
            Repository<Person> people = new Repository<Person>(context);

            Day day = new Day();
            day.Date = Convert.ToDateTime("3/7/2016");
            day.WorkTime = 8;
            day.PtoTime = 0;
            day.EntryStatus = EntryStatus.Locked;
            day.Person = people.Get(10);

            days.Insert(day);

            DateTime date = day.Date;
            double workTime = day.WorkTime;
            double ptoTime = day.PtoTime;
            

            day.Date = Convert.ToDateTime("3/5/2016");
            day.WorkTime = 0;
            day.PtoTime = 8;
            day.EntryStatus = EntryStatus.Unlocked;
            day.Person = people.Get(10);

            days.Update(day, day.Id);
            Assert.AreNotEqual(date, day.Date);
            Assert.AreNotEqual(workTime, day.WorkTime);

            days.Delete(day.Id);

        }
    }
}

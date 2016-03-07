using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {//Arrange
            SchoolContext context = new SchoolContext();
            Repository<Day> days = new Repository<Day>(context);
            Repository<Person> people = new Repository<Person>(context);
            int N = days.Get().Count();

            //Act
            days.Insert(new Day()
            {
                Date = Convert.ToDateTime("3/7/2016"),
                WorkTime = 5,
                PtoTime = 5,
                EntryStatus = EntryStatus.Unlocked,
                Person=people.Get(2)
                
            });
            int id = days.Get().Max(x => x.Id);
            days.Delete(id);
            int M = days.Get().Count();

            //Assert
            Assert.AreEqual(M, N);
        }
    }
}

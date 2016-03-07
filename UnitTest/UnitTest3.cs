using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            SchoolContext context = new SchoolContext();
            DetailUnit details = new DetailUnit(context);
            DayUnit days = new DayUnit(context);
            Repository<Team> teams = new Repository<Team>(context);
            int N = details.Get().Count();

            //Act
            details.Insert(new Detail()
            {
                Day=days.Get(5),
                WorkTime = 8,
                BillTime=8,
                Description="testni descr",
                Team=teams.Get(1)

            });
            int id = details.Get().Max(x => x.Id);
            details.Delete(id);
            int M = details.Get().Count();

            //Assert
            Assert.AreEqual(M, N);

        }
    }
}

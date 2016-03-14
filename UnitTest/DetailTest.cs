using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class DetailTest
    {
        [TestMethod]
        public void TestAdd()
        {
            //Arrange
            SchoolContext context = new SchoolContext();
            Repository<Detail> details = new Repository<Detail>(context);
            DayUnit days = new DayUnit(context);
            Repository<Team> teams = new Repository<Team>(context);
            int N = details.Get().Count();

            //Act

            details.Insert(new Detail()
            {
                Day = days.Get(5),
                WorkTime = 8,
                BillTime = 6,
                Description = "Unit testing Example",
                Team = teams.Get(4)

            });

            
            

            var detail = details.Get(1238);
            detail.Day = days.Get(3);
            detail.WorkTime = 7;
            detail.BillTime = 5;
            detail.Description = "Unit test update";
            detail.Team = teams.Get(5);

            
            details.Update(detail, detail.Id);
            
            int id = details.Get().Max(x => x.Id);
            //details.Delete(id);
            int M = details.Get().Count();

            //Assert
            Assert.AreEqual(M, N);
        }
    }
}

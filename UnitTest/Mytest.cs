using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TimeTracking.Controllers;
using TimeTracking.Models;
namespace UnitTest
{
    [TestClass]
    public class Mytest
    {
        [TestMethod]
        public void MyMethod()
        {
            //Arrange
            SchoolContext context = new SchoolContext();
            DetailUnit details = new DetailUnit(context);
            DayUnit days = new DayUnit(context);
            Repository<Team> teams = new Repository<Team>(context);

            Detail detail = new Detail();
            detail.Day= days.Get(5);
            detail.WorkTime = 5;
            detail.BillTime = 5;
            detail.Description = "first descr";
            detail.Team = teams.Get(1);

            details.Insert(detail);
           double workTime = detail.WorkTime;
           double billTime = detail.BillTime;

            //Act
            //var newDetail = details.Get(5);
            detail.Day = days.Get(5);
            detail.WorkTime = 8;
            detail.BillTime = 8;
           detail.Description = "editted descr";
            detail.Team = teams.Get(1);

            details.Update(detail, detail.Id);
         

            //Assert
           Assert.AreNotEqual(workTime, detail.WorkTime);
            Assert.AreNotEqual(billTime, detail.BillTime);

            details.Delete(detail.Id);
        }
    }
}

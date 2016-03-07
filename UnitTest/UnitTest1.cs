using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Repository<Team> teams = new Repository<Team>(new SchoolContext());
            int N = teams.Get().Count();

            //Act
            teams.Insert(new Team()
            {
                Name="test Project",
                Description="Unit test",
                Type=ProjectType.External
            });
            int id = teams.Get().Max(x=> x.Id);
            teams.Delete(id);
            int M = teams.Get().Count();

            //Assert
            Assert.AreEqual(M,N);

        }
    }
}

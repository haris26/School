using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class RepositoryTest
    {
        
        [TestMethod]
        public void TestAdd()
        {
            Repository<Team> teams = new Repository<Team>(new SchoolContext());
            int N = teams.Get().Count();
            teams.Insert(new Team()
            {
                Name = "Test Project",
                Description = "Unit Test",
                Type = ProjectType.External
            });
            int id = teams.Get().Max(x => x.Id);
            teams.Delete(id);
            int M = teams.Get().Count();
            Assert.AreEqual(M, N);
        }
    }
    [TestClass]
    public class CharacteriticTest
    {
        private SchoolContext context = new SchoolContext();
        [TestMethod]
        public void TestAddCharacteristics()
        {
            Repository<Characteristic> charac = new Repository<Characteristic>(context);
            int N = charac.Get().Count();
            charac.Insert(new Characteristic()
            {
                Name = "Test Project",
                Value = "Unit Test",
                Resource =new ResourceUnit(context).Get(1)
            });
            int id = charac.Get().Max(x => x.Id);
            charac.Delete(id);
            int M = charac.Get().Count();
            Assert.AreEqual(M, N);
        }
        [TestMethod]
        public void TestEditCharacteristics()
        {
            Repository<Characteristic> charac = new Repository<Characteristic>(context);
            Characteristic newChr = new Characteristic()
            {
                Name = "name",
                Value = "value",
                Resource = new ResourceUnit(context).Get(1)
            };
            charac.Insert(newChr);
            string name = newChr.Name;
            string value =newChr.Value;
            newChr.Name = "test name ";
            newChr.Value = "test value ";
            charac.Update(newChr, newChr.Id);
            Assert.AreNotEqual(name, newChr.Name);
            Assert.AreNotEqual(value, newChr.Value);
            charac.Delete(newChr.Id);
        }
        [TestMethod]
        public void TestDeleteCharacteristics()
        {
            Repository<Characteristic> charac = new Repository<Characteristic>(context);
            int N = charac.Get().Count();
            Characteristic newChr = new Characteristic()
            {
                Name = "name",
                Value = "value",
                Resource = new ResourceUnit(context).Get(1)
            };
            charac.Insert(newChr);
            charac.Delete(newChr.Id);
            int M = charac.Get().Count() ;
            Assert.AreEqual(N, M);
       
        }
    }
}

using System;
<<<<<<< HEAD
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
using System.Linq;
=======
using System.Linq;
using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
>>>>>>> 4ce30205bf0afe2a1131409efbdb42cc85ac63e8

namespace UnitTest
{
    [TestClass]
    public class RepositoryTest
    {
<<<<<<< HEAD
        
        [TestMethod]
        public void TestAdd()
        {
            Repository<Team> teams = new Repository<Team>(new SchoolContext());
            int N = teams.Get().Count();
=======
        [TestMethod]
        public void TestAdd()
        {
            // Arrange
            Repository<Team> teams = new Repository<Team>(new SchoolContext());
            int N = teams.Get().Count();

            // Act
>>>>>>> 4ce30205bf0afe2a1131409efbdb42cc85ac63e8
            teams.Insert(new Team()
            {
                Name = "Test Project",
                Description = "Unit Test",
                Type = ProjectType.External
            });
            int id = teams.Get().Max(x => x.Id);
            teams.Delete(id);
            int M = teams.Get().Count();
<<<<<<< HEAD
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
       
=======

            // Assert
            Assert.AreEqual(M, N);
        }
        [TestMethod]
        public void ResourceTest()
        {
            SchoolContext context = new SchoolContext();
            ResourceUnit resources = new ResourceUnit(context);
            Repository<ResourceCategory> resCat = new Repository<ResourceCategory>(context);
            int N = resources.Get().Count();

            resources.Insert(new Resource()
            {
                Name = "Resource test",
                Status = ReservationStatus.Available,
                ResourceCategory = resCat.Get(1)
            });
            int id = resources.Get().Max(x => x.Id);
            resources.Delete(id);
            int M = resources.Get().Count();

            Assert.AreEqual(M, N);
        }

        [TestMethod]
        public void TestUpdateResource()
        {
            SchoolContext context = new SchoolContext();
            ResourceUnit resources = new ResourceUnit(context);

            CreateTestRes();
            var oldRes = resources.Get().ToList().Last();
            string oldName = oldRes.Name;
            ReservationStatus oldStatus = oldRes.Status;

            oldRes.Name = "edit test res";
            oldRes.Status = ReservationStatus.Reserved;
            resources.Update(oldRes, oldRes.Id);
            
            Assert.AreNotEqual(oldName, oldRes.Name);
            Assert.AreNotEqual(oldStatus, oldRes.Status);
            resources.Delete(oldRes.Id);
        }

        public void CreateTestRes()
        {
            SchoolContext context = new SchoolContext();
            ResourceUnit resources = new ResourceUnit(context);

            Resource newRes = new Resource()
            {
                Name = "test res",
                ResourceCategory = new Repository<ResourceCategory>(context).Get(1),
                Status = ReservationStatus.Available
            };
            resources.Insert(newRes);
        }

        [TestMethod]
        public void TestDeleteResource()
        {
            SchoolContext context = new SchoolContext();
            ResourceUnit resources = new ResourceUnit(context);

            int oldCount = resources.Get().Count();
            CreateTestRes();
            int id = resources.Get().Max(x => x.Id);
            resources.Delete(id);
            int newCount = resources.Get().Count();

            Assert.AreEqual(oldCount, newCount);
        }

        [TestMethod]
        public void TestAddEvent()
        {
            SchoolContext context = new SchoolContext();
            EventUnit events = new EventUnit(context);
            int N = events.Get().Count();

            CreateTestEvent();
            int maxId = events.Get().Max(x => x.Id);
            events.Delete(maxId);
            int M = events.Get().Count();

            Assert.AreEqual(M, N);
        }

        public void CreateTestEvent()
        {
            SchoolContext context = new SchoolContext();
            ResourceUnit resources = new ResourceUnit(context);
            Repository<Person> users = new Repository<Person>(context);
            EventUnit events = new EventUnit(context);

            CreateTestRes();
            var resource = resources.Get().ToList().Last();
            var user = users.Get(5);

            Event ev = new Event()
            {
                EventTitle = "test event",
                Resource = resource,
                User = user,
                EventStart = System.DateTime.Now,
                EventEnd = System.DateTime.Today
            };
            events.Insert(ev);
        }

        [TestMethod]
        public void TestUpdateEvent()
        {
            SchoolContext context = new SchoolContext();
            EventUnit events = new EventUnit(context);

            CreateTestEvent();
            var oldEvent = events.Get().ToList().Last();
            string oldTitle = oldEvent.EventTitle;
            DateTime oldStart = oldEvent.EventStart;

            oldEvent.EventTitle = "update test event";
            oldEvent.EventStart = System.DateTime.Now;
            events.Update(oldEvent, oldEvent.Id);

            Assert.AreNotEqual(oldTitle, oldEvent.EventTitle);
            Assert.AreNotEqual(oldStart, oldEvent.EventStart);
            events.Delete(oldEvent.Id);

>>>>>>> 4ce30205bf0afe2a1131409efbdb42cc85ac63e8
        }
    }
}

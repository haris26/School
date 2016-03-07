using System;
<<<<<<< HEAD
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
using System.Linq;
using System.Collections.Generic;
=======
using System.Linq;
using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
>>>>>>> 3458eded02a15721a6bf1a1537efa5732455ae4f

namespace UnitTest
{
    [TestClass]
<<<<<<< HEAD
    public class RepositoryTest
    {
        [TestMethod]
        public void TestAdd()
        {
            // Arrange
            Repository<Team> teams = new Repository<Team>(new SchoolContext());
            int N = teams.Get().Count();

            // Act
            teams.Insert(new Team()
            {
                Name = "Test Project",
                Description = "Unit Test",
=======
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd(){
            //Arrange
            Repository<Team> teams = new Repository<Team>(new SchoolContext());
            int N = teams.Get().Count();

            //Act
            teams.Insert(new Team()
            {
                Name = "Test project",
                Description = "Unit test",
>>>>>>> 3458eded02a15721a6bf1a1537efa5732455ae4f
                Type = ProjectType.External
            });
            int id = teams.Get().Max(x => x.Id);
            teams.Delete(id);
            int M = teams.Get().Count();

<<<<<<< HEAD
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
=======
            //Assert
            Assert.AreEqual(M, N);
        }

        [TestMethod]
        public void TestAddResource()
        {
            SchoolContext context = new SchoolContext();
            ResourceUnit resources = new ResourceUnit(context);
            int N = resources.Get().Count();

            ResourceCategory cat = new Repository<ResourceCategory>(context).Get(1);
            resources.Insert(new Resource()
            {
                Name = "test phone",
                ResourceCategory = cat,
                Status = ReservationStatus.Available
>>>>>>> 3458eded02a15721a6bf1a1537efa5732455ae4f
            });
            int id = resources.Get().Max(x => x.Id);
            resources.Delete(id);
            int M = resources.Get().Count();

            Assert.AreEqual(M, N);
        }
<<<<<<< HEAD
        [TestMethod]
        public void ResourceCategoryTest()
        {
            Repository<ResourceCategory> resourceCat = new Repository<ResourceCategory>(new SchoolContext());
            int N = resourceCat.Get().Count();

            resourceCat.Insert(new ResourceCategory()
            {
                CategoryName = "Cars"
            });
            int id = resourceCat.Get().Max(x => x.Id);
            resourceCat.Delete(id);
            int M = resourceCat.Get().Count();

            Assert.AreEqual(M,N);
        }
        [TestMethod]
        public void ResourceUpdate()
        {
            Repository<Resource> resource = new Repository<Resource>(new SchoolContext());
            Resource res = new Resource()
            {
                Name = "Haris Proba",
                Status = ReservationStatus.Available
            };
            resource.Insert(res);
            int maxId = resource.Get().Max(x => x.Id);
            var oldRes = resource.Get(maxId);
            string oldStatus = oldRes.Status.ToString();
            oldRes.Status = ReservationStatus.Reserved;
            resource.Update(oldRes, oldRes.Id);

            Assert.AreNotEqual(oldStatus, oldRes.Status);
            resource.Delete(res.Id);
=======

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

>>>>>>> 3458eded02a15721a6bf1a1537efa5732455ae4f
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
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
                Type = ProjectType.External
            });
            int id = teams.Get().Max(x => x.Id);
            teams.Delete(id);
            int M = teams.Get().Count();

            // Assert
            Assert.AreEqual(M, N);
        }


        [TestMethod]
        public void TestAddRequest()
        {
            // Arrange
            SchoolContext context = new SchoolContext();
            Repository<Request> requests = new Repository<Request>(context);
            Repository<Person> people = new Repository<Person>(context);
            Repository<Asset> assets = new Repository<Asset>(context);

            int N = requests.Get().Count();

            // Act
            requests.Insert(new Request()
            {
                requestType = RequestType.Equipment,
                RequestMessage = "Need a new laptop",
                RequestDescription = "I need a new laptop asap",
                RequestDate = new DateTime(2016, 3, 5),
                Status = RequestStatus.AvaitingForApprovale,
                User = people.Get().Where(x => x.FirstName == "Dalila").FirstOrDefault(),
                Asset = assets.Get().Where(x => x.Model == "Inspiron 13 7347").FirstOrDefault()
            
                
            });
            int id = requests.Get().Max(x => x.Id);
            requests.Delete(id);
            int M = requests.Get().Count();

            // Assert
            Assert.AreEqual(M, N);
        }

        [TestMethod]
        public void TestUpdateRequest()
        {
            SchoolContext context = new SchoolContext();
            Repository<Request> requests = new Repository<Request>(context);
            Repository<Person> people = new Repository<Person>(context);
            Repository<Asset> assets = new Repository<Asset>(context);

            Request req = new Request()
            {
                requestType = RequestType.Equipment,
                RequestMessage = "Need a new laptop",
                RequestDescription = "I need a new laptop asap",
                RequestDate = new DateTime(2016, 3, 5),
                Status = RequestStatus.AvaitingForApprovale,
                User = people.Get().Where(x => x.FirstName == "Dalila").FirstOrDefault(),
                Asset = assets.Get().Where(x => x.Model == "Inspiron 13 7347").FirstOrDefault()
            };

            requests.Insert(req);
            var oldReq = requests.Get(req.Id);
            string oldMessage = oldReq.RequestMessage;
            oldReq.RequestMessage = "Test message";
            requests.Update(oldReq, oldReq.Id);

            Assert.AreNotEqual(oldMessage, oldReq.RequestMessage);
        }

        [TestMethod]
        public void TestDeleteRequest()
        {
            SchoolContext context = new SchoolContext();
            Repository<Request> requests = new Repository<Request>(context);
            Repository<Person> people = new Repository<Person>(context);
            Repository<Asset> assets = new Repository<Asset>(context);

            int N = requests.Get().Count();

            Request req = new Request()
            {
                requestType = RequestType.Equipment,
                RequestMessage = "Need a new laptop",
                RequestDescription = "I need a new laptop asap",
                RequestDate = new DateTime(2016, 3, 5),
                Status = RequestStatus.AvaitingForApprovale,
                User = people.Get().Where(x => x.FirstName == "Dalila").FirstOrDefault(),
                Asset = assets.Get().Where(x => x.Model == "Inspiron 13 7347").FirstOrDefault()
            };

            requests.Insert(req);
            int id = requests.Get().Max(x => x.Id);
            requests.Delete(id);
            int M = requests.Get().Count();
            

            Assert.AreEqual(M, N);
        }
    }
}

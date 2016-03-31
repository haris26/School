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
        static SchoolContext context = new SchoolContext();


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

        public void TestAdd1()
        { // Arrange
            SchoolContext cont = new SchoolContext();
            Repository<Person> people = new Repository<Person>(cont);
            Repository<Asset> assets = new Repository<Asset>(cont);

            int N = assets.Get().Count();
           
            // Act
            assets.Insert(new Asset()
            {

                DateOfTrade = new DateTime(2016, 2, 1),
                Name = "Name asset",
                Price = 157.87,
                SerialNumber = "025477aasdds",
                User =people.Get(1),
                 Vendor = "Dell",
                Status = AssetStatus.Assigned,
                Model="569IS",


            });
            int id = assets.Get().Max(x => x.Id);
            assets.Delete(id);
            int M = assets.Get().Count();

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
        public void UpdateTest()
        {
            SchoolContext cont = new SchoolContext();
            Repository<Person> people = new Repository<Person>(cont);
            Repository<AssetCategory> categories = new Repository<AssetCategory>(cont);
            Repository<Asset> assets = new Repository<Asset>(cont);

            int N = assets.Get().Count();

            // Act
            Asset asset = new Asset()
            {
                DateOfTrade = new DateTime(2016, 2, 1),
                Name = "Name asset",
                Price = 157.87,
                SerialNumber = "025477aasdds",
                AssetCategory = categories.Get(1),

                Vendor = "Dell",
                Status = AssetStatus.Assigned,
                Model = "inspiron i5K6",
                User = people.Get(1),

            };
            assets.Insert(asset);
            var oldasset = assets.Get(asset.Id);
            string oldModel = oldasset.Model;
            oldasset.Model= "Test";
            assets.Update(oldasset, oldasset.Id);

            Assert.AreNotEqual(oldModel, oldasset.Model);


        }


        public void RemoveTest()
        { // Arrange
            SchoolContext cont = new SchoolContext();
            Repository<Person> people = new Repository<Person>(cont);
            Repository<Asset> assets = new Repository<Asset>(cont);
            Repository<AssetCategory> categories = new Repository<AssetCategory>(cont);

            int N = assets.Get().Count();

            // Act
            assets.Insert(new Asset()
            {

                DateOfTrade = new DateTime(2016, 2, 1),
                Name = "Name asset",
                Price = 157.87,
                SerialNumber = "025477aasdds",
                User = people.Get(1),
                Vendor = "Dell",
                Status = AssetStatus.Assigned,
                Model = "569IS",
                AssetCategory = categories.Get(1),


            });
            int id = assets.Get().Max(x => x.Id);
            assets.Delete(id);
            int M = assets.Get().Count();
        }
            // Assert

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


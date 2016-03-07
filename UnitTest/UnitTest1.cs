using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
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
                Status = AssetStatus.Active,
                Model="569IS",


            });
            int id = assets.Get().Max(x => x.Id);
            assets.Delete(id);
            int M = assets.Get().Count();

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
                Status = AssetStatus.Active,
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
                User =people.Get(1),
                 Vendor = "Dell",
                Status = AssetStatus.Active,
                Model="569IS",
                AssetCategory=categories.Get(1),


            });
            int id = assets.Get().Max(x => x.Id);
            assets.Delete(id);
            int M = assets.Get().Count();

            // Assert
            Assert.AreEqual(M, N);
        }
    }
}


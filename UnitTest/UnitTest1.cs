using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
using System.Linq;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
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
                Type = ProjectType.External
            });
            int id = teams.Get().Max(x => x.Id);
            teams.Delete(id);
            int M = teams.Get().Count();

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
        }
    }
}

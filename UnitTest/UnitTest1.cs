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
        public void EducationTestAdd()
        {
            //Arrange
            Repository<Education> educations = new Repository<Education>(new SchoolContext());
            int N = educations.Get().Count();

            //Act
            educations.Insert(new Education()
            {
                Name = "Test Education",
                Type = EducationType.School
            });
            int id = educations.Get().Max(x => x.Id);
            educations.Delete(id);
            int M = educations.Get().Count();

            //Asert
            Assert.AreEqual(M, N);
        }

        [TestMethod]
        public void SkillCategoryTestAdd()
        {
            //Arrange
            Repository<SkillCategory> skillcategory = new Repository<SkillCategory>(new SchoolContext());
            int N = skillcategory.Get().Count();

            //Act
            skillcategory.Insert(new SkillCategory()
            {
                Name = "Test Skill Category"
            });
            int id = skillcategory.Get().Max(x => x.Id);
            skillcategory.Delete(id);
            int M = skillcategory.Get().Count();

            //Asert
            Assert.AreEqual(M, N);
        }

        [TestMethod]
        public void EmployeeSkillTestAdd()
        {
            SchoolContext context = new SchoolContext();
            //Arrange
            EmployeeSkillUnit employeeskill = new EmployeeSkillUnit(context);
            int N = employeeskill.Get().Count();

            //Act
            employeeskill.Insert(new EmployeeSkill()
            {
                Employee = new Repository<Person>(context).Get().FirstOrDefault(),
                Tool = new Repository<Tool>(context).Get().FirstOrDefault()
            });
            int id = employeeskill.Get().Max(x => x.Id);
            employeeskill.Delete(id);
            int M = employeeskill.Get().Count();

            //Asert
            Assert.AreEqual(M, N);
        }

        [TestMethod]
        public void EducationTestUpdate()
        {
            //Arrange
            Repository<Education> educations = new Repository<Education>(new SchoolContext());
            educations.Insert(new Education()
            {
                Name = "Test Education",
                Type = EducationType.School
            });

            int oldEduId = educations.Get().Max(x => x.Id);
            Education oldEdu = educations.Get(oldEduId);
            string oldName = oldEdu.Name;

            //Act
            oldEdu.Name = "updated name";

            educations.Update(oldEdu, oldEdu.Id);

            //Assert
            Assert.AreNotEqual(oldName, oldEdu.Name);

            educations.Delete(oldEduId);
        }

        [TestMethod]
        public void SkillCategoryTestUpdate()
        {
            //Arrange
            Repository<SkillCategory> skillcategory = new Repository<SkillCategory>(new SchoolContext());
            skillcategory.Insert(new SkillCategory()
            {
                Name = "Test Skill Category",
            });

            int oldSKId = skillcategory.Get().Max(x => x.Id);
            SkillCategory oldSK = skillcategory.Get(oldSKId);
            string oldName = oldSK.Name;

            //Act
            oldSK.Name = "updated name";

            skillcategory.Update(oldSK, oldSK.Id);

            //Assert
            Assert.AreNotEqual(oldName, oldSK.Name);

            skillcategory.Delete(oldSKId);
        }

        [TestMethod]
        public void EmployeeSkillTestUpdate()
        {
            SchoolContext context = new SchoolContext();

            //Arrange
            EmployeeSkillUnit empSkill = new EmployeeSkillUnit(context);

            empSkill.Insert(new EmployeeSkill()
            {
                Employee = new Repository<Person>(context).Get().FirstOrDefault(),
                Tool = new Repository<Tool>(context).Get().FirstOrDefault()
            });

            int oldEmpSkillId = empSkill.Get().Max(x => x.Id);
            EmployeeSkill oldEmpSkill = empSkill.Get(oldEmpSkillId);
            int Employee = oldEmpSkill.Employee.Id;

            //Act
            oldEmpSkill.Employee = new Repository<Person>(context).Get().ToList().Last();

            empSkill.Update(oldEmpSkill, oldEmpSkill.Id);

            //Assert
            Assert.AreNotEqual(Employee, oldEmpSkill.Employee.Id);

            empSkill.Delete(oldEmpSkillId);
        }            
    }
}

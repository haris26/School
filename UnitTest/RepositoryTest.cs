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
        public void TeamTestAdd()
        {
            //Arrange
            Repository<Team> teams = new Repository<Team>(new SchoolContext());
            int N = teams.Get().Count();

            //Act
            teams.Insert(new Team()
            {
                Name = "Test Project",
                Description = "Unit Test",
                Type = ProjectType.External
            });
            int id = teams.Get().Max(x => x.Id);
            teams.Delete(id);
            int M = teams.Get().Count();

            //Assert
            Assert.AreEqual(M, N);
        }

        [TestMethod]
        public void ToolTestAdd()
        {
            SchoolContext context = new SchoolContext();

            //Arrange
            ToolUnit tools = new ToolUnit(context);
            int N = tools.Get().Count();

            //Act
            tools.Insert(new Tool()
            {
                Name = "test tool",
                Category = new Repository<SkillCategory>(context).Get().FirstOrDefault()
            });

            int id = tools.Get().Max(x => x.Id);
            tools.Delete(id);
            int M = tools.Get().Count();

            //Assert
            Assert.AreEqual(M, N);
        }

        [TestMethod]
        public void ProjectSkillTestAdd()
        {
            SchoolContext context = new SchoolContext();

            //Arrange
            ProjectSkillUnit projSkill = new ProjectSkillUnit(context);
            int N = projSkill.Get().Count();

            //Act
            projSkill.Insert(new ProjectSkill()
            {
                Team = new Repository<Team>(context).Get().FirstOrDefault(),
                Tool = new Repository<Tool>(context).Get().FirstOrDefault(),
                Level = Level.Competent
            });

            int id = projSkill.Get().Max(x => x.Id);
            projSkill.Delete(id);
            int M = projSkill.Get().Count();

            //Assert
            Assert.AreEqual(M, N);
        }

        [TestMethod]
        public void EmployeeEducationTestAdd()
        {
            SchoolContext context = new SchoolContext();

            //Arrange
            EmployeeEducationUnit empEdu = new EmployeeEducationUnit(context);
            int N = empEdu.Get().Count();

            //Act
            empEdu.Insert(new EmployeeEducation()
            {
                Education = new Repository<Education>(context).Get().FirstOrDefault(),
                Employee = new Repository<Person>(context).Get().FirstOrDefault(),
                Reference = "www.somereference.ba"
            });

            int id = empEdu.Get().Max(x => x.Id);
            empEdu.Delete(id);
            int M = empEdu.Get().Count();

            //Assert
            Assert.AreEqual(M, N);
        }

        [TestMethod]
        public void ToolTestUpdate()
        {
            SchoolContext context = new SchoolContext();

            //Arrange
            ToolUnit tools = new ToolUnit(context);

            tools.Insert(new Tool()
            {
                Name = "test tool",
                Category = new Repository<SkillCategory>(context).Get().FirstOrDefault()
            });

            Tool oldTool = tools.Get().ToList().Last();
            string oldName = oldTool.Name;

            //Act
            oldTool.Name = "updated name";

            tools.Update(oldTool, oldTool.Id);

            //Assert
            Assert.AreNotEqual(oldName, oldTool.Name);

            tools.Delete(oldTool.Id);
        }

        [TestMethod]
        public void ProjectSkillTestUpdate()
        {
            SchoolContext context = new SchoolContext();

            //Arrange
            ProjectSkillUnit projSkills = new ProjectSkillUnit(context);

            projSkills.Insert(new ProjectSkill()
            {
                Team = new Repository<Team>(context).Get().FirstOrDefault(),
                Tool = new Repository<Tool>(context).Get().FirstOrDefault(),
                Level = Level.Competent
            });

            ProjectSkill oldProjSkill = projSkills.Get().ToList().Last();
            int oldTeamId = oldProjSkill.Team.Id;

            //Act
            oldProjSkill.Team = new Repository<Team>(context).Get().ToList().Last();

            projSkills.Update(oldProjSkill, oldProjSkill.Id);

            //Assert
            Assert.AreNotEqual(oldTeamId, oldProjSkill.Team.Id);

            projSkills.Delete(oldProjSkill.Id);
        }

        [TestMethod]
        public void EmployeeEducationTestUpdate()
        {
            SchoolContext context = new SchoolContext();

            //Arrange
            EmployeeEducationUnit empEdus = new EmployeeEducationUnit(context);

            empEdus.Insert(new EmployeeEducation()
            {
                Education = new Repository<Education>(context).Get().FirstOrDefault(),
                Employee = new Repository<Person>(context).Get().FirstOrDefault(),
                Reference = "www.somereference.ba"
            });

            EmployeeEducation oldEmpEdu = empEdus.Get().ToList().Last();
            int oldEmployee = oldEmpEdu.Employee.Id;

            //Act
            oldEmpEdu.Employee = new Repository<Person>(context).Get().ToList().Last();

            empEdus.Update(oldEmpEdu, oldEmpEdu.Id);

            //Assert
            Assert.AreNotEqual(oldEmployee, oldEmpEdu.Employee.Id);

            empEdus.Delete(oldEmpEdu.Id);
        }

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

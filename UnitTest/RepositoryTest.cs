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

    }
}

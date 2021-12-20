using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void CreateProjectTest()
        {
            ProjectData project = new ProjectData("UICreatedProject3");

            List<ProjectData> oldProjects = ProjectData.GetAll();

            app.Project.Create(project);

            Assert.AreEqual(oldProjects.Count + 1, app.Project.GetProjectCount());

            List<ProjectData> newProjects = ProjectData.GetAll();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test]
        public void CreateNewProjectAPI()
        {
            AccountData account = new AccountData("administrator", "administrator");
            ProjectData project = new ProjectData()
            {
                Name = "APICreatedProject2"
            };

            List<ProjectData> oldProjects = app.API.GetProjects(account);

            app.API.CreateNewProject(account, project);

            Assert.AreEqual(oldProjects.Count + 1, app.Project.GetProjectCount());

            List<ProjectData> newProjects = app.API.GetProjects(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
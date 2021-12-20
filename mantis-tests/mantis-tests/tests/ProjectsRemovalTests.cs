using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectsRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveProjectTest()
        {
            app.Project.IsProjectExist();

            List<ProjectData> oldProjects = ProjectData.GetAll();
            ProjectData toBeRemoved = oldProjects[0];

            app.Project.Remove(toBeRemoved);

            Assert.AreEqual(oldProjects.Count - 1, app.Project.GetProjectCount());

            List<ProjectData> newProjects = ProjectData.GetAll();

            oldProjects.RemoveAt(0);

            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData project in newProjects)
            {
                Assert.AreNotEqual(project.Id, toBeRemoved.Id);
            }
        }

        [Test]
        public void ProjectsRemovalAPI()
        {
            AccountData account = new AccountData("administrator", "administrator");
            ProjectData project = new ProjectData()
            {
                Name = "test"
            };

            List<ProjectData> oldProjects = app.API.GetProjects(account); ;
            ProjectData toBeRemoved = oldProjects[0];

            app.API.IsProjectExist(oldProjects, account, project);

            app.Project.Remove(toBeRemoved);

            Assert.AreEqual(oldProjects.Count - 1, app.Project.GetProjectCount());

            List<ProjectData> newProjects = ProjectData.GetAll();

            oldProjects.RemoveAt(0);

            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData newProject in newProjects)
            {
                Assert.AreNotEqual(newProject.Id, toBeRemoved.Id);
            }
        }
    }
}

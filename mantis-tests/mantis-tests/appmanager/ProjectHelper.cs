using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{

    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(AppManager manager) : base(manager)
        {

        }

        public void Create(ProjectData project)
        {
            manager.Navigator.GoToProjectManagmentPage();
            InitProjectCreation();
            FillProjectCreationForm(project);
            SubmitProjectCreation();
        }

        public void Remove(ProjectData toBeRemoved)
        {
            manager.Navigator.GoToProjectManagmentPage();
            InitProjectEdit(toBeRemoved.Name);
            InitProjectRemoval();
            SubmitProjectRemoval();
        }

        public ProjectHelper IsProjectExist()
        {
            manager.Navigator.GoToProjectManagmentPage();

            int count = GetProjectCount();

            if (count == 0)
            {
                ProjectData testProject = new ProjectData()
                {
                    Name = "test"
                };

                Create(testProject);
            }
            return this;
        }

        public int GetProjectCount()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            return driver.FindElements(By.TagName("tbody"))[0].FindElements(By.TagName("tr")).Count;
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input.btn-primary")).Click();
        }

        public void FillProjectCreationForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
        }

        public void InitProjectCreation()
        {
            driver.FindElement(By.CssSelector("button.btn-primary")).Click();
        }

        public void SubmitProjectRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        public void InitProjectRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        public void InitProjectEdit(string name)
        {
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            driver.FindElement(By.XPath("//*[@id='main-container']//a[contains(text(), '" + name + "')]")).Click();
        }
    }
}

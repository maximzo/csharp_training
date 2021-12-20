using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(AppManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToManagmentPage()
        {
            if (driver.Url == baseURL + "/manage_overview_page.php"
                && IsElementPresent(By.XPath("//a[contains(@href, '/mantisbt/manage_user_page.php')]")))
            {
                return;
            }
            driver.FindElement(By.XPath("//a[contains(@href, '/manage_overview_page.php')]")).Click();
        }

        public void GoToProjectManagmentPage()
        {
            GoToManagmentPage();
            driver.FindElement(By.XPath("//a[contains(@href, '/mantisbt/manage_proj_page.php')]")).Click();
        }
    }
}
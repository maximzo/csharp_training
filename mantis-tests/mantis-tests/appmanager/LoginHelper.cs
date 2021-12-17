using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(AppManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.CssSelector("input.btn-success")).Click();

            //new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            //    .Until(d => d.FindElements(By.Name("password")).Count() > 0);

            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input.btn-success")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("span.user-info"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Name;
        }

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.CssSelector("span.user-info")).Text;
            return text;
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("span.user-info")).Click();
                driver.FindElement(By.LinkText("Выход")).Click();
            }
        }
    }
}

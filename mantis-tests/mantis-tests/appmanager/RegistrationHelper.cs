using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        private string baseUrl;

        public RegistrationHelper(AppManager manager, String baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }

        public void Register(AccountData account)
        {
            //OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            String url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            SubmitPasswordForm();
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = baseUrl + "/login_page.php";
        }
        private void OpenRegistrationForm()
        {
            manager.Driver.Url = baseUrl + "/signup_page.php";
            //driver.FindElement(By.CssSelector("a.back-to-login-link")).Click(); ;
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input.btn-success")).Click();
        }

        private string GetConfirmationUrl(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.CssSelector("button.btn-success")).Click();
        }
    }
}

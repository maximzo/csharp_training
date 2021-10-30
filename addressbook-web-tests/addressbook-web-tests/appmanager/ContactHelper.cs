using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(AppManager manager) : base(manager)
        {
        }

        public ContactHelper Remove(int v)
        {
            SelectContact(v);
            RemoveContact();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td/input")).Click();
            return this;
        }

        public ContactHelper Modify(int v, ContactData contactEdit)
        {
            InitContactMod(v);
            FillContactForms(contactEdit);
            SubmitContactMod();
            return this;
        }
        public ContactHelper InitContactMod(int editindex)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + editindex + "]/td[8]/a/img")).Click();
            return this;
        }
        public ContactHelper SubmitContactMod()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[21]")).Click();
            return this;
        }

        public ContactHelper FillContactForms(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contact.Title);
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}

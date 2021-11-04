﻿using System;
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

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            InitNewContactCreation();
            FillContactForms(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Modify(int v, ContactData contact, ContactData contactEdit)
        {
            manager.Navigator.OpenHomePage();
            if (IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[" + v + "]/td/input")))
            {
                InitContactMod(v);
                FillContactForms(contactEdit);
                SubmitContactMod();
            }
            else
            {
                InitNewContactCreation();
                FillContactForms(contact);
                SubmitContactCreation();
                manager.Navigator.OpenHomePage();
                InitContactMod(v);
                FillContactForms(contactEdit);
                SubmitContactMod();
            }
            return this;
        }

        public ContactHelper Remove(int v, ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            if (IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[" + v + "]/td/input")))
            {
                SelectContact(v);
                RemoveContact();
            }
            else
            {
                InitNewContactCreation();
                FillContactForms(contact);
                SubmitContactCreation();
                manager.Navigator.OpenHomePage();
                SelectContact(v);
                RemoveContact();
            }
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td/input")).Click();
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
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}

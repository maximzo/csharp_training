using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(AppManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitNewGroupCreation();
            FillGroupForms(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(int v, GroupData group, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            if (IsElementPresent(By.XPath("//div[@id='content']/form/span[" + v + "]/input")))
            {
                SelectGroup(v);
                InitGroupMod();
                FillGroupForms(newData);
                SubmitGroupMod();
                ReturnToGroupPage();
            }
            else
            {
                Create(group);
                SelectGroup(v);
                InitGroupMod();
                FillGroupForms(newData);
                SubmitGroupMod();
                ReturnToGroupPage();
            }

            return this;
        }

        public GroupHelper Remove(int v, GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            if (IsElementPresent(By.XPath("//div[@id='content']/form/span[" + v + "]/input")))
            {
                SelectGroup(v);
                RemoveGroup();
                ReturnToGroupPage();
            }
            else
            {
                Create(group);
                SelectGroup(v);
                RemoveGroup();
                ReturnToGroupPage();
            }
            return this;
        }

        public GroupHelper InitGroupMod()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupMod()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForms(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
    }
}

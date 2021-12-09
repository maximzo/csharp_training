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

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            InitNewContactCreation();
            FillContactForms(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Modify(int v, ContactData contactEdit)
        {
            manager.Navigator.OpenHomePage();
            InitContactMod(v);
            FillContactForms(contactEdit);
            SubmitContactMod();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(v);
            RemoveContact();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index+2) + "]/td/input")).Click();
            return this;
        }

        public ContactHelper InitContactMod(int editindex)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (editindex+2) + "]/td[8]/a/img")).Click();
            return this;
        }
        public ContactHelper SubmitContactMod()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[21]")).Click();
            contactCache = null;
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
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Select(By.Name("bday"), contact.Birthday);
            Select(By.Name("bmonth"), contact.Birthmonth);
            Type(By.Name("byear"), contact.Birthyear);
            Select(By.Name("aday"), contact.Anniversaryday);
            Select(By.Name("amonth"), contact.Anniversarymonth);
            Type(By.Name("ayear"), contact.Anniversaryyear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.HomePhone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public bool IsContactExist(int p)
        {
            return IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[" + (p+2) + "]/td/input"));
        }

        public ContactHelper OpenContactDetails(int dindex)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (dindex + 2) + "]/td[7]/a/img")).Click();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr"));
                foreach (IWebElement element in elements)
                {
                    if (element.GetAttribute("name") == "entry")
                    {
                        List<IWebElement> tds = element.FindElements(By.CssSelector("td")).ToList();
                        contactCache.Add(new ContactData(tds[2].Text, tds[1].Text));
                    }
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmail = allEmail,
                AllPhones = allPhones,
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactMod(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");

            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string amonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string homePhone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");
            

            return new ContactData(firstName, lastName)
            {
                Middlename = middleName,
                Nickname = nickName,
                Title = title,
                Company = company,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homePage,
                Birthday = bday,
                Birthmonth = bmonth,
                Birthyear = byear,
                Anniversaryday = aday,
                Anniversarymonth = amonth,
                Anniversaryyear = ayear,
                Address2 = address2,
                HomePhone2 = homePhone2,
                Notes = notes
            };
        }

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            OpenContactDetails(index);

            string allContactInfo = driver.FindElement(By.Id("content")).GetAttribute("innerText").Replace("\r\n\r\n", "\r\n").
                Replace("H: ", "").Replace("M: ", "").Replace("W: ", "").Replace("F: ", "").Replace("Birthday ", "").Replace("Anniversary ", "").
                Replace("Homepage:\r\n", "").Replace("P: ", "").Trim();
            
            string fullName = driver.FindElement(By.Id("content")).FindElement(By.TagName("b")).Text;

            return new ContactData(allContactInfo)
            {
                AllContactInfo = allContactInfo,
                FullName = fullName,
            };
        }

        public void AddAddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            ClearGroupFilter();
            SelectContactById(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void SelectContactById(string contactid)
        {
            driver.FindElement(By.Id(contactid)).Click();
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
    }
}

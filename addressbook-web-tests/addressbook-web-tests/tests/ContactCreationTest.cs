using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contact.InitNewContactCreation();
            ContactData contact = new ContactData("John");
            contact.Middlename = "Michael";
            contact.Lastname = "Osbourne";
            contact.Nickname = "Ozzy";
            contact.Title = "Singer, Songwriter";
            contact.Company = "Black Sabbath";
            app.Contact.FillContactForms(contact);
            app.Contact.SubmitContactCreation();
            app.Auth.Logout();
        }
    }
}
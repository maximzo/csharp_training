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
            ContactData contact = new ContactData("John");
            contact.Middlename = "Michael";
            contact.Lastname = "Osbourne";
            contact.Nickname = "Ozzy";
            contact.Title = "Singer, Songwriter";
            contact.Company = "Black Sabbath";

            app.Contact
                .InitNewContactCreation()
                .FillContactForms(contact)
                .SubmitContactCreation();
            app.Auth.Logout();
        }
    }
}
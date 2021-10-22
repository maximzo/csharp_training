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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitNewContactCreation();
            FillContactForms(new ContactData("John", "Michael", "Osbourne", "Ozzy", "Singer, Songwriter", "Black Sabbath"));
            SubmitContactCreation();
            Logout();
        }
    }
}

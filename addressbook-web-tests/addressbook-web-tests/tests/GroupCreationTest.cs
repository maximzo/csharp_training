using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupPage();
            app.Groups.InitNewGroupCreation();
            app.Groups.FillGroupForms(new GroupData("new_group", "some_header", "any_footer"));
            app.Groups.SubmitGroupCreation();
            app.Navigator.ReturnToGroupPage();
            app.Auth.Logout();
        }
    }
}
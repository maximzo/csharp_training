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
            GroupData group = new GroupData("new_group");
            group.Header = "some_header";
            group.Footer = "some_footer";

            app.Navigator.GoToGroupPage();
            app.Groups.InitNewGroupCreation();
            app.Groups.FillGroupForms(group);
            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupPage();
            app.Auth.Logout();
        }
    }
}
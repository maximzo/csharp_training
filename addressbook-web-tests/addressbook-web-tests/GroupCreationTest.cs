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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            InitNewGroupCreation();
            FillGroupForms(new GroupData("new_group", "some_header", "any_footer"));
            SubmitGroupCreation();
            ReturnToGroupPage();
            Logout();
        }
    }
}

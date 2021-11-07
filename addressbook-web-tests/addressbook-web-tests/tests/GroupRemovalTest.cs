using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Navigator.GoToGroupPage();
            if (app.Groups.IsGroupExist())
            {
                app.Groups.Remove(1);
            }
            else
            {
                app.Groups.Create(group);
                app.Groups.Remove(1);
            }
        }
    }
}
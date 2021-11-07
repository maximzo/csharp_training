using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModTests : AuthTestBase
    {
        [Test]
        public void GroupModTest()
        {
            GroupData group = new GroupData("tobemodified");
            GroupData newData = new GroupData("else_modified_group");
            newData.Header = null;
            newData.Footer = null;

            app.Navigator.GoToGroupPage();
            if (app.Groups.IsGroupExist())
            {
                app.Groups.Modify(1, newData);
            }
            else
            {
                app.Groups.Create(group);
                app.Groups.Modify(1, newData);
            }
        }
    }
}

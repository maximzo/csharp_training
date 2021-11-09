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
            
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (app.Groups.IsGroupExist(0))
            {
                app.Groups.Modify(0, newData);
            }
            else
            {
                app.Groups.Create(group);
                app.Groups.Modify(0, newData);
            }

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

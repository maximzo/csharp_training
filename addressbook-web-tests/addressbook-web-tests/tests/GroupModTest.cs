using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModTests : GroupTestBase
    {
        [Test]
        public void GroupModTest()
        {
            GroupData testGroup = new GroupData("tobemodified");
            GroupData newData = new GroupData("else_modified_group");
            newData.Header = null;
            newData.Footer = null;

            app.Navigator.GoToGroupPage();
            if (!app.Groups.IsGroupExist(0))
            {
                app.Groups.Create(testGroup);
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData g in newGroups)
            {
                if(g.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, g.Name);
                }
            }
        }
    }
}

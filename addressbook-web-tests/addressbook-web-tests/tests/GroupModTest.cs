using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModTest : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("modified_group");
            newData.Header = "modified_header";
            newData.Footer = "modified_footer";

            app.Groups.Modify(1, newData);
        }
    }
}

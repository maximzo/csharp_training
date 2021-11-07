using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("ToBeRemoved");

            app.Navigator.OpenHomePage();
            if (app.Contact.IsContactExist())
            {
                app.Contact.Remove(2);
            }
            else
            {
                app.Contact.Create(contact);
                app.Contact.Remove(2);
            }
        }
    }
}

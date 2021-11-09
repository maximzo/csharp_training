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

            List<ContactData> oldContacts = app.Contact.GetContactList();

            if (app.Contact.IsContactExist(0))
            {
                app.Contact.Remove(0);
            }
            else
            {
                app.Contact.Create(contact);
                app.Contact.Remove(0);
            }

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

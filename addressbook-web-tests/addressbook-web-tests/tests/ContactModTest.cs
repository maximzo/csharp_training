using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModTests : AuthTestBase
    {
        [Test]
        public void ContactModTest()
        {
            ContactData contact = new ContactData("ToBeModified");
            ContactData contactEdit = new ContactData("Jonathan");
            contactEdit.Lastname = "Osbournitze";

            app.Navigator.OpenHomePage();

            List<ContactData> oldContacts = app.Contact.GetContactList();

            if (!app.Contact.IsContactExist(0))
            {
                app.Contact.Create(contact);
            }
            app.Contact.Modify(0, contactEdit);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = contactEdit.Firstname;
            oldContacts[0].Lastname = contactEdit.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

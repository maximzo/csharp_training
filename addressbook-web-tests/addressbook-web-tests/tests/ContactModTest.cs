using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModTests : ContactTestBase
    {
        [Test]
        public void ContactModTest()
        {
            ContactData testContact = new ContactData("ToBeModified");
            ContactData contactEdit = new ContactData("Jonathan");
            contactEdit.Lastname = "Osbournitze";

            if (!app.Contact.IsContactExist(0))
            {
                app.Contact.Create(testContact);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModded = oldContacts[0];

            app.Contact.Modify(toBeModded, contactEdit);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].Firstname = contactEdit.Firstname;
            oldContacts[0].Lastname = contactEdit.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

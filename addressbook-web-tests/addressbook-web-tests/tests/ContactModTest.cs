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
            if (app.Contact.IsContactExist())
            {
                app.Contact.Modify(2, contactEdit);
            }
            else
            {
                app.Contact.Create(contact);
                app.Contact.Modify(2, contactEdit);
            }
        }
    }
}

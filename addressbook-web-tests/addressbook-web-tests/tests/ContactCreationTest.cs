using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30))
                {
                    Firstname = GenerateRandomString(25),
                    Lastname = GenerateRandomString(25)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        //[Test]
        //public void ContactCreationTest()
        //{
        //    ContactData contact = new ContactData("John");
        //    contact.Middlename = "Michael";
        //    contact.Lastname = "Osbourne";
        //    contact.Nickname = "Ozzy";
        //    contact.Title = "Singer, Songwriter";
        //    contact.Company = "Black Sabbath";

        //    List<ContactData> oldContacts = app.Contact.GetContactList();

        //    app.Contact.Create(contact);

        //    List<ContactData> newContacts = app.Contact.GetContactList();
        //    oldContacts.Add(contact);
        //    oldContacts.Sort();
        //    newContacts.Sort();
        //    Assert.AreEqual(oldContacts, newContacts);
        //}

        [Test]
        public void ContactFullInfoCreationTest()
        {
            ContactData contact = new ContactData("Terence");
            contact.Middlename = "Michael Joseph";
            contact.Lastname = "Butler";
            contact.Nickname = "Geezer";
            contact.Title = "Bass guitar";
            contact.Company = "Black Sabbath";
            contact.Address = "Somewhere";
            contact.HomePhone = "8-927-333-44-55";
            contact.MobilePhone = "8(927)5554455";
            contact.WorkPhone = "89276664455";
            contact.Fax = "555667";
            contact.Email = "geezer@mail.com";
            contact.Email2 = "blacksabbath@mail.com";
            contact.Email3 = "heavenandhell@mail.com";
            contact.Homepage = "geezerbutler.com";
            contact.Birthday = "17";
            contact.Birthmonth = "July";
            contact.Birthyear = "1947";
            contact.Anniversaryday = "20";
            contact.Anniversarymonth = "January";
            contact.Anniversaryyear = "1980";
            contact.Address2 = "Somewhere else";
            contact.HomePhone2 = "8-927-3334466";
            contact.Notes = "Any note";

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
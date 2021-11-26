using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
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
                    Middlename = GenerateRandomString(20),
                    Lastname = GenerateRandomString(25)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0])
                {
                    Middlename = parts[1],
                    Lastname = parts[2]
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<ContactData> ContactDataFromExcelFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contacts.Add(new ContactData()
                {
                    Firstname = range.Cells[i, 1].Value,
                    Middlename = range.Cells[i, 2].Value,
                    Lastname = range.Cells[i, 3].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return contacts;
        }

        [Test, TestCaseSource("ContactDataFromExcelFile")]
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
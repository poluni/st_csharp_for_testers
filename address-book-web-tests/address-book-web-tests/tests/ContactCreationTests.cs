using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace address_book_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(5), GenerateRandomString(10)));
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.json");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1]));
            }
            return contacts;
        }

        [Test, TestCaseSource("ContactDataFromFile")]
        public void ContactCreationTest(ContactData contactData)
        {
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Create(contactData);
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }     
    }
}
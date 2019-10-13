using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace address_book_web_tests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
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

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1]));
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTest(ContactData contactData)
        {
            List<ContactData> oldContacts = ContactData.GetAllContacts();
            app.Contact.Create(contactData);
            List<ContactData> newContacts = ContactData.GetAllContacts();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<ContactData> contactFromUI = app.Contact.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.WriteLine(String.Format("Время выполнения получения списка групп из UI: {0} секунд", end.Subtract(start).TotalSeconds));
            start = DateTime.Now;
            List<ContactData> contactFromDB = ContactData.GetAllContacts();
            end = DateTime.Now;
            System.Console.WriteLine(String.Format("Время выполнения получения списка групп из БД: {0} секунд", end.Subtract(start).TotalSeconds));
        }
    }
}
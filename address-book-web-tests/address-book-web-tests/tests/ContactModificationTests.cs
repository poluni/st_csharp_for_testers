using NUnit.Framework;
using System.Collections.Generic;

namespace address_book_web_tests
{
    [TestFixture]
    public class ContactModificationTests : ContactExistTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Yan", "Сидоров-Иванов");
            List<ContactData> oldContacts = ContactData.GetAllContacts();
            app.Contact.Modify(oldContacts[0], newContactData);
            List<ContactData> newContacts = ContactData.GetAllContacts();
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts[0].Lastname = newContactData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactEmptyModificationTest()
        {
            ContactData newContactData = new ContactData("", "");
            List<ContactData> oldContacts = ContactData.GetAllContacts();
            app.Contact.Modify(oldContacts[0], newContactData);
            List<ContactData> newContacts = ContactData.GetAllContacts();
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts[0].Lastname = newContactData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

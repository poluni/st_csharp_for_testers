using NUnit.Framework;
using System.Collections.Generic;

namespace address_book_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Yan", "Сидоров-Иванов");
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.CheckContactExist(0, new ContactData("Вася", "Иванов"));
            app.Contact.Modify(0, newContactData);
            List<ContactData> newContacts = app.Contact.GetContactList();
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
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.CheckContactExist(0, new ContactData("Вася", "Иванов"));
            app.Contact.Modify(0, newContactData);
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts[0].Lastname = newContactData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

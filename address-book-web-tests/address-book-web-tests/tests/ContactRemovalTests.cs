using NUnit.Framework;
using System.Collections.Generic;

namespace address_book_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.CheckContactExist(0, new ContactData("Вася", "Иванов"));
            List<ContactData> oldContacts = ContactData.GetAllContacts();
            ContactData toBeRemoved = oldContacts[0];
            app.Contact.Remove(toBeRemoved, true);
            List<ContactData> newContacts = ContactData.GetAllContacts();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.IdContact, toBeRemoved.IdContact);
            }
        }
    }
}

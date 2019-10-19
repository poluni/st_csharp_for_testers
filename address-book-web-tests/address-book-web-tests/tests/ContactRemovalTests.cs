using NUnit.Framework;
using System.Collections.Generic;

namespace address_book_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : ContactExistTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
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

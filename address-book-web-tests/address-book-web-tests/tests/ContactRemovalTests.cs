using NUnit.Framework;
using System.Collections.Generic;

namespace address_book_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.CheckContactExist(0, new ContactData("Вася", "Иванов"));
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Remove(0, true);
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

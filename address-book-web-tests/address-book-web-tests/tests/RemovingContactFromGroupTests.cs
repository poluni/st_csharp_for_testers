using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_web_tests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAllGroups()[0];
            List<ContactData> oldList = group.GetContactsFromGroup();
            ContactData contact = ContactData.GetAllContacts().Intersect(oldList).First();
            app.Contact.RemoveContactFromGroup(contact, group);
            List<ContactData> newList = group.GetContactsFromGroup();
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_web_tests
{
    [TestFixture]
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAllGroups()[0];
            List<ContactData> oldList = group.GetContactsFromGroup();
            ContactData contact =  ContactData.GetAllContacts().Except(oldList).First();
            app.Contact.AddContactToGroup(contact, group);
            List<ContactData> newList = group.GetContactsFromGroup();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}

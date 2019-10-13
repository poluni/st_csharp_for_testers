using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_web_tests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactData> contactsFromUI = app.Contact.GetContactList();
                List<ContactData> contactsFromDB = ContactData.GetAllContacts();
                contactsFromUI.Sort();
                contactsFromDB.Sort();
                Assert.AreEqual(contactsFromUI, contactsFromDB);
            }

        }
    }
}

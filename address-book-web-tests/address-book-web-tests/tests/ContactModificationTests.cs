using NUnit.Framework;

namespace address_book_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Lora", "Palmer");
            app.Contact.CheckContactExist(1, new ContactData("Вася", "Иванов"));
            app.Contact.Modify(1, newContactData);
        }

        [Test]
        public void ContactEmptyModificationTest()
        {
            ContactData newContactData = new ContactData("", "");
            app.Contact.CheckContactExist(1, new ContactData("Вася", "Иванов"));
            app.Contact.Modify(1, newContactData);
        }
    }
}

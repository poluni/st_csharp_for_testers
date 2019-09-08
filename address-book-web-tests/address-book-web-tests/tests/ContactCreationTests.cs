using NUnit.Framework;

namespace address_book_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contactData = new ContactData("Ян", "Сидоров-Иванов");
            app.Contact.Create(contactData);
        }     
    }
}
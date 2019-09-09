using NUnit.Framework;

namespace address_book_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.CheckContactExist(1, new ContactData("Вася", "Иванов"));
            app.Contact.Remove(1, true);
        }
    }
}

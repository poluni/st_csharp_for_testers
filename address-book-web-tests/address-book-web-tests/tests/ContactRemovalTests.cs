using NUnit.Framework;

namespace address_book_web_tests.tests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.Remove(1, true);
        }
    }
}

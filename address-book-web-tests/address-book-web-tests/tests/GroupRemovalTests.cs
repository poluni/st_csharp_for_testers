using NUnit.Framework;

namespace address_book_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {

        [Test]
        public void RemoveGroupTest()
        {
            app.Groups.Remove(1);
        }
    }
}

using NUnit.Framework;

namespace address_book_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void RemoveGroupTest()
        {
            app.Groups.CheckGroupExist(1, new GroupData("Group_1", "Header_1", "Footer_2"));
            app.Groups.Remove(1);
        }
    }
}

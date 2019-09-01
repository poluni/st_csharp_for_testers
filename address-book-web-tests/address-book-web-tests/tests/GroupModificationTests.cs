using NUnit.Framework;

namespace address_book_web_tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void ModifyGroupTest()
        {
            GroupData newData = new GroupData("Group_0");
            newData.Header = "Header_0";
            newData.Footer = "Footer_0";
            app.Groups.Modify(1, newData);
        }
    }
}

using NUnit.Framework;

namespace address_book_web_tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void ModifyGroupTest()
        {            
            GroupData newData = new GroupData("Group_0");
            newData.Header = "Header_0";
            newData.Footer = "Footer_0";
            app.Groups.CheckGroupExist(1, new GroupData("Group_1", "Header_1", "Footer_2"));
            app.Groups.Modify(1, newData);
        }
    }
}

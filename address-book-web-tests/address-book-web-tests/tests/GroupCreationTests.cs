using NUnit.Framework;

namespace address_book_web_tests
{

    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void CreateNewGroupWithFillFieldsTest()
        {
            GroupData groupData = new GroupData("Group_1");
            groupData.Header = "Header_1";
            groupData.Footer = "Footer_1";
            app.Groups.Create(groupData);
        }

        [Test]
        public void CreateNewEmptyGroupTest()
        {
            GroupData groupData = new GroupData("");
            groupData.Header = "";
            groupData.Footer = "";
            app.Groups.Create(groupData);
        }
    }
}
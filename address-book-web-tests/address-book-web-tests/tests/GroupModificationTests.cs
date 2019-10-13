using NUnit.Framework;
using System.Collections.Generic;

namespace address_book_web_tests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void ModifyGroupTest()
        {
            app.Groups.CheckGroupExist(0, new GroupData("Group_1", "Header_1", "Footer_2"));
            GroupData newData = new GroupData("Group_0");
            newData.Header = "Header_0";
            newData.Footer = "Footer_0";
            List<GroupData> oldGroups = GroupData.GetAllGroups();            
            app.Groups.Modify(oldGroups[0], newData);
            List<GroupData> newGroups = GroupData.GetAllGroups();
            oldGroups[0].Name = newData.Name;
            oldGroups[0].Header = newData.Header;
            oldGroups[0].Footer = newData.Footer;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

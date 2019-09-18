using NUnit.Framework;
using System.Collections.Generic;

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
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.CheckGroupExist(0, new GroupData("Group_1", "Header_1", "Footer_2"));
            app.Groups.Modify(0, newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

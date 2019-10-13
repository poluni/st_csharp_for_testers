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
            GroupData newData = new GroupData("Group_0");
            newData.Header = "Header_0";
            newData.Footer = "Footer_0";
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.CheckGroupExist(oldGroups[0], new GroupData("Group_1", "Header_1", "Footer_2"));
            app.Groups.Modify(0, newData);
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

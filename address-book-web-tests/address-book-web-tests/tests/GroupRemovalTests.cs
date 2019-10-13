using NUnit.Framework;
using System.Collections.Generic;

namespace address_book_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {

        [Test]
        public void RemoveGroupTest()
        {
            List<GroupData> oldGroups = GroupData.GetAllGroups();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.CheckGroupExist(oldGroups[0], new GroupData("Group_1", "Header_1", "Footer_2"));
            app.Groups.Remove(oldGroups[0]);
            List<GroupData> newGroups = GroupData.GetAllGroups();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
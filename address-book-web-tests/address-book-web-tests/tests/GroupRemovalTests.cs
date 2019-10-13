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
            app.Groups.CheckGroupExist(0, new GroupData("Group_1", "Header_1", "Footer_2"));
            List<GroupData> oldGroups = GroupData.GetAllGroups();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);
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
using NUnit.Framework;
using System.Collections.Generic;

namespace address_book_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void RemoveGroupTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.CheckGroupExist(0, new GroupData("Group_1", "Header_1", "Footer_2"));
            app.Groups.Remove(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups, "Группа не удалена!");
        }
    }
}
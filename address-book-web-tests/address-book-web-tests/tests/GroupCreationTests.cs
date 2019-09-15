using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace address_book_web_tests
{

    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        private const string TextMessage = "Списки групп отличаются. Новая группа не создана!";

        [Test]
        public void CreateNewGroupWithFillFieldsTest()
        {
            GroupData groupData = new GroupData("Group_1");
            groupData.Header = "Header_1";
            groupData.Footer = "Footer_1";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(groupData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups, TextMessage);
        }

        [Test]
        public void CreateNewEmptyGroupTest()
        {
            GroupData groupData = new GroupData("");
            groupData.Header = "";
            groupData.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(groupData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups, TextMessage);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData groupData = new GroupData("a'a");
            groupData.Header = "";
            groupData.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(groupData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups, TextMessage);
        }
    }
}
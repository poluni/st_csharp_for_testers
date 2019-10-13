using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace address_book_web_tests
{

    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                  groups.Add(new GroupData(GenerateRandomString(30))
                  {
                      Header = GenerateRandomString(100),
                      Footer = GenerateRandomString(100)
                  });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();            
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void CreateNewGroupWithFillFieldsTest(GroupData groupData)
        {
            List<GroupData> oldGroups = GroupData.GetAll();
            app.Groups.Create(groupData);
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
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
            Assert.AreEqual(oldGroups, newGroups);
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
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> groupFromUI = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.WriteLine(String.Format("Время выполнения получения списка групп из UI: {0} секунд", end.Subtract(start).TotalSeconds));
            start = DateTime.Now;
            List<GroupData> groupFromDB = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.WriteLine(String.Format("Время выполнения получения списка групп из БД: {0} секунд", end.Subtract(start).TotalSeconds));
        }
    }
}
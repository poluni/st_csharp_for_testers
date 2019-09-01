using NUnit.Framework;


namespace address_book_web_tests
{

    [TestFixture]
    public class GroupCreationTests: TestBase
    {
       
        [Test]
        public void CreateNewGroupTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();
            GroupData groupData = new GroupData("Group_1");
            groupData.Header = "Header_1";
            groupData.Footer = "Footer_1";
            FillGroupForm(groupData);
            SubmitGroupCreation();
            GoToGroupsPage();
            Logout();
        }       
    }
}
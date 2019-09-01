using NUnit.Framework;

namespace address_book_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void AddNewContactTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddNewContactPage();
            FillContactForm(new ContactData("Ян", "Сидоров-Иванов"));
            SubmitContactCreation();
            Logout();
        }     
    }
}


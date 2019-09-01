using NUnit.Framework;

namespace address_book_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void AddNewContactTest()
        {
            app.Contact.GoToAddNewContactPage()
                       .FillContactForm(new ContactData("Ян", "Сидоров-Иванов"))
                       .SubmitContactCreation();
        }     
    }
}
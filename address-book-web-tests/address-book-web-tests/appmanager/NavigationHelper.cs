using OpenQA.Selenium;

namespace address_book_web_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToGroupsPage() => driver.FindElement(By.LinkText("groups")).Click();

        public void GoToHomePage() => driver.Navigate().GoToUrl(baseURL + @"/addressbook/");
    }
}

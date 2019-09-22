using System;
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

        public void GoToGroupsPage()
        {
            if(driver.Url == baseURL + @"/addressbook/group.php"
               && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + @"/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + @"/addressbook/");
        }
    }
}

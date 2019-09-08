using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace address_book_web_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;
        //private bool acceptNextAlert;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        
        public ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost";
            //acceptNextAlert = true;
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper Auth => loginHelper;

        public NavigationHelper Navigator => navigator;

        public GroupHelper Groups => groupHelper;

        public ContactHelper Contact => contactHelper;

        public IWebDriver Driver => driver;
    }
}

using OpenQA.Selenium;

namespace address_book_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }


        public ContactHelper Modify(int num, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(num);
            GoToEditContactPage();
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(int num, bool alertAcc)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(num);
            SubmitContactRemoval();
            IsAlertPresent();
            CloseAlertAndGetItsText(alertAcc);
            manager.Navigator.GoToHomePage();
            return this;
        }

        private ContactHelper SubmitContactRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper Create(ContactData newData)
        {
            GoToAddNewContactPage();
            FillContactForm(newData);
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper CheckContactExist(int num, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            if (Is—ontactCreatedBase())
            {
                if (Is—ontactCreated(num, contact))
                {
                    return this;
                }
            }
            else
            {
                Create(contact);
                return this;
            }
            return this;
        }

        public bool Is—ontactCreated(int num, ContactData contact)
        {
            return Is—ontactCreatedBase()
                && driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + num + "]")).Text
                == contact.Firstname;
        }

        public bool Is—ontactCreatedBase()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper GoToAddNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper GoToEditContactPage()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText(bool alertAcc)
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (alertAcc)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                alertAcc = true;
            }

        }
    }
}

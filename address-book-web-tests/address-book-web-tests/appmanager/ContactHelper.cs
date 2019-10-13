using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        public ContactHelper Modify(ContactData oldContactData, ContactData newContactData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(oldContactData.IdContact);
            GoToEditContactPage();
            FillContactForm(newContactData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            GoToEditContactPage();
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string secondaryAddress = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string secondaryHomePhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string secondaryNotes = driver.FindElement(By.Name("notes")).GetAttribute("value");
            return new ContactData(firstName, lastName)
            {
                Middlename = middleName,
                Nickname = nickName,
                Title = title,
                Company = company,
                Address = address,
                Fax = fax,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                HomePage = homePage,
                SecondaryAddress = secondaryAddress,
                SecondaryHomePhone = secondaryHomePhone,
                SecondaryNotes = secondaryNotes
            };            
        }

        public string MakeAllContactString(ContactData data)
        {
            StringBuilder allContactInfo = new StringBuilder();
                if (data.Firstname != null)
                {
                    allContactInfo.Append(data.Firstname);
                }
                if (data.Middlename != null)
                {
                    allContactInfo.Append(" ");
                    allContactInfo.Append(data.Middlename);
                }
                if (data.Lastname != null)
                {
                    allContactInfo.Append(" ");
                    allContactInfo.Append(data.Lastname);
                    allContactInfo.Append("\r\n");
                }
                if (data.Nickname != null)
                {
                    allContactInfo.Append(data.Nickname);
                    allContactInfo.Append("\r\n");
                }
                if (data.Title != null)
                {
                    allContactInfo.Append(data.Title);
                    allContactInfo.Append("\r\n");
                }
                if (data.Company != null)
                {
                    allContactInfo.Append(data.Company);
                    allContactInfo.Append("\r\n");
                }
                if (data.Address != null)
                {
                    allContactInfo.Append(data.Address);
                    allContactInfo.Append("\r\n").Append("\r\n");
                }
                if (data.HomePhone != null)
                {
                    allContactInfo.Append("H: ");
                    allContactInfo.Append(data.HomePhone);
                    allContactInfo.Append("\r\n");
                }
                if (data.MobilePhone != null)
                {
                    allContactInfo.Append("M: ");
                    allContactInfo.Append(data.MobilePhone);
                    allContactInfo.Append("\r\n");
                }
                if (data.WorkPhone != null)
                {
                    allContactInfo.Append("W: ");
                    allContactInfo.Append(data.WorkPhone);
                    allContactInfo.Append("\r\n");
                }
                if (data.Fax != null)
                {
                    allContactInfo.Append("F: ");
                    allContactInfo.Append(data.Fax);
                    allContactInfo.Append("\r\n").Append("\r\n");
                }                
                if (data.Email != null)
                {
                    allContactInfo.Append(data.Email);
                    allContactInfo.Append("\r\n");
                }
                if (data.Email2 != null)
                {
                    allContactInfo.Append(data.Email2);
                    allContactInfo.Append("\r\n");
                }
                if (data.Email3 != null)
                {
                    allContactInfo.Append(data.Email3);
                    allContactInfo.Append("\r\n");
                }
                if (data.HomePage != null)
                {
                    allContactInfo.Append("Homepage:");
                    allContactInfo.Append("\r\n");
                    allContactInfo.Append(data.HomePage);
                    allContactInfo.Append("\r\n").Append("\r\n").Append("\r\n");
                }
                if (data.SecondaryAddress != null)
                {
                    allContactInfo.Append(data.SecondaryAddress);
                    allContactInfo.Append("\r\n").Append("\r\n");
                }
                if (data.SecondaryHomePhone != null)
                {
                    allContactInfo.Append("P: ");
                    allContactInfo.Append(data.SecondaryHomePhone);
                    allContactInfo.Append("\r\n").Append("\r\n");
                }
                if (data.SecondaryNotes != null)
                {
                    allContactInfo.Append(data.SecondaryNotes);
                }
            return allContactInfo.ToString();
        }

        public string GetContactInformationFromPage(int index)
        {
            manager.Navigator.GoToHomePage();
            string id = driver.FindElement(By.Name("entry")).FindElement(By.TagName("input")).GetAttribute("id").ToString();
            driver.FindElement(By.XPath("(//a[@href='view.php?id=" + id + "'])")).Click();
            return driver.FindElement(By.Id("content")).Text;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
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

        public ContactHelper Remove(ContactData toBeRemoved, bool alertAcc)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(toBeRemoved.IdContact);
            SubmitContactRemoval();
            IsAlertPresent();
            CloseAlertAndGetItsText(alertAcc);
            manager.Navigator.GoToHomePage();
            return this;
        }

        private ContactHelper SubmitContactRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
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
                && driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + num + 1 + "]")).Text
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
            contactCache = null;
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + 1 + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
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
            contactCache = null;
            return this;
        }

        private List<ContactData> contactCache = null;
        
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> rows = driver.FindElement(By.Id("maintable")).FindElements(By.TagName("tr"));
                bool headerFlag = true;
                foreach (var row in rows)
                {
                    if (headerFlag)
                    {
                        headerFlag = false;
                        continue;
                    }
                    ICollection<IWebElement> cells = row.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells.ElementAt(2).Text, cells.ElementAt(1).Text));
                }
            }
            return new List<ContactData>(contactCache);
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

using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace address_book_web_tests
{
    public class GroupHelper : HelperBase

    {

        public GroupHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }

        public GroupHelper CheckGroupExist(int num, GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            if (IsGroupCreatedBase())
            {
                if (IsGroupCreated(num, group))
                {
                    return this;
                }
            }
            else
            {
                Create(group);
                return this;
            }
            return this;
        }        

        public GroupHelper Modify(int num, GroupData newData)
        { 
            manager.Navigator.GoToGroupsPage();
            SelectGroup(num);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public bool IsGroupCreated(int num, GroupData group)
        {
            return IsGroupCreatedBase()
                && driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (num + 1) + "]")).Text
                == group.Name;
        }

        public bool IsGroupCreatedBase()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.XPath("//input[@name='edit']")).Click();
            return this;
        }

        public GroupHelper Remove(int num)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(num);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
                driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
                return this;
        }
    }
}

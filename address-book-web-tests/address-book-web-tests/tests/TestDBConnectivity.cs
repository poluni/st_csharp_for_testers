using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace address_book_web_tests
{
    public class TestDBConnectivity : AuthTestBase
    {
        [Test]
        public void TestContactGroupDBConnectivity()
        {
            foreach (ContactData contact in GroupData.GetAllGroups()[0].GetContactsFromGroup())
            {
                System.Console.WriteLine(contact);
            }
        }

        [Test]
        public void TestGroupDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> groupFromUI = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.WriteLine(String.Format("Время выполнения получения списка групп из UI: {0} секунд", end.Subtract(start).TotalSeconds));
            start = DateTime.Now;
            List<GroupData> groupFromDB = GroupData.GetAllGroups();
            end = DateTime.Now;
            System.Console.WriteLine(String.Format("Время выполнения получения списка групп из БД: {0} секунд", end.Subtract(start).TotalSeconds));
        }

        [Test]
        public void TestContactDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<ContactData> contactFromUI = app.Contact.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.WriteLine(String.Format("Время выполнения получения списка групп из UI: {0} секунд", end.Subtract(start).TotalSeconds));
            start = DateTime.Now;
            List<ContactData> contactFromDB = ContactData.GetAllContacts();
            end = DateTime.Now;
            System.Console.WriteLine(String.Format("Время выполнения получения списка групп из БД: {0} секунд", end.Subtract(start).TotalSeconds));
        }

        [Test]
        public void TestContactDB()
        {
            foreach (ContactData contact in ContactData.GetAllContacts())
            {
                System.Console.WriteLine(contact.Deprecated);
            }
        }
    }
}

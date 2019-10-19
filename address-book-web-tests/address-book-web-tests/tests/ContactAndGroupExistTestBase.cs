using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_web_tests
{
    public class ContactAndGroupExistTestBase : AuthTestBase
    {
        [SetUp]
        public void CheckContactAndGroupExistTest()
        {
            app.Groups.CheckGroupExist(0, new GroupData("0", "0", "0"));
            app.Contact.CheckContactExist(0, new ContactData("Вася", "Иванов"));
        }
    }
}

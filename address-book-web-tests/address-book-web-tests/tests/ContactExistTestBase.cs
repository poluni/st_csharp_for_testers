using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_web_tests
{
    public class ContactExistTestBase : ContactTestBase
    {
        [SetUp]
        public void CheckContactExistTest()
        {
            app.Contact.CheckContactExist(0, new ContactData("Вася", "Иванов"));
        }
    }
}

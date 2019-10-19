using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_web_tests
{
    public class GroupExistTestBase : GroupTestBase
    {
        [SetUp]
        public void CheckGroupExistTest()
        {
            app.Groups.CheckGroupExist(0, new GroupData("0", "0", "0"));
        }
    }
}

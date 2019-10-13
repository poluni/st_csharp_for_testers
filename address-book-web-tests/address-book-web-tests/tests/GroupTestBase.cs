using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_web_tests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> groupsFromUI = app.Groups.GetGroupList();
                List<GroupData> groupsFromDB = GroupData.GetAll();
                groupsFromUI.Sort();
                groupsFromDB.Sort();
                Assert.AreEqual(groupsFromUI, groupsFromDB);
            }

        }
    }
}

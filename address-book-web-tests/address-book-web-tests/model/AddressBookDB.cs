using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using System.Text;
using System.Threading.Tasks;

namespace address_book_web_tests
{
    public class AddressBookDB: LinqToDB.Data.DataConnection
    {
        public AddressBookDB(): base ("AddressBook") { }

        public ITable<GroupData> Groups 
        {
            get
            {
                return GetTable<GroupData>();
            }
        }

        public ITable<ContactData> Contacts
        {
            get
            {
                return GetTable<ContactData>();
            }
        }

    }
}

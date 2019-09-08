using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_web_tests
{
    public class ContactData
    {
        private string firstname;
        private string lastname;

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string Firstname
        {
            get => firstname; 
            set => firstname = value; 
        }

        public string Lastname
        {
            get => lastname; 
            set => lastname = value;
        }
    }
}

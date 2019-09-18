using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int CompareTo(ContactData otherContact)
        {
            if (Object.ReferenceEquals(otherContact, null))
            {
                return 1;
            }
            if (Firstname.CompareTo(otherContact.Firstname) == 0 && Lastname.CompareTo(otherContact.Lastname) == 0)
            {
                return 0;
            }
            return 1;
        }

        public bool Equals(ContactData otherContact)
        {
            if (Object.ReferenceEquals(otherContact, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, otherContact))
            {
                return true;
            }
            return Firstname == otherContact.Firstname && Lastname == otherContact.Lastname;
        }

        public override int GetHashCode() => (Firstname + Lastname).GetHashCode();

        public override string ToString() => String.Format("firstname = {0}, lastname = {1}", Firstname, Lastname);
    }
}

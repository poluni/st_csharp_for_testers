using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace address_book_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allContactInfo;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }

        public string IdContact { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string HomePage { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(SecondaryHomePhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return Regex.Replace(data, "[ -()]", "") + "\r\n";
        }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllContactInfo
        {
            get
            {
                return allContactInfo;
            }
            /*
                if (allContactInfo != null)
                {
                    return allContactInfo;
                }
                else
                {
                    if (Firstname != null)
                    {
                        allContactInfo = Firstname;
                    }
                    if (Middlename != null)
                    {
                        allContactInfo += Middlename;
                    }
                    if (Lastname != null)
                    {
                        allContactInfo += Lastname;
                    }
                    if (Nickname != null)
                    {
                        allContactInfo += Nickname;
                    }
                    if (Title != null)
                    {
                        allContactInfo += Title;
                    }
                    if (Company != null)
                    {
                        allContactInfo += Company;
                    }
                    if (Address != null)
                    {
                        allContactInfo += Address;
                    }
                    if (AllPhones != null)
                    {
                        allContactInfo += AllPhones;
                    }
                    if (Fax != null)
                    {
                        allContactInfo += Fax;
                    }
                    if (AllEmails != null)
                    {
                        allContactInfo += AllEmails;
                    }
                    if (HomePage != null)
                    {
                        allContactInfo += HomePage;
                    }
                    if (SecondaryAddress != null)
                    {
                        allContactInfo += SecondaryAddress;
                    }
                    if (SecondaryHomePhone != null)
                    {
                        allContactInfo += SecondaryHomePhone;
                    }
                    if (SecondaryNotes != null)
                    {
                        allContactInfo += SecondaryNotes;
                    }
                }
                return allContactInfo;
            }
            */
            set
            {
                allContactInfo = value;
            }
        }

        public string Birthday { get; set; }

        public string Anniversary { get; set; }

        public string SecondaryAddress { get; set; }

        public string SecondaryHomePhone { get; set; }

        public string SecondaryNotes { get; set; }

        public int CompareTo(ContactData otherContact)
        {
            if (Object.ReferenceEquals(otherContact, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(otherContact.Lastname) == 0)
            {
                if (Firstname.CompareTo(otherContact.Firstname) == 0)
                {
                    return Firstname.CompareTo(otherContact.Firstname);
                }
            }
            return Lastname.CompareTo(otherContact.Lastname);
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

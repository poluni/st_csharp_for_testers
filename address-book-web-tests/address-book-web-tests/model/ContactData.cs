using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace address_book_web_tests
{
    [Table(Name = "addressbook")]
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

        [Column(Name = "firstname"), NotNull]
        public string Firstname { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string IdContact { get; set; }

        [Column(Name = "middlename"), NotNull]
        public string Middlename { get; set; }

        [Column(Name = "lastname"), NotNull]
        public string Lastname { get; set; }

        [Column(Name = "nickname"), NotNull]
        public string Nickname { get; set; }

        [Column(Name = "company"), NotNull]
        public string Company { get; set; }

        [Column(Name = "title"), NotNull]
        public string Title { get; set; }

        [Column(Name = "address"), NotNull]
        public string Address { get; set; }

        [Column(Name = "homepage"), NotNull]
        public string HomePage { get; set; }

        [Column(Name = "home"), NotNull]
        public string HomePhone { get; set; }
               
        [Column(Name = "mobile"), NotNull]
        public string MobilePhone { get; set; }

        [Column(Name = "work"), NotNull]
        public string WorkPhone { get; set; }

        [Column(Name = "fax"), NotNull]
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

        [Column(Name = "email"), NotNull]
        public string Email { get; set; }

        [Column(Name = "email2"), NotNull]
        public string Email2 { get; set; }

        [Column(Name = "email3"), NotNull]
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
            set
            {
                allContactInfo = value;
            }
        }

        public string Birthday { get; set; }

        public string Anniversary { get; set; }

        [Column(Name = "address2"), NotNull]
        public string SecondaryAddress { get; set; }

        [Column(Name = "phone2"), NotNull]
        public string SecondaryHomePhone { get; set; }

        [Column(Name = "notes"), NotNull]
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

        public static List<ContactData> GetAllContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts select c).ToList();
            }
        }

        public override int GetHashCode() => (Firstname + Lastname).GetHashCode();

        public override string ToString() => String.Format("firstname = {0}, lastname = {1}", Firstname, Lastname);
    }
}

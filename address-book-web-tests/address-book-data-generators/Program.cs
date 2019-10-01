using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using address_book_web_tests;
using Newtonsoft.Json;

namespace address_book_web_tests
{
    class Program
    {
        static void Main(string[] args)
        {
            string obj = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];
            if (obj.Equals("groups"))
            {
                writeObjectAsGroups(obj, count, writer, format);
            }
            else if (obj.Equals("contacts"))
            {
                writeObjectAsContacts(obj, count, writer, format);
            }
            writer.Close();
        }

        static void writeObjectAsGroups(string obj, int count, StreamWriter writer, string format)
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
            switch (format)
            {
                case "csv": writeGroupsToCsvFile(groups, writer); break;
                case "xml": writeGroupsToXmlFile(groups, writer); break;
                case "json": writeGroupsToJsonFile(groups, writer); break;
                default: System.Console.Out.Write(String.Format("Unrecognized format - {0}", format)); break;
            }
        }

        static void writeObjectAsContacts(string obj, int count, StreamWriter writer, string format)
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10)));
            }
            switch (format)
            {
                case "csv": writeContactsToCsvFile(contacts, writer); break;
                case "xml": writeContactsToXmlFile(contacts, writer); break;
                case "json": writeContactsToJsonFile(contacts, writer); break;
                default: System.Console.Out.Write(String.Format("Unrecognized format - {0}", format)); break;
            }
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.WriteLine(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0}, ${1}",
                    contact.Firstname, contact.Lastname));
            }
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0}, ${1}, ${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.WriteLine(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}

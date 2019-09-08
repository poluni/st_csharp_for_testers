using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_web_tests
{
    public class GroupData
    {
        private string name;
        private string header = "";
        private string footer = "";

        public GroupData(string name)
        {
            this.name = name;
        }

        public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }

        public string Name
        {
            get => name; 
            set => name = value; 
        }

        public string Header
        {
            get => header; 
            set => header = value; 
        }

        public string Footer
        {
            get => footer; 
            set => footer = value;
        }
    }
}

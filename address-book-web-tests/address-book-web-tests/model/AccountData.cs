﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_web_tests
{
    public class AccountData
    {
        private string username;
        private string password;

        public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get => username; 
            set => username = value;
        }

        public string Password
        {
            get => password; 
            set => password = value;
        }
    }
}

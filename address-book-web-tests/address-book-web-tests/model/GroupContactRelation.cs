﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace address_book_web_tests
{
    [Table(Name= "address_in_groups")]
    public class GroupContactRelation
    {
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string GroupId { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string ContactId { get; set; }

    }
}

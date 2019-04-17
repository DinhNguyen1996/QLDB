﻿using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceModel
{
    public class Contact
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public long phoneNumber { get; set; }
        public string notes { get; set; }
        public bool myFavourite { get; set; }
        public bool gender { get; set; }
        //public nameNetwork 
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DTO
{
    public class ObjCustomer
    {
        string customercode, name, phone, note;

        public string Customercode { get => customercode; set => customercode = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Note { get => note; set => note = value; }

        public ObjCustomer(string a, string b, string c, string d)
        {
            Customercode = Regex.Replace(a, " ", "");
            Name = b.Trim();
            Phone = Regex.Replace(c, " ", "");
            Note = d.Trim();
        }     
    }
}

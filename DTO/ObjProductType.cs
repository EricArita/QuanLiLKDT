using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace DTO
{
    public class ObjProductType
    {
        string name, code;

        public string Name { get => name; set => name = value; }
        public string Code { get => code; set => code = value; }

        public ObjProductType(string s, string t)
        {
            Code = s;
            Name = t;
        }
       
    }
}

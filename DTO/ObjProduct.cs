using System;
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
    public class ObjProduct
    {
        string productcode, typecode, providercode, name, importprice, saleprice, unit;

        public string Productcode { get => productcode; set => productcode = value; }
        public string Typecode { get => typecode; set => typecode = value; }
        public string Providercode { get => providercode; set => providercode = value; }
        public string Name { get => name; set => name = value; }
        public string Importprice { get => importprice; set => importprice = value; }
        public string Saleprice { get => saleprice; set => saleprice = value; }
        public string Unit { get => unit; set => unit = value; }
        
        public ObjProduct(string a, string b, string c, string d, string e, string f, string g)
        {
            Productcode = Regex.Replace(a, " ", "");
            Typecode = Regex.Replace(b, " ", "");
            Providercode = Regex.Replace(c, " ", "");
            Name = d.Trim();
            Importprice = Regex.Replace(e, " ", "");
            Saleprice = Regex.Replace(f, " ", "");
            Unit = Regex.Replace(g, " ", "");
        }       
    }
}

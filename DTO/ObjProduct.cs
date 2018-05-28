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
        string codeproduct, codetype, codeprovider, name, importprice, saleprice, unit;

        public string Codeproduct { get => codeproduct; set => codeproduct = value; }
        public string Codetype { get => codetype; set => codetype = value; }
        public string Codeprovider { get => codeprovider; set => codeprovider = value; }
        public string Name { get => name; set => name = value; }
        public string Importprice { get => importprice; set => importprice = value; }
        public string Saleprice { get => saleprice; set => saleprice = value; }
        public string Unit { get => unit; set => unit = value; }

        public ObjProduct(string a, string b, string c, string d, string e, string f, string g)
        {
            Codeproduct = Regex.Replace(a, " ", "");
            Codetype = Regex.Replace(b, " ", "");
            Codeprovider = Regex.Replace(c, " ", "");
            Name = d.Trim();
            Importprice = Regex.Replace(e, " ", "");
            Saleprice = Regex.Replace(f, " ", "");
            Unit = Regex.Replace(g, " ", "");
        }       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ObjSupplier
    {
        string suppliercode, name, note;

        public string Suppliercode { get => suppliercode; set => suppliercode = value; }
        public string Name { get => name; set => name = value; }
        public string Note { get => note; set => note = value; }
       
        public ObjSupplier(string a, string b, string c)
        {
            Suppliercode = a.Trim();
            Name = b.Trim();
            Note = c.Trim();
        }
    }
}

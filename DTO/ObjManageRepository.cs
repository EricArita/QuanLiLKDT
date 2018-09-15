using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ObjManageRepository
    {
        string productcode, productname, suppliercode,suppliername, date, status, amount, note;

        public string Productcode { get => productcode; set => productcode = value; }
        public string Productname { get => productname; set => productname = value; }
        public string Suppliercode { get => suppliercode; set => suppliercode = value; }
        public string Suppliername { get => suppliername; set => suppliername = value; }
        public string Date { get => date; set => date = value; }
        public string Status { get => status; set => status = value; }
        public string Amount { get => amount; set => amount = value; }
        public string Note { get => note; set => note = value; }

        public ObjManageRepository(string a, string b, string c, string d, string e, string f, string g, string h)
        {
            Productcode = a.Trim();
            Productname = b.Trim();
            Suppliercode = c.Trim();
            Suppliername = d.Trim();
            Date = e.Trim();
            Status = f.Trim();
            Amount = g.Trim();
            Note = h.Trim();
        }
       
    }
}

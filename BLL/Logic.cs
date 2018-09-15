using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DAL;
using DTO;

namespace BLL
{
    public abstract class Logic
    {      
       public DataSet getDataBase(string NameOfTable)
        {
           switch (NameOfTable)
            {
                case "KhoHangTon":
                    return Connection.Instance.getData("EXEC TaoBangHangTonKho;");
                default:
                    return Connection.Instance.getData("SELECT * FROM " + NameOfTable);                   
            }
           
        }
    }
}


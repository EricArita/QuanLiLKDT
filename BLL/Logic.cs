using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class Logic
    {
        public DataSet getDataBase(string TableName)
        {
            return Connection.Instance.getData("SELECT * FROM " + TableName);
        }

    }
}


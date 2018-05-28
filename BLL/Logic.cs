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
        protected Connection connect = new Connection();

        public DataSet getDataBase(string TableName)
        {
            return connect.getData("SELECT * FROM " + TableName);
        }

    }
}


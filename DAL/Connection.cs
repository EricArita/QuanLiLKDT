using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DAL
{
    public class Connection
    {
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        string path_connect = @"Data Source=DESKTOP-RNV8JUS\SQLEXPRESS;Initial Catalog=QLLinhKienDT;Integrated Security=True";
        DataSet ds = new DataSet();

        public DataSet getData(string sql)
        {
            try
            {
                conn = new SqlConnection(path_connect);
                conn.Open();
                adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds, sql);
                conn.Close();
                return ds;
            }
            catch (Exception )
            {
                return null;
            }
        }

        public bool setData(string sql)
        {
            try
            {
                conn = new SqlConnection(path_connect);
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

    }
}


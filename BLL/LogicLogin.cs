using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using DAL;
using DTO;

namespace BLL
{
    public class LogicLogin : Logic
    {
        public string getID_User(ObjLogin client)
        {
            try
            {
                DataSet dt = Connection.Instance.getData("SELECT MaTaiKhoan FROM TaiKhoan WHERE Username = '" + client.Username + "' AND  Password = '" + client.Password + "';");
                return dt.Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác");
                return "-1";
            }
        }
    }
}

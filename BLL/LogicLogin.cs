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
                return " ";
            }
        }

        public string getID_Permission(string ID_User)
        {
            DataSet dt = Connection.Instance.getData("SELECT MaPhanQuyen FROM PhanQuyen WHERE MaTaiKhoan = '" + ID_User + "';");
            return dt.Tables[0].Rows[0][0].ToString();
        }

        public List<string> getDetailPermission(string ID_Permission)
        {
            DataSet dt = Connection.Instance.getData("SELECT BtnName FROM ChiTietPhanQuyen WHERE MaPhanQuyen = '" + ID_Permission + "';");

            List<string> container = new List<string>();
            foreach(DataRow dr in dt.Tables[0].Rows)
            {
                container.Add(dr[0].ToString());
            }

            return container;
        }
    }
}

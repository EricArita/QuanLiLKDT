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
    public class LogicCustomer : Logic
    {
        string nameOfTable = " KhachHang ";

        public DataSet getDataBase(ObjCustomer client)
        {
            return connect.getData("SELECT * FROM" + nameOfTable + "WHERE MaKhach = '" + client.Codecustomer + "'");
        }

        public void setDataBase(ObjCustomer client, string button)
        {
            if (button == "Add")
            {
                bool ok = connect.setData("INSERT INTO" + nameOfTable + "VALUES('" + client.Codecustomer + "', N'" + client.Name + "', '" + client.Phone + "', N'" + client.Note + "');");

                if (ok)
                    MessageBox.Show("Thêm thông tin thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm thông ti thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (button == "Delete")
            {
                connect.setData("DELETE FROM" + nameOfTable + "WHERE MaKhach = '" + client.Codecustomer + "'");
                return;
            }
        }

        public void editDataBase(ObjCustomer client_initial, ObjCustomer client_edited)
        {
            connect.setData("UPDATE" + nameOfTable + "SET MaKhach = '" + client_edited.Codecustomer + "', TenKhach = N'" + client_edited.Name + "', SoDT = '" + client_edited.Phone + "', GhiChu = N'" + client_edited.Note + "' WHERE MaKhach = '" + client_initial.Codecustomer + "';");
            return;
        }
    }
}

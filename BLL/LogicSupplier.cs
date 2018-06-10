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
    public class LogicSupplier : Logic
    {
        string nameOfTable = " NguonCungCap ";

        public DataSet getDataBase(ObjSupplier client)
        {
            return connect.getData("SELECT * FROM" + nameOfTable + "WHERE MaNguon = '" + client.Codesupplier + "'");
        }

        public void setDataBase(ObjSupplier client, string button)
        {
            if (button == "Add")
            {
                bool ok = connect.setData("INSERT INTO" + nameOfTable + "VALUES('" + client.Codesupplier + "', N'" + client.Name +  "', N'" + client.Note + "');");

                if (ok)
                    MessageBox.Show("Thêm thông tin thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm thông tin thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (button == "Delete")
            {
                connect.setData("DELETE FROM" + nameOfTable + "WHERE MaNguon = '" + client.Codesupplier + "'");
                return;
            }
        }

        public void editDataBase(ObjSupplier client_initial, ObjSupplier client_edited)
        {
            connect.setData("UPDATE" + nameOfTable + "SET MaNguon = '" + client_edited.Codesupplier + "', TenNguon = N'" + client_edited.Name + "', GhiChu = N'" + client_edited.Note + "' WHERE MaNguon = '" + client_initial.Codesupplier + "';");
            return;
        }
    }
}

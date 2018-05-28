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
    public class LogicProductType : Logic
    {
        public DataSet getDataBase(ObjProductType client)
        {
            return connect.getData("SELECT * FROM LoaiSP WHERE MaLoai = '" + client.Code + "'");
        }

        public void setDataBase(ObjProductType client, string button)
        {
            if (button == "Add")
            {
                bool ok = connect.setData("INSERT INTO LoaiSP VALUES('" + client.Code + "', N'" + client.Name + "')");
                if (ok)
                    MessageBox.Show("Thêm thông tin thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm thông tin thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (button == "Delete")
            {
                connect.setData("DELETE FROM LoaiSP WHERE MaLoai = '" + client.Code + "'");
                return;
            }
        }

        public void editDataBase(ObjProductType client_initial, ObjProductType client_edited)
        {
            connect.setData("UPDATE LoaiSP SET MaLoai = '" + client_edited.Code + "', TenLoai = N'" + client_edited.Name + "' WHERE MaLoai = '" + client_initial.Code + "'");
            return;
        }

    }
}

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
    public class LogicManageRepository :  Logic
    {
        string nameOfTable = " Kho ";

        public DataSet getDataBase(ObjManageRepository client, string nameOfTable)
        {
            return Connection.Instance.getData("SELECT SoLuong FROM" + nameOfTable + "WHERE MaSP = '" + client.Productcode + "'");
        }

        public void setDataBase(ObjManageRepository client, string button, string ID)
        {
            if (button == "Add")
            {
                bool ok = Connection.Instance.setData("INSERT INTO" + nameOfTable + "VALUES('" + client.Productcode + "', N'" + client.Productname + "', '" + client.Suppliercode + "', N'" + client.Suppliername + "', '" + client.Date + "', N'" + client.Status + "', '" + client.Amount + "', '" + client.Note + "');");

                if (ok)
                    MessageBox.Show("Thêm thông tin thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm thông tin thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           if (button == "Delete")
            {
                Connection.Instance.setData("DELETE FROM" + nameOfTable + "WHERE IDKho = '" + ID 
                                            + "'; EXEC SortID;");
                                           
                return;
            }
        }

        public void editDataBase(string ID, ObjManageRepository client_edited)
        {
            Connection.Instance.setData("UPDATE" + nameOfTable + "SET MaSP = '" + client_edited.Productcode + "', TenSP = N'" + client_edited.Productname + "', MaNguon = '" + client_edited.Suppliercode + "', ThoiGian = '" + client_edited.Date + "', TrangThai = N'" + client_edited.Status + "', SoLuong = '" + client_edited.Amount + "', GhiChu = N'" + client_edited.Note + "' WHERE IDKho = '" + ID + "';");
            return;
        }
    }
}

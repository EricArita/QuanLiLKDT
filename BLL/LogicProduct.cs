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
    public class LogicProduct : Logic
    {
        string nameOfTable = " SanPham ";

        public DataSet getDataBase(ObjProduct client)
        {
            return Connection.Instance.getData("SELECT * FROM" + nameOfTable +  "WHERE MaSP = '" + client.Codeproduct + "'");
        }

        public void setDataBase(ObjProduct client, string button)
        {
            if (button == "Add")
            {
                bool ok = Connection.Instance.setData("INSERT INTO" + nameOfTable + "VALUES('" + client.Codeproduct + "', '" + client.Codetype + "', '" + client.Codeprovider + "', N'" + client.Name + "', " + client.Importprice + ", " + client.Saleprice + ", N'" + client.Unit + "');");              
     
                if (ok)
                    MessageBox.Show("Thêm thông tin thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm thông tin thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (button == "Delete")
            {
                Connection.Instance.setData("DELETE FROM" + nameOfTable + "WHERE MaSP = '" + client.Codeproduct + "'");
                return;
            }
        }

        public void editDataBase(ObjProduct client_initial, ObjProduct client_edited)
        {
            Connection.Instance.setData("UPDATE" + nameOfTable + "SET MaSP = '" + client_edited.Codeproduct + "', MaLoai = '" + client_edited.Codetype + "', MaNguon = '" + client_edited.Codeprovider + "', TenSP = N'" + client_edited.Name + "', GiaNhap = " + client_edited.Importprice + ", " + "GiaBan = " + client_edited.Saleprice + ", DonViTinh = '" + client_edited.Unit + "' WHERE MaSP = '" + client_initial.Codeproduct + "';");
            return;
        }
    }
}

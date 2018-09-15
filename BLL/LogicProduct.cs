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
            return Connection.Instance.getData("SELECT * FROM" + nameOfTable +  "WHERE MaSP = '" + client.Productcode + "'");
        }

        public void setDataBase(ObjProduct client, string button)
        {
            if (button == "Add")
            {              
                bool ok = Connection.Instance.setData("INSERT INTO" + nameOfTable + "VALUES('" + client.Productcode + "', '" + client.Typecode + "', '" + client.Providercode + "', N'" + client.Name + "', " + client.Importprice + ", " + client.Saleprice + ", N'" + client.Unit + "');");
                               
                if (ok)
                    MessageBox.Show("Thêm thông tin thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Danh mục loại sản phẩm chưa tồn tại mã loại này hoặc danh mục nguồn cung cấp chưa tồn tại mã nguồn này! Vui lòng cập nhật các thông tin trên trước khi thêm sản phẩm ! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;              
            }

            if (button == "Delete")
            {
                Connection.Instance.setData("DELETE FROM" + nameOfTable + "WHERE MaSP = '" + client.Productcode + "'");
                return;
            }
        }

        public void editDataBase(ObjProduct client_initial, ObjProduct client_edited)
        {
            Connection.Instance.setData("UPDATE" + nameOfTable + "SET MaSP = '" + client_edited.Productcode + "', MaLoai = '" + client_edited.Typecode + "', MaNguon = '" + client_edited.Providercode + "', TenSP = N'" + client_edited.Name + "', GiaNhap = " + client_edited.Importprice + ", " + "GiaBan = " + client_edited.Saleprice + ", DonViTinh = '" + client_edited.Unit + "' WHERE MaSP = '" + client_initial.Productcode + "';");
            return;
        }
    }
}

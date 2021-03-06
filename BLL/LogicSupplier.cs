﻿using System;
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
            return Connection.Instance.getData("SELECT * FROM" + nameOfTable + "WHERE MaNguon = '" + client.Suppliercode + "'");
        }

        public void setDataBase(ObjSupplier client, string button)
        {
            if (button == "Add")
            {
                bool ok = Connection.Instance.setData("INSERT INTO" + nameOfTable + "VALUES('" + client.Suppliercode + "', N'" + client.Name +  "', N'" + client.Note + "');");

                if (ok)
                    MessageBox.Show("Thêm thông tin thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm thông tin thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (button == "Delete")
            {
                Connection.Instance.setData("DELETE FROM" + nameOfTable + "WHERE MaNguon = '" + client.Suppliercode + "'");
                return;
            }
        }

        public void editDataBase(ObjSupplier client_initial, ObjSupplier client_edited)
        {
            Connection.Instance.setData("UPDATE" + nameOfTable + "SET MaNguon = '" + client_edited.Suppliercode + "', TenNguon = N'" + client_edited.Name + "', GhiChu = N'" + client_edited.Note + "' WHERE MaNguon = '" + client_initial.Suppliercode + "';");
            return;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class LogicReport : Logic
    {
        public DataSet getDataBase(string fromDate, string toDate)
        {
            //convert Datetime type in C# to suitable Datetime type in SQL
            fromDate = fromDate.Substring(6, 4) + fromDate.Substring(3, 2) + fromDate.Substring(0, 2);
            toDate = toDate.Substring(6, 4) + toDate.Substring(3, 2) + toDate.Substring(0, 2) + " 23:59:59";

            return Connection.Instance.getData("SELECT MaSP, TenSP, MaNguon, TenNguon, ThoiGian, SoLuong, GhiChu " +
                                                "FROM Kho WHERE TrangThai = N'Nhập' AND ThoiGian >= '" + fromDate + "' AND ThoiGian <= '" + toDate + "';");
        }
    }
}

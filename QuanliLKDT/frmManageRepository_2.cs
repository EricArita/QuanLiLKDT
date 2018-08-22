using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace QuanliLKDT
{
    public partial class frmManageRepository_2 : Form
    {
        public frmManageRepository_2()
        {
            InitializeComponent();
        }

        DataSet Temporary_Dataset;
        LogicManageRepository server = new LogicManageRepository();

        private void frmManageRepository_2_Load(object sender, EventArgs e)
        {          
            Temporary_Dataset = server.getDataBase("KhoHangTon");
            dataGridView.DataSource = Temporary_Dataset.Tables[0];
            dataGridView.Columns[0].Width = 271;      
            dataGridView.Columns[1].Width = 271;
            dataGridView.Columns[2].Width = 271;
            dataGridView.Columns[3].Width = 271;
            dataGridView.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView.Columns[1].HeaderText = "Tên sản phẩm ";
            dataGridView.Columns[2].HeaderText = "Tên nhà cung cấp";
            dataGridView.Columns[3].HeaderText = "Số lượng còn lại";

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
        }

        public void updateDataGridview(string ProductCode, string ProductName, string SupplierName, int Amount, string querry)
        {
            if (querry == "add")
            {
                DataRow row = Temporary_Dataset.Tables[0].NewRow();
                row["MaSP"] = ProductCode;
                row["TenSP"] = ProductName;
                row["TenNguon"] = SupplierName;
                row["SoLuong"] = Amount.ToString();
                Temporary_Dataset.Tables[0].Rows.Add(row);
                return;
            }

            if(querry == "inc" || querry == "dec")
            {
                for(int i = 0; i < dataGridView.RowCount; i++)
                {
                    if (dataGridView.Rows[i].Cells[0].Value.ToString() == ProductCode)
                    {
                        int p = int.Parse(dataGridView.Rows[i].Cells[3].Value.ToString());
                        if (querry == "inc")
                            dataGridView.Rows[i].Cells[3].Value = p + Amount;
                        else
                        {
                            if (querry == "dec")
                                dataGridView.Rows[i].Cells[3].Value = p - Amount;
                            else
                                dataGridView.Rows[i].Cells[3].Value = p - Amount;
                        }
                        return;
                    }
                }
            }           
        }

        public void closeForm()
        {
            this.Close();
        }
    }
}

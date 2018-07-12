using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DTO;
using BLL;

namespace QuanliLKDT
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void enable_button(int stt)
        {
            if (stt == 0)
            {
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
                btnUpdate.Enabled = false;
                txtCodeProduct.Enabled = txtCodeType.Enabled = txtCodeProvider.Enabled = false;
                txtNameProduct.Enabled = txtImportPrice.Enabled = txtSalePrice.Enabled = txtUnit.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                txtCodeProduct.Enabled = txtCodeType.Enabled = txtCodeProvider.Enabled = true;
                txtNameProduct.Enabled = txtImportPrice.Enabled = txtSalePrice.Enabled = txtUnit.Enabled = true;
            }
        }

        LogicProduct server;
        ObjProduct client, client_edited;
        string button;

        private void frmProduct_Load(object sender, EventArgs e)
        {
            enable_button(0);

            server = new LogicProduct();
      
            DataSet dataset = server.getDataBase("SanPham");
            dataGridView.DataSource = dataset.Tables[0];
            dataGridView.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView.Columns[1].HeaderText = "Mã loại";
            dataGridView.Columns[2].HeaderText = "Mã nguồn cung cấp";
            dataGridView.Columns[3].HeaderText = "Tên sản phẩm";
            dataGridView.Columns[4].HeaderText = "Giá nhập";
            dataGridView.Columns[5].HeaderText = "Giá bán";
            dataGridView.Columns[6].HeaderText = "Đơn vị tính";
            dataGridView.Columns[3].Width = 145;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            enable_button(1);
            txtCodeProduct.Text = txtCodeType.Text = txtCodeProvider.Text = " ";
            txtNameProduct.Text = txtImportPrice.Text = txtSalePrice.Text = txtUnit.Text = " ";
            button = "Add";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            enable_button(1);
            button = "Edit";
            client = new ObjProduct(txtCodeProduct.Text, txtCodeType.Text, txtCodeProvider.Text, txtNameProduct.Text, txtImportPrice.Text, txtSalePrice.Text, txtUnit.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa loại sản phẩm này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            button = "Delete";
            if (res == DialogResult.Yes)
            {
                client = new ObjProduct(txtCodeProduct.Text, txtCodeType.Text, txtCodeProvider.Text, txtNameProduct.Text, txtImportPrice.Text, txtSalePrice.Text, txtUnit.Text);
                server = new LogicProduct();
                server.setDataBase(client, button);
                DataSet dataset_AfterDeleting = server.getDataBase("SanPham");
                dataGridView.DataSource = dataset_AfterDeleting.Tables[0];
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (button == "Add")
            {
                client = new ObjProduct(txtCodeProduct.Text, txtCodeType.Text, txtCodeProvider.Text, txtNameProduct.Text, txtImportPrice.Text, txtSalePrice.Text, txtUnit.Text);
                server = new LogicProduct();
                DataSet dataset_Check = server.getDataBase(client);
 
                if (dataset_Check.Tables[0].Rows.Count > 0)
                    MessageBox.Show("Sản phẩm này đã tồn tại trong danh sách", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    server.setDataBase(client, button);
                    dataset_Check = server.getDataBase("SanPham");
                    dataGridView.DataSource = dataset_Check.Tables[0];
                }

                enable_button(0);
                button = "";
                return;
            }

            if (button == "Edit")
            {
                client_edited = new ObjProduct(txtCodeProduct.Text, txtCodeType.Text, txtCodeProvider.Text, txtNameProduct.Text, txtImportPrice.Text, txtSalePrice.Text, txtUnit.Text);
                server = new LogicProduct();
                server.editDataBase(client, client_edited);
                DataSet dataset_edit = server.getDataBase("SanPham");
                dataGridView.DataSource = dataset_edit.Tables[0];
                enable_button(0);
                button = "";
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult res;

            if (btnUpdate.Enabled == true)
                res = MessageBox.Show("Bạn chưa cập nhật thông tin hiện tại. Bạn có chắc muốn thoát?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else
                res = MessageBox.Show("Bạn có chắc muốn thoát?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                this.Close();

                foreach (frmMain f in Application.OpenForms)
                {
                    foreach (XtraTabPage tab in f.xtraTabControl_Function.TabPages)
                    {
                        if (tab.Name == this.Name)
                        {
                            f.xtraTabControl_Function.TabPages.Remove(tab);
                            return;
                        }
                    }
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodeProduct.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            txtCodeType.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            txtCodeProvider.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            txtNameProduct.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            txtImportPrice.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            txtSalePrice.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            txtUnit.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
